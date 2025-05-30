using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyect_EventPlanner.Data;
using Proyect_EventPlanner.Models;

namespace Proyect_EventPlanner.Pages.Locations
{
    [Authorize(Roles = "Admin,User")]
    public class IndexModel : PageModel
    {
        private readonly EventContext _context;

        public IndexModel(EventContext context)
        {
            _context = context;
        }

        public IList<Location> Locations { get; set; } = new List<Location>();

        public async Task OnGetAsync()
        {
            Locations = await _context.Locations.ToListAsync();
        }
    }
}
