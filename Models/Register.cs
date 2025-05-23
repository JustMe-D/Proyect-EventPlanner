using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyect_EventPlanner.Models
{
    public class Register
    {
        [Key]
        public int IdRegister { get; set; }

        [Required]
        public int IdEvent { get; set; }

        [Required]
        public int IdParticipant { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }

        [ForeignKey("IdEvent")]
        public Event? Event { get; set; }

        [ForeignKey("IdParticipant")]
        public Participant? Participant { get; set; }
    }
}
