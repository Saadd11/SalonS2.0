using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalonS.Services;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace SalonS.Pages
{
    public class BookingModel : PageModel
    {
        [BindProperty] public DateTime Dato { get; set; }

        [BindProperty] public string Klippetype { get; set; }

        [BindProperty] public int Kundenummer { get; set; } // Add property to store Kundenummer

        [Inject] public SignInManager<ApplicationId> SignInManager { get; set; }

        [Inject] public IBookingRepository BookingRepository { get; set; }

        [Inject] public IKundeRepository KundeRepository { get; set; }

        public List<string> Kliptyper { get; private set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
        {
                        // Create a new booking using the form data
                        var nyBooking = new Booking
                        {
                            Kunde = customerInfo,
                            Dato = Dato,
                            Kliptyper = Klippetype,
                            // Assign other booking properties here
                        };

                        // Save the booking to the database (you need to implement this)
                        // BookingRepository.CreateBooking(nyBooking);

                        // Redirect to a confirmation page or another appropriate page
                        return RedirectToPage("BookingConfirmation");
                    }
                    else
                    {
                        // Handle the case where the customer information is not found
                        ModelState.AddModelError(string.Empty, "Customer information not found.");
                    }
                }
                else
                {
                    // Handle the case where the user is not authenticated
                    ModelState.AddModelError(string.Empty, "User not authenticated.");
                }
            }

            // If ModelState is not valid or any error occurs, return to the booking page with validation errors
            return Page();
        }
    }
}
// Retrieve the logged
