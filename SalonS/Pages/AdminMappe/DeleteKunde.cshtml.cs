using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalonS.Services;
using SalonS.Models;

namespace SalonS.Pages.Admin
{


    public class DeleteKundeModel : PageModel
    {

        private IKundeRepository _kunderRepo;

        public DeleteKundeModel(IKundeRepository kunderRepo)
        {
            _kunderRepo = kunderRepo;
        }

        public Models.Kunde Kunde { get; private set; }

        public IActionResult OnGet(int kundenummer)
        {
            Kunde = _kunderRepo.GetKundeNr(kundenummer);

            return Page();
        }

        public IActionResult OnPostDelete(int kundenummer)
        {
            _kunderRepo.RemoveKunde(kundenummer);
            return RedirectToPage("Index");
        }
        
        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }




    }
}