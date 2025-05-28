using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyect_EventPlanner.Data;
using Proyect_EventPlanner.Models;

namespace Proyect_EventPlanner.Pages.Users
{
    [Authorize]
    public class DeleteModel : PageModel
        {
            private readonly EventContext _context;

            public DeleteModel(EventContext context)
            {
                _context = context;
            }

            [BindProperty]
            public User User { get; set; } = default!;

            public async Task<IActionResult> OnGetAsync(int? id)
            {
                if (id == null || _context.Users == null)
                {
                    return NotFound();
                }
                var user = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    User = user;
                }
                return Page();
            }
            public async Task<IActionResult> OnPostAsync(int? id)
            {
                if (id == null || _context.Users == null)
                {
                    return NotFound();
                }
                var user = await _context.Users.FindAsync(id);
                if (user != null)
                {
                    User = user;
                    _context.Users.Remove(User);
                    await _context.SaveChangesAsync();
                }
                return RedirectToPage("./Index");
            }
        }
}
