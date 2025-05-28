using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyect_EventPlanner.Data;

namespace Proyect_EventPlanner.Pages.Registers
{
    public class IndexModel : PageModel
    {
        private readonly EventContext _context;

        public IndexModel(EventContext context)
        {
            _context = context;
        }

        public IList<Models.Register> Registers{ get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Events != null)
            {
                Registers = await _context.Registers.ToListAsync();
            }
        }
    }
}
