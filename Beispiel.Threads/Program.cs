using System;
using System.Threading;

namespace Beispiel.Threads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(Methode1);
            Thread t2 = new Thread(Methode1);
            Thread t3 = new Thread(Methode1);

            t1.Name = "Thread 1";
            t2.Name = "Thread 2";
            t3.Name = "Thread 3";

            t1.Start(".");
            t2.Start("#");
            t3.Start("|");

            Methode1(" ");
        }
        static void Methode1(object obj)
        {
            Console.Write($"{Thread.CurrentThread.Name}|{Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < 1000; i++)
            {
                Console.Write((string)obj);
            }
        }
    }
}
