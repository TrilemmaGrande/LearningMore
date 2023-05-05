using System.Globalization;

namespace Beispiel.SkipAndTake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Enumerable.Range(1, 50).ToArray();

            int pageSize = 8;
            for (int page = 1; page <= Math.Ceiling(numbers.Count() / (decimal) pageSize); page++)
            {
                Console.WriteLine($"Seite {page}:");
                PrintColl(numbers
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize));
            }
            Console.WriteLine(new String('-',80));
            PrintColl(numbers.SkipLast(30));
            PrintColl(numbers.TakeLast(20));
            Console.WriteLine(new String('-', 80));
            PrintColl(numbers.TakeWhile(n => n < 20));
            PrintColl(numbers.SkipWhile(n => n < 20));

            static void PrintColl<T>(IEnumerable<T> coll)
            {
                foreach (T item in coll)
                {
                    Console.Write(item);
                    if (!item.Equals(coll.LastOrDefault()))
                    {
                        Console.Write(", ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}