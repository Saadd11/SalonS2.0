using System.Text.Json;
using SalonS.Models;
using SalonS.Services;

namespace SalonS.Services
{
    public class BookingRepositoryjson : IBookingRepository
    {
    // instans felt
        Dictionary<string, Booking> _bookings;
        
    // properties
        public Dictionary<string, Booking> Bkatalog
        {
            get { return Bkatalog; }
            set { Bkatalog = value; }
        }

    // konstruktør
    public BookingRepositoryjson()
    {
        Bkatalog = ReadFromJson();
    }



    /*
     * metoder
     */
    public Booking Tilføj(Booking booking)
    {
        if (Bkatalog.ContainsKey(booking.Tid))
        {
            Bkatalog.Add(booking.Tid, booking);


            WriteToJson();
            return booking;
        }

        throw new ArgumentException($"Tid {booking.Tid} findes i forvejen");
    }

    public Dictionary<string, Booking> Bookings { get; set; }
    public List<Booking> HentAlleBooking()
    {
        throw new NotImplementedException();
    }
    
    public Booking Slet(string Tid)
    {
        Booking slettetBooking = HentBooking(Tid);
        Bkatalog.Remove(Tid);

        WriteToJson();
        return slettetBooking;
    }

    public Booking Opdater (Booking booking)
    {
        Booking editBooking = HentBooking(booking.Tid);
        Bkatalog[booking.Tid] = booking;
        
        

        WriteToJson();
        return booking;
    }



    public Booking HentBooking(string Tid)
    {
        if (Bkatalog.ContainsKey(Tid))
        {
            return Bkatalog[Tid];
        }
        else
        {
            // opdaget en fejl
            throw new KeyNotFoundException($"Tid {Tid} findes ikke");
        }
    }

    public List<Booking> HentAlleBookings()
    {
        return Bkatalog.Values.ToList();
    }

    public Booking HentBookingUdFraTid(string Tid)
    {
        Booking resBooking = null;

        foreach (Booking b in Bkatalog.Values)
        {
            if (b.Tid == Tid)
            {
                return b;
            }
        }

        return resBooking;
    }

    public List<Booking> Search(string? tid, string? frisør, string? klip, int pris)
    {
        List<Booking> retBookings = new List<Booking>(HentAlleBookings());

        if (tid is not null)
        {
            retBookings = retBookings.FindAll(b => b.Tid == tid);
        }

        if (frisør is not null)
        {
            retBookings = retBookings.FindAll(b => b.Frisør.Contains(frisør));
        }


        if (klip is not null)
        {
            retBookings = retBookings.FindAll(b => b.Klip.Contains(klip));
        }

        return retBookings;
    }


    private bool NumberASC = true;

    public List<Booking> SortTid()
    {
        List<Booking> retBookings = HentAlleBookings();

        retBookings.Sort(new SortByTid());

        if (!NumberASC)
        {
            retBookings.Reverse();
        }

        NumberASC = !NumberASC;

        return retBookings;
    }

    private class SortByTid : IComparer<Booking>
    {
        public int Compare (Booking? x, Booking? y)
        {
            if(x == null || y == null)
            {
                return 0;
            }

            //if (x.Tid > y.Tid)
            //{
            //    return 1;
            //}
            //else
            //{
            //    return -1;
            //}

            return x.Tid.CompareTo(y.Tid);
        }
    }

   
    




    public override string ToString()
    {
        String pænTekst = String.Join(", ", Bkatalog.Values);

        return $"{{{nameof(Bkatalog)}={pænTekst}}}";
    }


    /*
     * Hjælpe metoder til at læse og skrive til en fil i json format
     */

    private const string FILENAME = "BookingRepository.json";

    private Dictionary<string, Booking> ReadFromJson()
    {
        if (File.Exists(FILENAME))
        {
            StreamReader reader = File.OpenText(FILENAME);
            Dictionary<string, Booking> BKatalog = JsonSerializer.Deserialize<Dictionary<string, Booking>>(reader.ReadToEnd());
            reader.Close();
            return Bkatalog;
        }
        else
        {
            return new Dictionary<string, Booking>();
        }

    }

    private void WriteToJson()
    {
        FileStream fs = new FileStream(FILENAME, FileMode.Create);
        Utf8JsonWriter writer = new Utf8JsonWriter(fs);
        JsonSerializer.Serialize(writer, Bkatalog);
        fs.Close();
    }


    }
}

        
        



