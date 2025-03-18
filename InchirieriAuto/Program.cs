using System;
using System.Configuration;
using LibrarieModele;
using NivelStocareDateNou;

namespace InchirieriAuto
{
    public class Program
    {
        static void Main(string[] args)
        {
            string numeFisier = ConfigurationManager.AppSettings["NumeFisierClienti"];
            AdministrareClienti_FisierText adminClienti = new AdministrareClienti_FisierText(numeFisier);
            Client clientNou = new Client();
            int nrClienti = 0;


            Masina masinaNoua = new Masina();

            string opt = "";

            do
            {
                Console.WriteLine("\nMENIU: ");
                Console.WriteLine("C. Citire masina de la tastatura");
                Console.WriteLine("D. Citire client de la tastatura");
                Console.WriteLine("A. Afisare ultima masina introdusa");
                Console.WriteLine("E. Afisare ultimul client introdus");
                Console.WriteLine("W. Afisare date masina dupa model");
                Console.WriteLine("Y. Afisare date client dupa nume");
                Console.WriteLine("S. Salvare client in fisier");
                Console.WriteLine("R. Citire toti clientii din fisier");
                Console.WriteLine("X. Inchidere program");
                Console.WriteLine();

                Console.WriteLine("Alegeti o optiune: ");
                opt = Console.ReadLine();
                if (opt == null)
                {
                    Console.WriteLine("Input cannot be null");
                }
                else
                { 
                    switch (opt.ToUpper())
                    {
                        case "C":
                            masinaNoua = CitireMasinaTastatura();
                            break;
                        case "D":
                            clientNou = CitireClientT();
                            break;
                        case "E":
                            AfisareClientTastatura(clientNou);
                            break;
                        case "A":
                            AfisareMasinaTastatura(masinaNoua);
                            break;
                        case "W":
                            IdentificareDupaNume(masinaNoua);
                            break;
                        case "Y":
                            IdentificareDupaNumeClient(clientNou);
                            break;
                        case "S":
                            adminClienti.AddClient(clientNou);
                            Console.WriteLine("Client salvat");
                            break;
                        case "R":

                            Client[] clienti = adminClienti.GetClienti(out nrClienti);
                            if (nrClienti == 0)
                            {
                                Console.WriteLine("Nu exista clienti in fisier");
                            }
                            else
                            {
                                for (int i = 0; i < nrClienti; i++)
                                {
                                    Console.WriteLine(clienti[i].Info());
                                }
                            }
                            break;
                        case "X":
                            return;
                        default:
                            Console.WriteLine("Optiune inexistenta");
                            break;
                    }
                }
            } while (true);

        }

        public static Masina CitireMasinaTastatura()
        {
            Console.WriteLine("Introduceti modelul: ");
            string nume = Console.ReadLine();

            Console.WriteLine("Introduceti tipul combustibilului: ");
            string combustibil = Console.ReadLine();

            Console.WriteLine("Introduceti anul fabricatiei: ");
            int anFabricatie;
            while (!int.TryParse(Console.ReadLine(), out anFabricatie))
            {
                Console.WriteLine("Anul trebuie sa fie un numar! Introduceti din nou: ");
            }

            return new Masina(nume, combustibil, anFabricatie);

        }

        public static void AfisareMasinaTastatura(Masina masina)
        {
            if (string.IsNullOrEmpty(masina.model))
            {
                Console.WriteLine("Nu exista nicio masina introdusa!");
                return;
            }

            Console.WriteLine($"Model: {masina.model}, Combustibil: {masina.tip_combustibil}, An: {masina.an_fabricatie}");
        }

        public static void IdentificareDupaNume(Masina masina)
        {
            Console.WriteLine("Introduceti un model: ");
            string model1 = Console.ReadLine();

            if (model1.Equals(masina.model))
            {
                Console.WriteLine($"Modelul {masina.model} functioneaza pe {masina.tip_combustibil}");
            }
            else
            {
                Console.WriteLine("Modelul introdus nu corespunde");
            }
        }
        public static Client CitireClientT()
        {
            Console.WriteLine("Introduceti numele: ");
            string nume = Console.ReadLine();
            Console.WriteLine();


            Console.WriteLine("Introduceti email-ul: ");
            string email = Console.ReadLine();
            Console.WriteLine();


            Console.WriteLine("Introduceti CNP-ul: ");
            string CNP = Console.ReadLine();

            while (CNP.Length != 13)
            {
                Console.WriteLine("CNP invalid. Reintroduceti: ");
                CNP = Console.ReadLine();

            }
            Console.WriteLine();

            Console.WriteLine("Introduceti numarul de telefon: ");
            string telefon = Console.ReadLine();

            while (telefon.Length != 10)
            {
                Console.WriteLine("Numar de telefon invalid. Reintroduceti: ");
                telefon = Console.ReadLine();
            }

            return new Client(nume, email, CNP, telefon);
        }

        public static void AfisareClientTastatura(Client client)
        {
            if (string.IsNullOrEmpty(client.nume))
            {
                Console.WriteLine("Nu exista niciun client introdus!");
                return;
            }
            Console.WriteLine($"Nume: {client.nume}" +
                $"\nemail: {client.email}" +
                $"\nCNP: {client.CNP}" +
                $"\nNumar telefon: {client.telefon}");
        }
        public static void IdentificareDupaNumeClient(Client client)
        {
            Console.WriteLine("Introduceti un nume: ");
            string nume = Console.ReadLine();

            if (client.nume.Contains(nume))
            {
                Console.WriteLine($"Persoana {client.nume} are numarul de telefon: {client.telefon} si adresa de mail: {client.email}");
            }
            else
            {
                Console.WriteLine("Numele introdus nu corespunde");

            }
        }
    }
}
