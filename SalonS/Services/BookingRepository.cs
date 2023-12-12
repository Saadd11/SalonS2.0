using SalonS.Models;

namespace SalonS.Services

{
    public class BookingRepository : IBookingRepository
    {

        // instans felt
        private Dictionary<string, Booking> _katalogBooking;


        // properties
        public Dictionary<string, Booking> _Bkatalog
        {
            get { return _katalogBooking; }
            set { _katalogBooking = value; }
        }

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
            //_katalogBooking.Add(1.ToString(), new Booking("10:00", "Ali", "Taperfade", 300));
            //_katalogBooking.Add(2.ToString(), new Booking("12:00", "Dani", "Lowfade",300));
            //_katalogBooking.Add(3.ToString(), new Booking("15:00", "Musti", "Midfade",300));
        }

        
        public Dictionary<string, Booking>? Bookings { get; set; }

        public List<Booking> HentAlleBooking()
        {
            return _katalogBooking.Values.ToList();
        }

        public Booking HentBooking(string Tid)
        {
            if (_katalogBooking.ContainsKey(Tid))
            {
                return _katalogBooking[Tid];
            }

            return null;
        }

        public Booking Opdater(Booking booking)
        {
            Booking Edit = HentBooking(booking.Tid);

            _katalogBooking[booking.Tid] = booking;

            return booking;        
        }

        public Booking Slet(string tid)
        {
            Booking slettetBooking = HentBooking(tid);

            _katalogBooking.Remove(tid);

            return slettetBooking;        
        }
        

        public Booking Tilføj(Booking booking)
        {
            if (_katalogBooking.ContainsKey(booking.Tid))
            {
                _katalogBooking.Add(booking.Tid,booking);
                return booking;
            }

            throw new ArgumentException();
        }

    }

}

