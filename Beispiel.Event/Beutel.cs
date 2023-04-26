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
        }

        public void EventInitialisieren()
        {
            this.flasche.OnAuslaufen += EventMakeWet;
        }

        public void EventMakeWet(object sender, AuslaufenEventArgs e)
        {
            Console.WriteLine(e.GetOperation());
            Console.WriteLine(e.GetReason());

            MakeWet(e.GetBeispielText());
        }
        public void MakeWet(string text)
        {
            Console.WriteLine(text);
            this.dry = false;
        }

        public bool GetDry()
        {
            return this.dry;
        }
    }

}