using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibrarieModele
{
    //Clasa client
   public class Client
    {
        private const char SEPARATOR_AFISARE = ';';

        
        private const int NUME = 0;
        private const int EMAIL = 1;
        public string nume { get; set; }
        public string email { get; set; }
        public string CNP { get; set; }

        public string telefon { get; set; }

        public Client()
        {
           nume = string.Empty;
           email = string.Empty;
           CNP = string.Empty;
           telefon = string.Empty;
        }

        public Client(string _nume, string _email, string _CNP, string _telefon)
        {
            nume = _nume;
            email = _email;
            CNP = _CNP;
            telefon = _telefon;
        }
        public Client(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_AFISARE);

            if (dateFisier.Length >= 3)
            {
                
                this.nume = dateFisier[NUME];
                this.email = dateFisier[EMAIL];
            }
            else
            {
                Console.WriteLine("Eroare la citirea din fișier! Date incomplete.");
            }
        }
        public string Info()
        {
            return $"CLient: {nume}\n" +
                $"Email: {email}\n" +
                $"Numar telefon: {telefon}";

        }
        public string ConversieLaSir()
        {
            string obiectClientPentruFisier = string.Format("{1}{0}{2}{0}",
                SEPARATOR_AFISARE, 
                (nume ?? "NECUNOSCUT"),
                (email ?? "NECUNOSCUT"));
            return obiectClientPentruFisier;
        }
    }
}
