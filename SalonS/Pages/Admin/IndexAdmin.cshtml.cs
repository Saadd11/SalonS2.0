using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalonS.Services;

namespace SalonS.Pages.Admin;

public class IndexAdmin : PageModel
{
        private IKundeRepository _admins;

        public Models.Admin AdminLoggedIn {  get; private set; }

        public IndexAdmin(IKundeRepository Admins)
        {
            _admins = Admins;
        }

        public IActionResult OnGet()
        {
            if (_admins is null || _admins.AdminLoggedIn is null || !_admins.AdminLoggedIn.IsAdminAdmin) {
                return RedirectToPage("/Login");
            }

            AdminLoggedIn = _admins.AdminLoggedIn;   

            return Page();
        }
    }