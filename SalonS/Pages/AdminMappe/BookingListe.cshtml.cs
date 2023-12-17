using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalonS.Services;

namespace SalonS.Pages.AdminMappe
{
    public class BookinglisteModel : PageModel
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IKundeRepository _kundeRepository;

        public BookinglisteModel(IBookingRepository bookingRepository, IKundeRepository kundeRepository)
        {
            _bookingRepository = bookingRepository;
            _kundeRepository = kundeRepository;
        }

        public List<Models.Booking> Bookings { get; set; }
        public List<Models.Kunde> Kunder { get; set; }

        [BindProperty]
        public string Navn { get; set; }

        public string Tlf { get; set; }

        public void OnGet()
        {
            Bookings = _bookingRepository.HentAlleBooking();
            Kunder = _kundeRepository.GetKunde();
        }

        public IActionResult OnPost()
        {
            // Your post logic goes here, if needed
            return Page();
        }
    }
}