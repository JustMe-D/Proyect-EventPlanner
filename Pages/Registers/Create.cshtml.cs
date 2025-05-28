using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyect_EventPlanner.Data;
using Proyect_EventPlanner.Models;

namespace Proyect_EventPlanner.Pages.Registers
{
    public class CreateModel : PageModel
    {
        private readonly EventContext _context;

        public CreateModel(EventContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["IdEvent"] = new SelectList(_context.Events, "IdEvent", "EventName");
            ViewData["IdParticipant"] = new SelectList(_context.Participants, "IdParticipant", "Name");

            return Page();
        }
        [BindProperty]

        public Register Register{ get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Events == null || Register == null)
            {
                return Page();
            }
            _context.Registers.Add(Register);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
