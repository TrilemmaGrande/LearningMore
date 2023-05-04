namespace Beispiel.LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Hero> heroes = Hero.GetHeroes(10);

            var xMen = from h in heroes
                       where h.Gang == "X-Men"
                       orderby h.Gang, h.HeroName descending
                       select new { h.HeroName, h.Gang };
            Ausgabe(xMen);

            var avengers = heroes
                .Where(h => h.Gang == "Avengers")
                .OrderByDescending(h => h.Gang)
                .ThenBy(h => h.HeroName)
                .Select(h => new { h.HeroName, h.Gang, h.FirstName, h.LastName });
            Ausgabe(avengers);

            var alle = heroes
                .OrderBy(h => h.Gang)
                .ThenBy(h => h.HeroName)
                .Select(h => new { h.Gang, h.HeroName });
            Ausgabe(alle);

            var ersteDrei = heroes
                .Where((h, i) => i < 3)
                .Select(h => h.HeroName);
            Ausgabe(ersteDrei);

            var buchstaben = heroes
                .Where(h => h.Gang == "X-Men")
                .SelectMany(h => h.HeroName);
            Ausgabe(buchstaben);
        }
        static void Ausgabe<T>(IEnumerable<T> coll)
        {
            foreach (T item in coll)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}