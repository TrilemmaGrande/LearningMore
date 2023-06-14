using System;
using System.Threading;
using System.Threading.Tasks;

namespace Beispiel.AsyncAwait
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main starts " + Thread.CurrentThread.ManagedThreadId);
            DoCalculationAsync();
            Console.WriteLine("Main ends " + Thread.CurrentThread.ManagedThreadId);

            Console.ReadKey();
        }
        static async Task DoCalculationAsync()
        {
            Console.WriteLine("    DoCalculation starts " + Thread.CurrentThread.ManagedThreadId);
            Task<int> t1 = Task.Run(() => RandomValue());
            Task<int> t2 = Task.Run(() => RandomValue());

            //Thread.Sleep(2000);

            int result1 = await t1;
            int result2 = await t2;

            Console.WriteLine($"    {result1 + result2}");
            Console.WriteLine("    DoCalculation ends " + Thread.CurrentThread.ManagedThreadId);
        }
        static int RandomValue()
        {
            Console.WriteLine("         RandomValue starts " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
            Console.WriteLine("         RandomValue ends " + Thread.CurrentThread.ManagedThreadId);
            return new Random().Next(1000);
        }
    }
}
