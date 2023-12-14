using SalonS.Models;

namespace SalonS.Services
{
    public class BookingRepository : IBookingRepository
    {
        private readonly List<Kunde?> _kunderRepo = new List<Kunde?>();

        private readonly Dictionary<string, Booking> _katalogBooking;
        
        private List<string> _kliptyper = new List<string>() {"Klipning med skæg", "klipning uden skæg"};


        /*
         * Constructor
         */

        public BookingRepository(bool mockData = false)
        {
            _katalogBooking = new Dictionary<string, Booking>();

            if (mockData)
            {
                PopulateBookingRepository();
            }
        }

        private void PopulateBookingRepository()
        {
            
            _katalogBooking.Add("1", new Booking(1, DateTime.Parse("2023-12-01"), "09:23", "Ali", "Buzzcut", 300,
                new Kunde(1, "ali", "55235465", "test.dk", "ggg")));
            
            _katalogBooking.Add("2", new Booking(2, DateTime.Parse("2023-12-28"), "19:55", "Saad", "Fade", 300,
                new Kunde(2, "D", "67349922", "test.dk", "ggg")));
            
            _katalogBooking.Add("3", new Booking(3, DateTime.Parse("2023-01-21"), "22:27", "D", "Klipning & Skæg", 300,
                new Kunde(3, "Saad", "98547612", "test.dk", "ggg")));
        }

        public List<Booking>? Bookings { get; set; }

        public Booking HentBookingID(int bookingId)
        {
            return _katalogBooking.Values.FirstOrDefault(b => b.BookingId == bookingId) ?? throw new InvalidOperationException();
        }

        public Dictionary<string, Booking> GetAll()
        {
            return _katalogBooking;
        }

        public void Tilføj(Booking booking)
        {
            // Generate a unique ID for the booking (e.g., use a counter)
            booking.BookingId = _katalogBooking.Count + 1;

            _katalogBooking.Add(booking.BookingId.ToString(), booking);
        }

        public void Delete(int id)
        {
            var booking = HentBookingID(id);
            _katalogBooking.Remove(booking.BookingId.ToString());
        }

        public Kunde? FindByCustomerId(int kundenummer)
        {
            return _kunderRepo.FirstOrDefault(x => x?.Kundenummer == kundenummer);
        }

        public void OpdaterBooking(Booking booking)
        {
            booking.Dato = booking.Dato;
            booking.Tid = booking.Tid;
            booking.Frisør = booking.Frisør;
            booking.Klip = booking.Klip;
            booking.Pris = booking.Pris;
        }

        public List<Kunde?> HentAlleKunder()
        {
            return _kunderRepo.ToList();
        }
 
        public List<Booking> HentAlleBooking()
        {
            return _katalogBooking.Values.ToList();
        }
    }
}
