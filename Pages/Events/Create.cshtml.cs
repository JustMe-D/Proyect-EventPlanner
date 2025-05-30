using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyect_EventPlanner.Data;
using Proyect_EventPlanner.Models;

namespace Proyect_EventPlanner.Pages.Events
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly EventContext _context;

        public CreateModel(EventContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["IdLocation"] = new SelectList(_context.Locations, "IdLocation", "LocationName");
            return Page();
        }
        [BindProperty]

        public Event Event { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Events == null || Event == null)
            {
                return Page();
            }
            _context.Events.Add(Event);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
    