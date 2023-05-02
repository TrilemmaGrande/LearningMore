namespace Aufgabe.Wasserstand
{
    internal class Fluss
    {
        private string name;
        private int wasserstand;
        public event Action WasserstandHoch;
        public event Action WasserstandNiedrig;
        public Fluss(string name)
        {
            this.name = name;
        }
        public void RandomWasserstand()
        {
            Random rand = new Random();
            this.wasserstand = rand.Next(100, 10001);
            Console.WriteLine(this.name + " Wasserstand: " + this.wasserstand);
            if (TestWasserstandHoch())
            {
                WasserstandHoch?.Invoke();
            }
            if (TestWasserstandNiedrig())
            {
                WasserstandNiedrig?.Invoke();
            }
        }
        private bool TestWasserstandHoch()
        {
            if (wasserstand > 8000)
            {
                return true;
            }
            return false;
        }

        private bool TestWasserstandNiedrig()
        {
            if (wasserstand < 250)
            {
                return true;
            }
            return false;
        }
    }
}
