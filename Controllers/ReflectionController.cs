using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using outrusive.Data;
using outrusive.Models;

namespace outrusive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReflectionController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public static Reflection reflection = new Reflection();

        public ReflectionController(DataContext dataContext) 
        { 
            _dataContext = dataContext;
        }

        [HttpGet, Authorize]
        public async Task<ActionResult> GetReflections(string request) 
        {
            List<Reflection> thoughts = await _dataContext.Reflections.Where(u => u.UserId == request).OrderByDescending(d => d.DateCreated).ToListAsync();
   
            if (!thoughts.Any())
            {
                return Ok();
            }else
            {
                return Ok(thoughts);
            }
        }

        [HttpPost, Authorize]
        public async Task<ActionResult> PostReflections(Reflection request)
        {
            try
            {
                reflection.Id = Guid.NewGuid().ToString();
                reflection.UserId = request.UserId;
                reflection.HabitOrFact = request.HabitOrFact;
                reflection.Assumptions = request.Assumptions;
                reflection.Thought = request.Thought;
                reflection.Source = request.Source;
                reflection.BlackAndWhite = request.BlackAndWhite;
                reflection.DateCreated = DateTime.UtcNow;
                reflection.Evidence = request.Evidence;
                reflection.EvidenceAgainst = request.EvidenceAgainst;
                reflection.Exaggeration = request.Exaggeration;
                reflection.OnlyConsideringSupportingEvidence = request.OnlyConsideringSupportingEvidence;
                reflection.FactOrFeeling = request.FactOrFeeling;
                reflection.LikelyOrWorstCase = request.LikelyOrWorstCase;
                reflection.OtherInterpretations = request.OtherInterpretations;
                
                var SavedReflection = await _dataContext.AddAsync(reflection);

                if (SavedReflection != null)
                {
                    await _dataContext.SaveChangesAsync();
                    
                    return Ok();
                }
                else
                {
                    BadRequest();
                }

            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
}
