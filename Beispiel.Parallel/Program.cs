using System;
using System.Threading;
using System.Threading.Tasks;

namespace Beispiel.Parallels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parallel.Invoke(
                () => Methode1("-"),
                () => Methode1("|"),
                () => Methode1("*"),
                () => Methode1(" "));
        }
        static void Methode1(string s)
        {
            for (int i = 0; i < 500; i++)
            {
                Console.Write(s);
            }
        }
    }
}
