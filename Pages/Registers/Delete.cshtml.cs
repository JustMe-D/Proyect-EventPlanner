using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyect_EventPlanner.Data;
using Proyect_EventPlanner.Models;

namespace Proyect_EventPlanner.Pages.Registers
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
        public Register Register{ get; set; } = default;

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (id == null || _context.Registers == null)
            {
                return NotFound();
            }
            var register = await _context.Registers.FirstOrDefaultAsync(m => m.IdRegister== id);
            if (register == null)
            {
                return NotFound();
            }
            else
            {
                Register = register;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Registers == null)
            {
                return NotFound();
            }
            var register = await _context.Registers.FindAsync(id);
            if (register != null)
            {
                Register = register;
                _context.Registers.Remove(Register);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
