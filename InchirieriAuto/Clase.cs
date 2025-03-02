using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InchirieriAuto
{
    //Clasa masina
    public class Masina
    {
        string model;
        string tip_combustibil;
        int an_fabricatie;

        public Masina()
        {
            model = string.Empty;
            tip_combustibil = string.Empty;
            an_fabricatie = 0;
        }

        public Masina(string _model, string _tip_combustibil, int _an_fabricatie)
        {
            model = _model;
            tip_combustibil = _tip_combustibil;
            an_fabricatie = _an_fabricatie;
        }

        public string Info()
        {
            return $"Model: {model}\n" +
                $"Motorizare: {tip_combustibil}\n" +
                $"An fabricatie: {an_fabricatie}";

        }
    }
}
