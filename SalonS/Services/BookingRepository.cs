using SalonS.Models;
using SalonS.Models.Kunde;

namespace SalonS.Services
{
    public class BookingRepository : IBookingRepository
    {
        private List<Kunde?> _kunderRepo = new List<Kunde?>();

        private Dictionary<string, Booking> _katalogBooking;

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
            _katalogBooking.Add("1", new Booking("10:00", "Ali", "Taperfade", 300, Convert.ToDateTime("2023, 12, 28"),new Kunde(1, "ali", "4254231", "test.dk", "ggg")));
            _katalogBooking.Add("2", new Booking("12:00", "Dani", "Lowfade", 300,Convert.ToDateTime("2023, 07, 28"),new Kunde(1, "ali", "4254231", "test.dk", "ggg")));;
            _katalogBooking.Add("3", new Booking("15:00", "Musti", "Midfade", 300,Convert.ToDateTime("2023, 11, 28"),new Kunde(1, "ali", "4254231", "test.dk", "ggg")));
        }

        public List<Booking>? Bookings { get; set; }


        
        public Booking HentBooking(string tid)
        {
            _katalogBooking.TryGetValue(tid, out var booking);
            return booking;
        }

        public Booking Opdater(Booking booking)
        {
            if (_katalogBooking.ContainsKey(booking.Tid))
            {
                _katalogBooking[booking.Tid] = booking;
                return booking;
            }

            throw new KeyNotFoundException($"No booking found with time {booking.Tid} to update.");
        }

        public Booking Slet(string tid)
        {
            if (_katalogBooking.TryGetValue(tid, out var slettetBooking))
            {
                _katalogBooking.Remove(tid);
                return slettetBooking;
            }

            throw new KeyNotFoundException($"No booking found with time {tid} to delete.");
        }

        public Booking Tilføj(Booking booking)
        {
            if (!_katalogBooking.ContainsKey(booking.Tid))
            {
                _katalogBooking.Add(booking.Tid, booking);
                return booking;
            }

            throw new ArgumentException($"A booking with time {booking.Tid} already exists.");
        }

        public Kunde? HentAlleKunder(int kundenummer)
        {
            return _kunderRepo.FirstOrDefault(x => x?.Kundenummer == kundenummer);

        }

        public List<Booking> HentAlleBooking()
        {
            return _katalogBooking.Values.ToList();
        }
        

    }
}

    