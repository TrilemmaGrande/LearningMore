using System;

namespace Beispiel.SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            calc.Add(21);
            calc.Mult(2);

            Console.WriteLine(calc.Value);
        }
    }
}
