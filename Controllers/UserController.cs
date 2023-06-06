using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using outrusive.Data;
using outrusive.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace outrusive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;
        public static User user = new User();

        public UserController(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }

        [HttpGet("Id")]
        public async Task<ActionResult<string>> GetUserName(string Id)
        {
            try
            {
                User? DbUser = await _dataContext.Users.FindAsync(Id);

                if (DbUser == null)
                {
                    return NotFound("");
                }
                return Ok(DbUser.Name);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register([FromBody] User request)
        {
            try
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
                user.Email = request.Email;
                user.Name = request.Name;
                user.Id = Guid.NewGuid().ToString();

                await _dataContext.Users.AddAsync(user);
                await _dataContext.SaveChangesAsync();
                return Ok(user.Id);
            }
            catch (DbUpdateException)
            {
                BadRequest("");
            }
            return BadRequest("");
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(User request)
        {
            try
            {
                User? DbUser = await _dataContext.Users.Where(u => u.Email == request.Email).FirstOrDefaultAsync();

                if(DbUser == null)
                {
                    return NotFound();
                }

                if (!BCrypt.Net.BCrypt.Verify(request.Password, DbUser.Password))
                {
                    return BadRequest("Incorrect email and/or password.");
                }
                else
                {
                    string token = CreateToken(DbUser);
                    return Ok(token);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        internal string CreateToken(User u)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, u.Id),
                new Claim(ClaimTypes.Name, u.Name)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(claims: claims, signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
