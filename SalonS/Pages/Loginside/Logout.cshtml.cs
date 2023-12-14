using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalonS.Services;

namespace SalonS.Pages

{
    public class LogoutModel : PageModel
    {
        private readonly IKundeRepository _kundeRepository;

        public LogoutModel(IKundeRepository kundeRepository)
        {
            _kundeRepository = kundeRepository;
        }

        public RedirectToPageResult OnGet()
        {
            _kundeRepository.LogoutKunde();

            return RedirectToPage("ConfirmLogout");
        }
    }
}