using SalonS.Models;
using SalonS.Models.Kunde;

namespace SalonS.ServicAs

{
    public interface IAdminRepository
    {
        Admin? AdminLoggedIn { get; }
        bool CheckAdmin(string email, string adgangskode);
        void LogoutAdmin();
        Kunde RemoveKunde(int kundeNummer);
        Kunde HentKunde(int kundeNummer);
    }
}