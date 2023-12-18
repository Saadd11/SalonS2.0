using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalonS.Services;

namespace SalonS.Pages.Admin;

    public class EditKunde : PageModel
    {
   
        private IKundeRepository _kunderRepo;

        public EditKunde(IKundeRepository kunderRepo)
        {
            _kunderRepo = kunderRepo;
        }


        [BindProperty]
        public int NytKundeNummer { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "Der skal v�re et navn")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Der skal v�re mindst to tegn i et navn")]
        public string NytKundeNavn { get; set; }



        [BindProperty]
        public string NytKundetlf { get; set; }
        
        [BindProperty] 
        public string NytKundeEmail { get; set; }
    




        public string ErrorMessage { get; private set; }
        public bool Error { get; private set; }



        public void OnGet(int kundenummer)
        {
            ErrorMessage = "";
            Error = false;

            try
            {
                Models.Kunde kunde = _kunderRepo.GetKundeNr(kundenummer);

                NytKundeNummer = kunde.Kundenummer;
                NytKundeNavn = kunde.Navn;
                NytKundetlf = kunde.Tlf;
                NytKundeEmail = kunde.Email;
            }
            catch (KeyNotFoundException knfe)
            {
                ErrorMessage = knfe.Message;
                Error = true;
            }
        }
        
        
        

        public IActionResult OnPostChange()
        {
            if ( !ModelState.IsValid )
            {
                return Page();
            }

            Models.Kunde kunde = _kunderRepo.Opdater(new Models.Kunde(NytKundeNummer, NytKundeNavn, NytKundetlf, NytKundeEmail));

            return RedirectToPage("Index");
        }
        

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
