namespace Beispiel.Event
{
    class Flasche
    {
        public event EventHandler<MyEventArgs> MyEvent;
        public void Auslaufen()
        {
            Console.WriteLine("Das hier kommt aus Flasche - Die Flasche läuft aus!");
            MyEvent.Invoke(this, new MyEventArgs("Flasche.Auslaufen()", "geplatzt"));
        }
    }

}