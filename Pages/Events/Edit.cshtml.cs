using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyect_EventPlanner.Data;
using Proyect_EventPlanner.Models;

namespace Proyect_EventPlanner.Pages.Events
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
        public Event Event { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Console.WriteLine($"Editing event with ID: {id}");
            ViewData["IdLocation"] = new SelectList(_context.Locations, "IdLocation", "LocationName");
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }
            var Evente = await _context.Events.FirstOrDefaultAsync(m => m.IdEvent == id);
            if (Evente == null)
            {
                return NotFound();
            }
            Event = Evente;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Event).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(Event.IdEvent))
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
        private bool EventExists(int id)
        {
            return (_context.Events?.Any(o => o.IdEvent == id)).GetValueOrDefault();
        }
    }
}
