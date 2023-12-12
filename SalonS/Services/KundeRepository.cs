using SalonS.Models.Kunde;

namespace SalonS.Services;

public class KundeRepository : IKundeRepository
{
    //Instans felt
    private List<Kunde> _kunderRepo = new List<Kunde>(); // Use non-nullable list

    public Kunde? KundeLoggedIn { get; private set; } // Use non-nullable Kunde

    
    //Constructor
    public KundeRepository(bool mockData = false)
    {
        
        KundeLoggedIn = null;
        //_kunder = JsonFileServices.ReadFromJson<User>(_fileName);
        
        if (mockData)
        {
            //_kunderRepo.Add(new Kunde(1,"saad", "42546563", "hsfh@live.dk", "2000"));
            //_kunderRepo.Add(new Kunde(2, "saaad", "98234576", "yhbh@gmail.com", "2450"));
            //_kunderRepo.Add(new Kunde(3, "ødelagt i fort 16-0", "12456587", "peop@outlook.gb", "4312"));
        }
    }

    public Kunde? KundeLoggedin { get; }

    public void AddKunde(Kunde kunde)
    {
        _kunderRepo.Add(kunde);
        //JsonFileServices.WriteToJson(_usersRepo, _fileName);

    }
    
    public List<Kunde> Search(string Email)
    {
        List<Kunde> searchResults = new List<Kunde>();

        foreach (Kunde user in _kunderRepo)
        {
            if ((user.Navn.IndexOf(Email, StringComparison.OrdinalIgnoreCase) != -1) ||
                (user.Navn.IndexOf(Email, StringComparison.OrdinalIgnoreCase) != -1))
            {
                searchResults.Add(user);
            }
        }
        return searchResults;
    }
    

    public void LogoutKunde()
    {
        KundeLoggedIn = null;
        
    }

    public List<Kunde?> GetAlleKunder()
    {
        return _kunderRepo;
    }


    public Kunde? GetKunde(int kundenummer)
    {
        return _kunderRepo.FirstOrDefault(x => x?.Kundenummer == kundenummer);
    }

    public void RemoveKunde(int kundenummer)
    {
        var user = _kunderRepo.FirstOrDefault(x => x.Kundenummer == kundenummer);
        if (user != null)
        {
            _kunderRepo.Remove(user);
            //JsonFileServices.WriteToJson(_usersRepo, _fileName);
        }
    }
    
    public void UpdateKunde(Kunde kunde)
    {
        var existingUser = _kunderRepo.FirstOrDefault(x => x?.Kundenummer == kunde.Kundenummer);
        if (existingUser != null)
        {
            var userIndex = _kunderRepo.IndexOf(existingUser);
            _kunderRepo.Remove(existingUser);
            _kunderRepo.Insert(userIndex, kunde);

           // JsonFileServices.WriteToJson(_usersRepo, _fileName);
        }
    }
    
    
    public bool CheckKunde(string email, string adgangskode)
    {
        Kunde? foundUser = _kunderRepo.Find(u => u.Email == email && u.Adgangskode == adgangskode);

        if (foundUser != null)
        {
            KundeLoggedIn = foundUser;
            return true;
        }
        else
        {
            return false;
        }
    }
    
}