using System;

namespace Aufgabe.Event
{
    class Mensch
    {
        public event EventHandler<MyEventArgs> MyEvent;
        public Smartphone smartphone;

        public Mensch(Smartphone smartphone)
        {
            this.smartphone = smartphone;
        }
        public void Herzinfarkt()
        {
            Console.WriteLine("Fahrer hat Herzinfarkt");
            MyEvent.Invoke(this, new MyEventArgs("Subscriber wird ausgelöst!"));
        }
    }
}
