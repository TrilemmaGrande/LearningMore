namespace Aufgabe.Wasserloch
{
    class Waechtertier : Tier
    {
        private List<Tier> tiereAngemeldet = new List<Tier>();
        public event EventHandler OnAlarm;

        public void EventAlarm(object sender, EventArgs e)
        {
            Alarm();
            OnAlarm?.Invoke(this, EventArgs.Empty);
        }
        public void Alarm()
        {
            Console.WriteLine("Alarm, Alahaaarm");
        }
        public void Anmelden(Tier tier)
        {
            tiereAngemeldet.Add(tier);
            OnAlarm += tier.ReagiereAufAlarm;
        }
    }
}