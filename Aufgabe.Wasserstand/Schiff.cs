using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe.Wasserstand
{
    internal class Schiff
    {
        private string name;

        public Schiff(string name)
        {
            this.name = name;
        }
        public void FahrtGestopptNiedrig()
        {
            FahrtGestoppt("niedrigem Wasserstand");
        }
        public void FahrtGestopptHoch()
        {
            FahrtGestoppt("hohem Wasserstand");
        }
        public void FahrtGestoppt(string wasserstand)
        {
            Console.WriteLine($"{name}: Fahrt wurde wegen zu {wasserstand} gestoppt");
        }
    }
}
