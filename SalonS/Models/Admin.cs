namespace SalonS.Models
{
    public class Admin
    {
        private string _navn;
        private string _tlf;
        private string _email;
        private string _adgangskode;


        /*
         * Properties
         */
        public string NavnAdmin
        {
            get { return _navn; }
            set { _navn = value; }
        }

        public string TlfAdmin
        {
            get { return _tlf; }
            set { _tlf = value; }
        }

        public string EmailAdmin
        {
            get { return _email; }
            set { _email = value; }
        }

        public string AdgangskodeAdmin
        {
            get { return _adgangskode; }
            set { _adgangskode = value; }
        }

        public Admin()
        {
            _navn = "";
            _tlf = "";
            _email = "";
            _adgangskode = "";
        }

        public Admin(string NavnAdmin, string TlfAdmin, string EmailAdmin, string AdgangskodeAdmin)
        {
            _navn = NavnAdmin;
            _tlf = TlfAdmin;
            _email = EmailAdmin;
            _adgangskode = AdgangskodeAdmin;
        }



        public override string ToString()
        {
            return $"Navn: {_navn}, Tlf: {_tlf}, Email: {_email}, Adgangskode: {_adgangskode}";
        }


    }

}
