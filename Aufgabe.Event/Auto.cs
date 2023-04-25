using System;

namespace Aufgabe.Event
{
    class Auto
    {
        private Mensch mensch;

        public Auto(Mensch mensch)
        {
            this.mensch = mensch;
            this.mensch.MyEvent += this.mensch.GetSmartphone().Notruf;
            this.mensch.MyEvent += Warnblinklicht;
            this.mensch.MyEvent += RechtsRanFahren;
        }

        public void Warnblinklicht(object sender, MyEventArgs e)
        {
            Console.WriteLine("Warnblinker eingeschaltet");
        }
        public void RechtsRanFahren(object sender, MyEventArgs e)
        {
            Console.WriteLine("Auto fährt rechts ran");
        }
    }
}
