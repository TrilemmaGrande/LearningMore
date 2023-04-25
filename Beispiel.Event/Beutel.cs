namespace Beispiel.Event
{
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

}