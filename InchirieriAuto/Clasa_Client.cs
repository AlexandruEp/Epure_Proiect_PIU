using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InchirieriAuto
{
    //Clasa client
    public class Client
    {
        string nume;
        string email;
        string CNP;
        string telefon;

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

        public string Info()
        {
            return $"CLient: {nume}\n" +
                $"Email: {email}\n" +
                $"Numar telefon: {telefon}";

        }
    }
}
