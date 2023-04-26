namespace Aufgabe.Wasserloch
{
    class Wasserloch
    {
        private List<Tier> besucher = new List<Tier>();
        private Waechtertier waechtertier;
        public event EventHandler OnRaubkatzeNaehertSich;
        public Wasserloch(Waechtertier waechtertier)
        {
            this.waechtertier = waechtertier;
            OnRaubkatzeNaehertSich += waechtertier.EventAlarm;
        }
        public void Besuchen(Tier tier)
        {
            if (tier.GetType().Name.ToString() != "Raubkatze")
            {
                besucher.Add(tier);
            }
            else
            {
                RaubkatzeNaehertSich();
            }
        }
        private void RaubkatzeNaehertSich()
        {
            OnRaubkatzeNaehertSich?.Invoke(this, EventArgs.Empty);
        }
    }
}