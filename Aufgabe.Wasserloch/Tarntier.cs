namespace Aufgabe.Wasserloch
{
    class Tarntier : Tier
    {
        public override void ReagiereAufAlarm(object sender, EventArgs e)
        {
            Console.WriteLine(this.GetType().Name + " versteckt sich");
        }
    }
}