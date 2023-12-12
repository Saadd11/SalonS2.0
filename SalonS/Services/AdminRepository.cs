using SalonS.Models;
using SalonS.Models.Kunde;
using SalonS.ServicAs;
using System.Text;
using static SalonS.Services.AdminRepository;

namespace SalonS.Services
{

    public class AdminRepository : IAdminRepository
    {
        // instans felt
        private List<Admin> _katalogAdmin = new List<Admin>();

        public Admin? AdminLoggedIn { get; private set; }

        public AdminRepository(bool mockData = false)
        {
            AdminLoggedIn = null;

            if (mockData)
            {
                _katalogAdmin.Add(new Admin("saad", "42546563", "hsfh@live.dk", "2000"));
                _katalogAdmin.Add(new Admin("saaad", "98234576", "yhbh@gmail.com", "2450"));
                _katalogAdmin.Add(new Admin("ok", "12456587", "peop@outlook.gb", "4312"));
            }
        }

        public bool CheckAdmin(string email, string adgangskode)
        {
            Admin? foundUser = _katalogAdmin.Find(u => u.EmailAdmin == email && u.AdgangskodeAdmin == adgangskode);

            if (foundUser != null)
            {
                AdminLoggedIn = foundUser;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void LogoutAdmin()
        {
            AdminLoggedIn = null;
        }

        public Kunde RemoveKunde(int kundeNummer)
        {
            throw new NotImplementedException();
        }

        public Kunde HentKunde(int kundeNummer)
        {
            throw new NotImplementedException();
        }
    }



}
