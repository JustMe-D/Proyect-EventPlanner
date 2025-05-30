using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyect_EventPlanner.Data;

namespace Proyect_EventPlanner.Pages.Events
{
    [Authorize(Roles = "Admin,User")]
    public class IndexModel : PageModel
    {
        private readonly EventContext _context;

        public IndexModel(EventContext context)
        {
            _context = context;
        }

        public IList<Models.Event> Events{ get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Events != null)
            {
                Events = await _context.Events.ToListAsync();
            }
        }
    }
}
