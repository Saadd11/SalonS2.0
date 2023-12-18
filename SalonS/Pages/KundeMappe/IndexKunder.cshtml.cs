using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalonS.Services;

namespace SalonS.Pages.KundeMappe;

public class IndexKunder : PageModel
{
    private IKundeRepository _kunde;

    public Models.Kunde KundeLoggedIn { get; private set; }

    public IndexKunder(IKundeRepository kunder)
    {
        _kunde = kunder;
    }

    public IActionResult OnGet()
    {
        if (_kunde is null || _kunde.KundeLoggedIn is null )
        {
            return RedirectToPage("/Login");
        }

        KundeLoggedIn = _kunde.KundeLoggedIn;
        return Page();
    }
}
