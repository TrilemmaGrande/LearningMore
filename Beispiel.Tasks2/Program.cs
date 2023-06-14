using System;
using System.Threading.Tasks;

namespace Beispiel.Tasks2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main startet");
            Task<int> t1 = Task.Run(() => Add(21, 21));
            Console.WriteLine(t1.Result);
            Console.WriteLine("Main endet");

            Task<int> t2 = Task.Run(() => Add(21, 21));
            Task<int> t3 = t2.ContinueWith(v => Add(v.Result, v.Result));

            Console.WriteLine(t3.Result);

            Task.Factory.StartNew(() => 21)
                .ContinueWith(v => Add(v.Result, v.Result))
                .ContinueWith(v => Add(v.Result, v.Result))
                .ContinueWith(v => Add(v.Result, v.Result))
                .ContinueWith(v => Add(v.Result, v.Result))
                .ContinueWith(v => Add(v.Result, v.Result))
                .ContinueWith(v => Add(v.Result, v.Result))
                .ContinueWith(v => Add(v.Result, v.Result))
                .ContinueWith(v => Console.WriteLine(v.Result))
                .Wait();

        }
        static int Add(int n1, int n2)
        {
            Console.WriteLine("Addieren startet");
            Task.Delay(500);
            Console.WriteLine("Addieren endet");
            return n1 + n2;
        }
    }
}
