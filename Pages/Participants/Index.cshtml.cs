using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Proyect_EventPlanner.Data;
using Proyect_EventPlanner.Models;

namespace Proyect_EventPlanner.Pages.Participants
{
    public class IndexModel : PageModel
    {
        private readonly EventContext _context;

        public IndexModel(EventContext context)
        {
            _context = context;
        }

        public IList<Participant> Participants { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Participants != null)
            {
                Participants = await _context.Participants.ToListAsync();
            }

        }

    }
}
