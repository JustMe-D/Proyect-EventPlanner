using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyect_EventPlanner.Data;
using Proyect_EventPlanner.Models;

namespace Proyect_EventPlanner.Pages.Participants
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly EventContext _context;

        public DeleteModel(EventContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Participant Participant { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Participants == null)
            {
                return NotFound();
            }

            var participant = await _context.Participants.FirstOrDefaultAsync(m => m.IdParticipant == id);

            if (participant == null)
            {
                return NotFound();
            }
            else
            {
                Participant = participant;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Participants == null)
            {
                return NotFound();
            }
            var participant = await _context.Participants.FindAsync(id);

            if (participant != null)
            {
                Participant = participant;
                _context.Participants.Remove(Participant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
