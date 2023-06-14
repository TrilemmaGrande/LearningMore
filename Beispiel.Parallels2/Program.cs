using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Beispiel.Parallels2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            SynchronLoops(100);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            ParallelLoops(100);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
        static void SynchronLoops(int loops)
        {
            double[] arr = new double[loops];
            for (int i = 0; i < loops; i++)
            {
                Thread.Sleep(1);
                arr[i] = Math.Pow(i, 0.333) * Math.Sqrt(Math.Sin(i));
            }
        }
        static void ParallelLoops(int loops)
        {
            double[] arr = new double[loops];
            Parallel.For(0, loops, (i) =>
            {
                Thread.Sleep(1);
                arr[i] = Math.Pow(i, 0.333) * Math.Sqrt(Math.Sin(i));
            });
        }
    }
}
