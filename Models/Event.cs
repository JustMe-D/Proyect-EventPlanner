using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Win32;

namespace Proyect_EventPlanner.Models
{
    public class Event
    {
        [Key]
        public int IdEvent { get; set; }

        [Required]
        [StringLength(200)]
        public string EventName { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime FinishDate { get; set; }

        [Required]
        public int IdLocation { get; set; }

        [ForeignKey("IdLocation")]
        public Location? Location { get; set; }

        public ICollection<Register>? Registers { get; set; } = new List<Register>();

        public ICollection<Resource>? Resources { get; set; } = new List<Resource>();
    }
}
