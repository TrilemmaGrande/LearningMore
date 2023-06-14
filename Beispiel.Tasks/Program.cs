using System;
using System.Threading;
using System.Threading.Tasks;

namespace Beispiel.Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Task über Konstruktor erstellen (muss gestartet werden)
            Task t1 = new Task(() => { Methode1("Task 1"); });
            t1.Start();

            // Task über statische Methode erstellen (startet automatisch)
            Task t2 = Task.Run(() => { Methode1("Task2"); });

            // Task über Factory erstellen (startet automatisch)
            Task t3 = Task.Factory.StartNew(() => { Methode1("Task 3"); });

            Console.WriteLine("Main Methode");
            //t1.Wait();
            //t2.Wait();
            //t3.Wait();
            Task.WaitAll(t1, t2, t3);
        }
        static void Methode1(string name)
        {
            Thread.Sleep(50);
            Console.WriteLine(name);
        }
    }
}
