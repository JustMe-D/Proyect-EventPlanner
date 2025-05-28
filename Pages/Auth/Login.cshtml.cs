using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyect_EventPlanner.Data;

namespace Proyect_EventPlanner.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly EventContext _context;

        public LoginModel(EventContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public class InputModel
        {
            [Required]
            public string Name { get; set; } = string.Empty;
            [Required]
            public string Password { get; set; } = string.Empty;
        }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == Input.Name);

            if (user == null || user.Password != Input.Password)
            {
                ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos.");
                return Page();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var identity = new ClaimsIdentity(claims, "MyCookieAuth");

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

            return RedirectToPage("/Index");
        }
    }
}
