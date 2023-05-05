namespace Aufgabe.SkipAndTake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0, 22, 12, 16, 18, 11, 19, 13 };

            PrintColl(numbers.Take(5));
            PrintColl(numbers.TakeLast(5));
            PrintColl(numbers.Skip(3).SkipLast(3));
            PrintColl(numbers.TakeWhile(n => n != 22));
            PrintColl(numbers.SkipWhile(n => n != 12).Skip(1));

            Console.WriteLine(new String('-', 80));
            Console.WriteLine();
            int itemsPerPage = 5;
            for (int i = 0; i < numbers.Length; i += itemsPerPage)
            {                
                    Console.WriteLine("Page " + ((i / itemsPerPage) + 1) + ":");
                    Console.WriteLine();
                    PrintColl(numbers.Skip(i).SkipLast(numbers.Length - i - itemsPerPage));
                    Console.WriteLine();                
            }
            Console.WriteLine(new String('-', 80));


            static void PrintColl<T>(IEnumerable<T> coll)
            {
                foreach (T item in coll)
                {
                    Console.Write(item);
                    if (!item.GetHashCode().Equals(coll.LastOrDefault()))
                    {
                        Console.Write(", ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}