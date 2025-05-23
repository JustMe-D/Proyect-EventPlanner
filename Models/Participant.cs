using System.ComponentModel.DataAnnotations;
using Microsoft.Win32;

namespace Proyect_EventPlanner.Models
{
    public class Participant
    {
        [Key]
        public int IdParticipant { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(20)]
        public string? Phone { get; set; }

        public ICollection<Register>? Registers { get; set; } = new List<Register>();
    }
}
