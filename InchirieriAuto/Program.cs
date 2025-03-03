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
            //Instantierea unui obiect de tip Masina, folisind constructorul cu parametri

            Masina m1 = new Masina("Dacia Logan", "1.4 Benzina", 2008);
            string entitate1 = m1.Info();
            Console.WriteLine(entitate1);

            //Instantierea unui obiect de tip Client, folisind constructorul cu parametri
            Client c1 = new Client("Popescu Tudor", "popescutudor@gmail.com", "5000101123456", "+40723123456");
            string entitate2 = c1.Info();
            Console.WriteLine(entitate2);
        }
    }
}
