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
    }
}