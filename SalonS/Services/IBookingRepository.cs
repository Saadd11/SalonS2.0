using SalonS.Models;

namespace SalonS.Services;

public interface IBookingRepository
{
    public Dictionary<string, Booking>? Bookings { get; set; }
    List<Booking> HentAlleBooking();
    Booking HentBooking(string tid);
    Booking Opdater(Booking booking);
    Booking Slet(string tid);
    Booking Tilføj(Booking booking);
    
    
}