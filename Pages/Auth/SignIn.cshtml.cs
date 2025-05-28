using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyect_EventPlanner.Data;
using Proyect_EventPlanner.Models;

namespace Proyect_EventPlanner.Pages.Auth
{
    public class SignInModel : PageModel
    {
        private readonly EventContext _context;

        public SignInModel(EventContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; } = new User { Role = "User" };

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Users == null || User == null)
            {
                return Page();
            }

            // Verificar si el nombre de usuario ya existe
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Name == User.Name);
            if (existingUser != null)
            {
                ModelState.AddModelError("User.Name", "UserName already on use.");
                return Page();
            }

            // Asegurarse de que el rol sea "User"
            User.Role = "User";

            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Auth/Login");
        }
    }
}