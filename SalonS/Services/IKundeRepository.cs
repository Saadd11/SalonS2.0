using SalonS.Models.Kunde;

namespace SalonS.Services
{
    public interface IKundeRepository
    {
        Kunde? KundeLoggedin { get; }
        
        void AddKunde(Kunde kunde);
        void UpdateKunde(Kunde kunde);
        Kunde? GetKunde(int id);
        void RemoveKunde(int kundenummer);
        bool CheckKunde(string email, string adgangskode);
        void LogoutKunde();
        
        
    }
}