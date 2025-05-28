using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyect_EventPlanner.Data;
using Proyect_EventPlanner.Models;

namespace Proyect_EventPlanner.Pages.Users
{
    [Authorize]
        public class CreateModel : PageModel
        {
            private readonly EventContext _context;

            public CreateModel(EventContext context)
            {
                _context = context;
            }
            public IActionResult OnGet()
            {
                return Page();
            }
            [BindProperty]
            public User User { get; set; } = default!;
            public List<SelectListItem> RoleOptions { get; } = new()
    {
        new SelectListItem { Value = "User", Text = "User" },
        new SelectListItem { Value = "Admin", Text = "Admin" }
    };
            public async Task<IActionResult> OnPostAsync()
            {
                if (!ModelState.IsValid || _context.Users == null || User == null)
                {
                    return Page();
                }
                _context.Users.Add(User);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }


        }
    }

