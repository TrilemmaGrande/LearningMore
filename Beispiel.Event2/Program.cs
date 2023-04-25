namespace Beispiel.Event2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    class Flasche
    {
        private Wasser wasser;
        public Flasche(Wasser wasser)
        {
            this.wasser = wasser;
            this.wasser.OnAusdehnung += Wasser_Ausdehnung;
        }

        public void Wasser_Ausdehnung(object sender, EventArgs e)
        {
            this.Platzen();
            this.Auslaufen();
        }
        public void Platzen()
        {
            Console.WriteLine("Die Flasche platzt");
        }
        public void Auslaufen()
        {
            Console.WriteLine("Die Flasche läuft aus");
        }
    }
    class Wasser
    {
        public event EventHandler OnAusdehnung;
        public void Ausdehnen()
        {
            Console.WriteLine("Wasser dehnt sich aus");
            OnAusdehnung?.Invoke(this, new EventArgs());
        }
    }
}