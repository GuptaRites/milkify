using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http; // Required for Session
using milkify.Areas.Identity.Data;

namespace milkify.Areas.Identity.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<MilkifyUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(SignInManager<MilkifyUser> signInManager, ILogger<LogoutModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<IActionResult> OnPost(string? returnUrl = null)
        {
            // Sign out the user
            await _signInManager.SignOutAsync();

            // Clear session
            HttpContext.Session.Clear();

            _logger.LogInformation("User logged out and session cleared.");

            if (!string.IsNullOrEmpty(returnUrl))
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                // Redirect to home or login page after logout
                return RedirectToPage("/Index");
            }
        }
    }
}
