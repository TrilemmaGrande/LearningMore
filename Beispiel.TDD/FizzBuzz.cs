using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beispiel.TDD
{
    public class FizzBuzz
    {
        public string Play(int number)
        {
            return number switch
            {
                _ when number.IsDivisibleBy(15) => "FizzBuzz",
                _ when number.IsDivisibleBy(3) => "Fizz",
                _ when number.IsDivisibleBy(5) => "Buzz",
                _ => number.ToString()
            };
        }
    }
    public static class IntExtensions
    {
        public static bool IsDivisibleBy(this int i, int divisibly)
        {
            return i % divisibly == 0;
        }
    }
}
