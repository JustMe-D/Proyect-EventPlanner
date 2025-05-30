using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyect_EventPlanner.Data;
using Proyect_EventPlanner.Models;

namespace Proyect_EventPlanner.Pages.Resources
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly EventContext _context;

        public EditModel(EventContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Resource Resource { get; set; }

        public SelectList EventOptions { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Resource = await _context.Resources.FindAsync(id);

            if (Resource == null)
            {
                return NotFound();
            }

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

            _context.Attach(Resource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Resources.Any(e => e.IdResource == Resource.IdResource))
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
    }
}
