using System;

namespace Aufgabe.Event
{
    class Program
    {
        static void Main(string[] args)
        {
            Smartphone smartphone = new Smartphone();
            Mensch mensch = new Mensch(smartphone);
            Auto auto = new Auto(mensch);

            mensch.Herzinfarkt();
            
        }
    }
}
