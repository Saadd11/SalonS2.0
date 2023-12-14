using Microsoft.Extensions.Primitives;
using SalonS.Models;
using SalonS.Models.Kunde;

namespace SalonS.Services
{
    public interface IKundeRepository
    {   
        Kunde KundeLoggedIn { get; }
        Admin? AdminLoggedIn { get; }

        void LogoutAdmin();

        void AddKunde(Kunde kunde);
        bool CheckKunde(string email, string adgangskode);
        void LogoutKunde();
        public List<Kunde> GetKunde();

        Kunde? GetKunde(int kundenummer);
        
        // Combined methods
        void RemoveKunde(int kundenummer);
    }
}