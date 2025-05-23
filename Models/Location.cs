using System.ComponentModel.DataAnnotations;

namespace Proyect_EventPlanner.Models
{
    public class Location
    {
        [Key]
        public int IdLocation { get; set; }

        [Required]
        [StringLength(200)]
        public string LocationName { get; set; }

        [Required]
        public int Capacity { get; set; }

        [StringLength(500)]
        public string? Address { get; set; }

        public ICollection<Event>? Events { get; set; } = new List<Event>();
    }
}
