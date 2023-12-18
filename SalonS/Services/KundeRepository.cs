using SalonS.Models;

namespace SalonS.Services;

public class KundeRepository : IKundeRepository
{
    //Instans felt
    private List<Kunde> _kunderRepo = new List<Kunde>();
  


    public Kunde? KundeLoggedIn { get; private set; } // Use non-nullable Kunde
    
    
    
    public KundeRepository(bool mockData = false)
    {
        KundeLoggedIn = null;
        //_kunderRepo = JsonFileServices.ReadFromJson<Kunde>(_fileName);
        
        if (mockData)
        {
            
            // Add mock Kunde
            _kunderRepo.Add(new Kunde(1, "ali", "4254231", "test.dk", "ggg",false));
            // ... other Kunde ...
            _kunderRepo.Add(new Kunde(2, "ali", "4254231", "test.dk2", "ggg2",false));
            // ... other Kunde ...
            _kunderRepo.Add(new Kunde(3, "ali", "4254231", "test.dk3", "ggg3",true));
            // ... other Kunde ...

            // Add mock Admin
            
            // ... other Admin ...
        }
    }
    
    

    //KUNDE TING EFTER DET HER

    
    
    
    public void AddKunde(Kunde kunde)
    {
        _kunderRepo.Add(new Kunde());
        //JsonFileServices.WriteToJson(_usersRepo, _fileName);

    }

    

    public void LogoutKunde()
    {
        KundeLoggedIn = null;
        
    }

    public Kunde GetKunde(int kundenummer)
    {
        throw new NotImplementedException();
    }


    public List<Kunde> GetKunde()
    {
        return _kunderRepo;
    }

    public Kunde Opdater(Kunde kunde)
    {
        throw new NotImplementedException();
    }

    public Kunde? GetKundeNr(int kundenummer)
    {
        return _kunderRepo.FirstOrDefault(x => x?.Kundenummer == kundenummer);
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
    
    public void Edit(Kunde kunde)
    {
        kunde.Kundenummer = kunde.Kundenummer;
        kunde.Navn = kunde.Navn;
        kunde.Tlf = kunde.Tlf;
        kunde.Email = kunde.Email;
        kunde.Adgangskode = kunde.Adgangskode;
    }
}