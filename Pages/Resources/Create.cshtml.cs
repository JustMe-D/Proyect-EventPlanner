using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyect_EventPlanner.Data;
using Proyect_EventPlanner.Models;

namespace Proyect_EventPlanner.Pages.Resources
{
    public class CreateModel : PageModel
    {
        private readonly EventContext _context;

        public CreateModel(EventContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Resource Resource { get; set; }

        public SelectList EventOptions { get; set; }

        public IActionResult OnGet()
        {
            EventOptions = new SelectList(_context.Events.ToList(), "IdEvent", "EventName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                EventOptions = new SelectList(_context.Events.ToList(), "IdEvent", "EventName");
                return Page();
            }

            _context.Resources.Add(Resource);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
