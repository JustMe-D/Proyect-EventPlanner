using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyect_EventPlanner.Data;
using Proyect_EventPlanner.Models;

namespace Proyect_EventPlanner.Pages.Participants
{
    public class EditModel : PageModel
    {
        private readonly EventContext _context;

        public EditModel(EventContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Participant Participant { get; set; } = default!;
        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id  == null || _context.Participants == null)
            {
                return NotFound();
            }

            var participant = await _context.Participants.FirstOrDefaultAsync(m => m.IdParticipant == id);
            if (participant == null)
            {
                return NotFound();
            }
            Participant = participant;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(Participant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantExists(Participant.IdParticipant))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ParticipantExists(int id) 
        {
            return (_context.Participants?.Any(e => e.IdParticipant == id)).GetValueOrDefault();
        }
    }
}
