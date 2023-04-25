namespace Beispiel.Event
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Flasche flasche = new Flasche();
            Beutel beutel = new Beutel(flasche);

            Console.WriteLine("ist der Beutel trocken?");
            Console.WriteLine(beutel.GetDry());
            flasche.Auslaufen();
            Console.WriteLine("ist der Beutel trocken?");
            Console.WriteLine(beutel.GetDry());
        }
    }

}