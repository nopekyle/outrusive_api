using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace outrusive.Models
{
    [PrimaryKey(nameof(Id))]
    public class Reflection
    {
        public string Id { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string UserId { get; set; } = string.Empty;
        [StringLength(1000)]
        public string Assumptions { get; set; } = string.Empty;
        [StringLength(1000)]
        public string Evidence { get; set; } = string.Empty;
        [StringLength(1000)]
        public string EvidenceAgainst { get; set; } = string.Empty;
        [StringLength(1000)]
        public string FactOrFeeling { get; set;} = string.Empty;
        [StringLength(1000)]
        public string HabitOrFact { get; set; } = string.Empty;
        [StringLength(1000)]
        public string Exaggeration { get; set; } = string.Empty;
        [StringLength(1000)]
        public string BlackAndWhite { get; set; } = string.Empty;
        [StringLength(1000)]
        public string LikelyOrWorstCase { get; set; } = string.Empty;
        [StringLength(1000)]
        public string OnlyConsideringSupportingEvidence { get; set; } = string.Empty;
        [StringLength(1000)]
        public string OtherInterpretations { get; set; } = string.Empty;
        [StringLength(1000)]
        public string Source { get; set; } = string.Empty;
        [StringLength(1000)]
        public string Thought { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }

    }
}
