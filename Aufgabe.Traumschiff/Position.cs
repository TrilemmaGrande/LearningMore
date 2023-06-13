using System;

namespace Aufgabe.Traumschiff
{
    internal class Position
    {
        private Random rnd = new Random();
        public int X { get; set; }
        public int Y { get; set; }
        public void SetRandomPosition(string shipName)
        {
            X = rnd.Next(Console.WindowWidth - (shipName.Length + 1));
            Y = rnd.Next(Console.WindowHeight - 1);
        }
    }
}
