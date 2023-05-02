namespace Aufgabe.Wasserstand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fluss rhein = new Fluss("Rhein");
            Fluss donau = new Fluss("Donau");
            Schiff rheingold = new Schiff("Rheingold");
            Schiff lorelei = new Schiff("Lorelei");
            Schiff xaver = new Schiff("Xaver");
            Schiff franz = new Schiff("Franz");

            rhein.WasserstandNiedrig += rheingold.FahrtGestopptNiedrig;
            rhein.WasserstandHoch += rheingold.FahrtGestopptHoch;
            rhein.WasserstandNiedrig += lorelei.FahrtGestopptNiedrig;
            rhein.WasserstandHoch += lorelei.FahrtGestopptHoch;
            donau.WasserstandNiedrig += xaver.FahrtGestopptNiedrig;
            donau.WasserstandHoch += xaver.FahrtGestopptHoch;
            donau.WasserstandNiedrig += franz.FahrtGestopptNiedrig;
            donau.WasserstandHoch += franz.FahrtGestopptHoch;

            for (int i = 0; i < 10; i++)
            {
                rhein.RandomWasserstand();
                donau.RandomWasserstand();
            }
        }
    }
}