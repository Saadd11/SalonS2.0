using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SalonS.Pages.Kunde
{
    public class Opretkunde : PageModel
    {
        [BindProperty, Required(ErrorMessage = "Indtast Navn"),
         Display(Name = "Navn")]
        public string Navn { get; set; }
        
        [BindProperty, Required(ErrorMessage = "Indtast Telefon Nummer"),
         Display(Name = "Tlf.nr")]
        public string Tlf { get; set; }
        
        [BindProperty, Required(ErrorMessage = "Indtast Email"),
         Display(Name = "Email")]
        public string Email { get; set; }
        
        
        
        [BindProperty, Required(ErrorMessage = "Indtast Adgangskode"),
         Display(Name = "Adgangskode")]
        public string Adgangskode { get; set; }
        
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
         if (!ModelState.IsValid)
         {
          return Page();
         }

         // Perform registration logic here

         // Redirect to the Opretbooking page
         return RedirectToPage("/Booking/Opretbooking");
        }
        }
        
    }
