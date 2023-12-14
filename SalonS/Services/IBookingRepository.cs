using SalonS.Models;
using SalonS.Models.Kunde;

namespace SalonS.Services;

public interface IBookingRepository
{
    Booking HentBooking(string tid);
    Booking Opdater(Booking booking);
    Booking Slet(string tid);
    Booking Tilføj(Booking booking);
    public Kunde? HentAlleKunder(int Kundenummer);
    List<Booking> HentAlleBooking();
}