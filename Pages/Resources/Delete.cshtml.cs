using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyect_EventPlanner.Data;
using Proyect_EventPlanner.Models;

namespace Proyect_EventPlanner.Pages.Resources
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
        public Resource Resource { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Resource = await _context.Resources
                .Include(r => r.Event)
                .FirstOrDefaultAsync(m => m.IdResource == id);

            if (Resource == null)
            {
                return NotFound();
            }


            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
             var Resource = await _context.Resources.FindAsync(id);

            if (Resource != null)
            {
                _context.Resources.Remove(Resource);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
