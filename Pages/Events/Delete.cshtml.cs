using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyect_EventPlanner.Data;
using Proyect_EventPlanner.Models;

namespace Proyect_EventPlanner.Pages.Events
{
    public class DeleteModel : PageModel
    {
        private readonly EventContext _context;

        public DeleteModel(EventContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Event Event { get; set; } = default;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }
            var even= await _context.Events.FirstOrDefaultAsync(m => m.IdLocation == id);
            if (even == null)
            {
                return NotFound();
            }
            else
            {
                Event = even;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            Console.WriteLine($"Deleting event with ID: {id}");
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }
            var even = await _context.Events.FindAsync(id);
            if (even != null)
            {
                Event = even;
                _context.Events.Remove(Event);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
