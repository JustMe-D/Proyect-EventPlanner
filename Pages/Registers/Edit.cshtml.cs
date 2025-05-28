using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyect_EventPlanner.Data;
using Proyect_EventPlanner.Models;

namespace Proyect_EventPlanner.Pages.Registers
{
    public class EditModel : PageModel
    {
        private readonly EventContext _context;

        public EditModel(EventContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Register Register{ get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            ViewData["IdEvent"] = new SelectList(_context.Events, "IdEvent", "EventName");
            ViewData["IdParticipant"] = new SelectList(_context.Participants, "IdParticipant", "Name");
            if (id == null || _context.Registers == null)
            {
                Console.WriteLine("ERROR1" + id);
                return NotFound();
            }
            var register = await _context.Registers.FirstOrDefaultAsync(m => m.IdRegister== id);
            if (register == null)
            {
                Console.WriteLine("ERROR2" + id);

                return NotFound();
            }
            Register = register;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Register).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterExists(Register.IdRegister))
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
        private bool RegisterExists(int id)
        {
            return (_context.Registers?.Any(o => o.IdRegister== id)).GetValueOrDefault();
        }
    }
}
