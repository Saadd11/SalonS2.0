using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalonS.Services;

namespace SalonS.Pages.Kunde;

public class IndexKunderModel : PageModel
{
    private IKundeRepository _kunde;

    public Models.Kunde.Kunde KundeLoggedIn { get; private set; }

    public IndexKunderModel(IKundeRepository users)
    {
        _kunde = users;
    }

    public IActionResult OnGet(int kundenummer)
    {
        if (_kunde is null || _kunde.KundeLoggedIn is null )
        {
            return RedirectToPage("/Login");
        }

        KundeLoggedIn = _kunde.GetKunde(kundenummer);

        if (KundeLoggedIn is null)
        {
            // Handle the case where the customer with the provided ID was not found.
            return RedirectToPage("/NotFound"); // You can replace this with the appropriate redirect.
        }

        return Page();
    }
}
