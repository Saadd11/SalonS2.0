using Microsoft.Extensions.Primitives;
using SalonS.Models;

namespace SalonS.Services
{
    public interface IKundeRepository
    {   
        Kunde KundeLoggedIn { get; }

    
        void AddKunde(Kunde kunde);
        bool CheckKunde(string email, string adgangskode);
        void LogoutKunde();
        public Kunde GetKunde(int kundenummer);
        Kunde? GetKundeNr(int kundenummer);
        public void Edit(Kunde kunde);
        // Combined methods
        void RemoveKunde(int kundenummer);
        List<Kunde> GetKunde();
        Kunde Opdater(Kunde kunde);
        //Tilføj update kunde. 
    }
}