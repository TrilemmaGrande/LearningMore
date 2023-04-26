namespace Aufgabe.Wasserloch
{
    class Kampftier : Tier
    {
        public override void ReagiereAufAlarm(object sender, EventArgs e)
        {
            Console.WriteLine(this.GetType().Name + " formiert sich zum Kampf");
        }
    }
}