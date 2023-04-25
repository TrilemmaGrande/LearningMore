using System;

namespace Aufgabe.Event
{
    class Smartphone
    {
        public void Notruf(object sender, MyEventArgs e)
        {
            Console.WriteLine("Notruf wird abgesetzt");
        }
    }
}
