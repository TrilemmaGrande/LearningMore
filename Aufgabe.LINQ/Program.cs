namespace Aufgabe.LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0, 22, 12, 16, 18, 11, 19, 13 };

            var numbersSmallerSeven = numbers
                .Where(n => n < 7);

            var numbersEven = numbers
                .Where(n => n % 2 == 0);

            var numbersOddSingleDigit = numbers
                .Where(n => n % 2 != 0)
                .Where(n => n < 10);

            var numbersOddAfter6Index = numbers
                .Where((n, i) => i > 6)
                .Where(n => n % 2 == 0);

            var numbersDividableBy2Or3 = numbers
                .Where(n => n % 2 == 0 || n % 3 == 0);

            PrintColl(numbersSmallerSeven);
            PrintColl(numbersEven);
            PrintColl(numbersOddSingleDigit);
            PrintColl(numbersOddAfter6Index);
            PrintColl(numbersDividableBy2Or3);

            string[] words = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen" };

            var words3Chars = words
                .Where(w => w.Length == 3);

            var wordsContainsO = words
                .Where(w => w.ToLower().Contains('o'));

            var wordsEndsWithTeen = words
                .Where(w => w.EndsWith("teen"));

            var wordsEndsWithBigTeen = words
                .Where(w => w.EndsWith("teen"))
                .Select(w => w.ToUpper());

            var wordsContainsFour = words
                .Where(w => w.Contains("four"));

            var wordsNotStartWithTOrF = words
                .Where(w => !w.StartsWith('t') && !w.StartsWith('f'));

            PrintColl(words3Chars);
            PrintColl(wordsContainsO);
            PrintColl(wordsEndsWithTeen);
            PrintColl(wordsEndsWithBigTeen);
            PrintColl(wordsContainsFour);
            PrintColl(wordsNotStartWithTOrF);
        }
        static void PrintColl<T>(IEnumerable<T> coll)
        {
            foreach (var item in coll)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
        }
    }
}