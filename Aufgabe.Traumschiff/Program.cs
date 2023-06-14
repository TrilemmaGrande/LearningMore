using System;
using System.Threading;

namespace Aufgabe.Traumschiff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Read();
            Console.CursorVisible = false;
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                for (int j = 0; j < Console.WindowHeight; j++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write('~');
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Traumschiff ts1 = new Traumschiff("\\___/", ConsoleColor.Red);
            Traumschiff ts2 = new Traumschiff("\\___/", ConsoleColor.Blue);
            Traumschiff ts3 = new Traumschiff("\\___/", ConsoleColor.Green);
            Thread thread1 = new Thread(ts1.MoveAround);
            Thread thread2 = new Thread(ts2.MoveAround);
            Thread thread3 = new Thread(ts3.MoveAround);
            thread1.Start(10);
            thread2.Start(10);
            thread3.Start(10);
        }
    }
}
