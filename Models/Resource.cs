using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyect_EventPlanner.Models
{
    public class Resource
    {
        [Key]
        public int IdResource { get; set; }

        [Required]
        public int IdEvent { get; set; }

        [Required]
        [StringLength(200)]
        public string ResourceName { get; set; }

        [Required]
        public int Quantity { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [ForeignKey("IdEvent")]
        public Event? Event { get; set; }
    }
}
