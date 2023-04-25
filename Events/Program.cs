namespace Beispiel.Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Flasche flasche = new Flasche();
            Beutel beutel = new Beutel(flasche);

            Console.WriteLine("ist der Beutel trocken?");
            Console.WriteLine(beutel.GetDry());
            flasche.Auslaufen();
            Console.WriteLine("ist der Beutel trocken?");
            Console.WriteLine(beutel.GetDry());
        }
    }

    class Flasche
    {
        public event EventHandler<MyEventArgs> MyEvent;
        public void Auslaufen()
        {
            Console.WriteLine("Das hier kommt aus Flasche - Die Flasche läuft aus!");
            MyEvent.Invoke(this, new MyEventArgs("Flasche.Auslaufen()", "geplatzt"));
        }
    }
    class Beutel
    {
        private Flasche flasche;
        private bool dry;

        public Beutel(Flasche flasche)
        {
            this.flasche = flasche;
            this.dry = true;
            this.flasche.MyEvent += MakeWet;
        }
        public void MakeWet(object sender, MyEventArgs e)
        {
            Console.WriteLine(e.GetOperation());
            Console.WriteLine(e.GetReason());
            this.dry = false;
        }

        public bool GetDry()
        {
            return this.dry;
        }
    }
    class MyEventArgs : EventArgs
    {
        private string operation;
        private string reason;

        public MyEventArgs(string operation, string reason)
        {
            this.operation = operation;
            this.reason = reason;
        }
        public string GetOperation()
        {
            return this.operation;
        }
        public string GetReason()
        {
            return this.reason;
        }
    }

}