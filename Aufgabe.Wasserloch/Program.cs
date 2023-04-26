namespace Aufgabe.Wasserloch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Waechtertier waechtertier = new Waechtertier();
            Wasserloch wasserloch = new Wasserloch(waechtertier);
            Raubkatze raubkatze = new Raubkatze();
            Fluchttier f1 = new Fluchttier();
            Kampftier k1 = new Kampftier();
            Tarntier t1 = new Tarntier();
            Tarntier t2 = new Tarntier();

            wasserloch.Besuchen(f1);
            wasserloch.Besuchen(k1);
            wasserloch.Besuchen(t1);
            waechtertier.Anmelden(f1);
            waechtertier.Anmelden(k1);
            waechtertier.Anmelden(t1);
            wasserloch.Besuchen(t2);
            wasserloch.Besuchen(raubkatze);          
        }
    }
}