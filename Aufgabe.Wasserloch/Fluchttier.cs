namespace Aufgabe.Wasserloch
{
    class Fluchttier : Tier
    {
        public override void ReagiereAufAlarm(object sender, EventArgs e)
        {
            Console.WriteLine(this.GetType().Name + " flieht");
        }
    }
}