using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalonS.Services;

namespace SalonS.Pages;

public class LoginModel : PageModel
{
    private IKundeRepository _kundeRepository;

    public LoginModel(IKundeRepository KundeRepository)
    {
        _kundeRepository = KundeRepository;
    }

    [BindProperty]
    public string Email { get; set; }

    [BindProperty]
    public string Adgangskode { get; set; }

    public void OnGet()
    {
    }
    public IActionResult OnPost()
    {
        if (Email == null || Adgangskode == null)
        {
            return Page();
        }

        if (!_kundeRepository.CheckKunde(Email, Adgangskode))
        {
            return Page();
        }

        //husk ændre det her
        return RedirectToPage("Index");
    }
}
