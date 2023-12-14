using SalonS.Models;

namespace SalonS.Services;

public interface IBookingRepository
{
    public List<Kunde?> HentAlleKunder();
    List<Booking> HentAlleBooking();
    Booking HentBookingID(int BookingId);
    Dictionary<string, Booking> GetAll();
    void Tilføj(Booking booking);
    void OpdaterBooking(Booking booking);
    void Delete(int id);
    Kunde? FindByCustomerId(int customerId);

    
}