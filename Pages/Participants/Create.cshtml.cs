using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyect_EventPlanner.Data;
using Proyect_EventPlanner.Models;

namespace Proyect_EventPlanner.Pages.Participants
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly EventContext _context;

        public CreateModel (EventContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Participant Participant { get; set; } = default!;
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Participants == null || Participant == null)
            {
                return Page();
            }

            _context.Participants.Add(Participant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
