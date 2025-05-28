using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyect_EventPlanner.Data;
using Proyect_EventPlanner.Models;

namespace Proyect_EventPlanner.Pages.Resources
{
    public class IndexModel : PageModel
    {
        private readonly EventContext _context;

        public IndexModel(EventContext context)
        {
            _context = context;
        }

        public IList<Resource> ResourceList { get; set; } =  default!;

        public async Task OnGetAsync()
        {
            ResourceList = await _context.Resources.ToListAsync();
            ResourceList = await _context.Resources
                .Include(r => r.Event)
                .ToListAsync();
        }
    }
}
