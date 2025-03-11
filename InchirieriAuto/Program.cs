using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InchirieriAuto
{
    class Program
    {
        static void Main()
        {
            Masina masinaNoua = new Masina();
            string opt;

            do
            {
                Console.WriteLine("\nMENIU: ");
                Console.WriteLine("C. Citire masina de la tastatura");
                Console.WriteLine("A. Afisare ultima masina introdusa");
                Console.WriteLine("W. Afisare date masina dupa model");
                Console.WriteLine("X. Inchidere program");

                Console.WriteLine("Alegeti o optiune: ");
                opt = Console.ReadLine();

                switch (opt.ToUpper())
                {
                    case "C":
                        masinaNoua = CitireMasinaTastatura();
                        break;
                    case "A":
                        AfisareMasinaTastatura(masinaNoua);
                        break;
                    case "W":
                        IdentificareDupaNume(masinaNoua);
                        break;
                    case "X":
                        return;
                    default:
                        Console.WriteLine("Optiune inexistenta");
                        break;
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

            if (model1 == masina.model)
            {
                Console.WriteLine($"Modelul {masina.model} functioneaza pe {masina.tip_combustibil}");
            }
            else
            {
                Console.WriteLine("Modelul introdus nu corespune");
            }
        }
    }
}
