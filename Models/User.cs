using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace outrusive.Models
{
    [PrimaryKey(nameof(Id))]
    public class User
    {
        public string Id { get; set; } = string.Empty;
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string Password { get; set; } = string.Empty;
    }
}
