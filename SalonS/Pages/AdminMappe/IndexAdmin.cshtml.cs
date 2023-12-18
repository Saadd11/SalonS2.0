using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalonS.Services;

namespace SalonS.Pages.AdminMappe;

public class IndexAdmin : PageModel
{
        private IKundeRepository _kunde;

        public Models.Kunde KundeLoggedIn {  get; private set; }

        public IndexAdmin(IKundeRepository kunde)
        {
            _kunde = kunde;
        }

        public IActionResult OnGet()
        {
            if (_kunde is null || _kunde.KundeLoggedIn is null || !_kunde.KundeLoggedIn.IsAdmin) {
                return RedirectToPage("/Login");
            }

            KundeLoggedIn= _kunde.KundeLoggedIn;   

            return Page();
        }
    }