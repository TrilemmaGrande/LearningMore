using System;
using System.Threading;

namespace Aufgabe.Traumschiff
{
    internal class Traumschiff
    {
        private static object lockObject = new object();
        public string Name { get; set; }
        public Position Position { get; set; }
        public Traumschiff(string name)
        {
            this.Name = name;
            this.Position = new Position();
            Position.SetRandomPosition(Name);
            ShowShip();
        }
        public void ShowShip()
        {
            lock (lockObject)
            {
                Console.SetCursorPosition(Position.X, Position.Y);
                Console.Write(Name);
            }
        }
        public void MoveAround(object stops)
        {
            for (int i = 0; i < (int)stops; i++)
            {
                bool movingX = true;
                bool movingY = true;
                Position nextPosition = new Position();
                Position ziel = new Position();
                ziel.SetRandomPosition(Name);
                int rangeX;
                int rangeY;
                int stepX = 1;
                int stepY = 1;

                if (Position.X > nextPosition.X)
                {
                    rangeX = Position.X - nextPosition.X;
                }
                else
                {
                    rangeX = nextPosition.X - Position.X;
                }
                if (Position.Y > nextPosition.Y)
                {
                    rangeY = Position.Y - nextPosition.Y;
                }
                else
                {
                    rangeY = nextPosition.Y - Position.Y;
                }
                if (rangeX > rangeY && rangeY != 0)
                {
                    stepX = rangeX / rangeY;
                }
                else if (rangeY > rangeX && rangeX != 0)
                {
                    stepY = rangeY / rangeX;
                }         

                while (movingX || movingY)
                {
                    for (int j = 0; j <= stepX; j++)
                    {
                        DeleteShip(Position, nextPosition);
                        movingX = MoveX(ziel, nextPosition, movingX);
                        Position.X = nextPosition.X;
                        ShowShip();
                        Thread.Sleep(100);
                    }
                    for (int o = 0; o <= stepY; o++)
                    {
                        DeleteShip(Position, nextPosition);
                        movingY = MoveY(ziel, nextPosition, movingY);
                        Position.Y = nextPosition.Y;
                        ShowShip();
                        Thread.Sleep(100);
                    }
                }
            }
        }
        public void DeleteShip(Position Position, Position nextPosition)
        {
            lock (lockObject)
            {
                string space = new String('~', Name.Length);
                Console.SetCursorPosition(Position.X, Position.Y);
                Console.Write(space);
                
            }
        }
        private bool MoveX(Position ziel, Position nextPosition, bool movingX)
        {
            if (Position.X > ziel.X)
            {
                nextPosition.X = Position.X - 1;
                return movingX;
            }
            else if (Position.X < ziel.X)
            {
                nextPosition.X = Position.X + 1;
                return movingX;
            }
            else
            {
                return movingX = false;
            }
        }
        private bool MoveY(Position ziel, Position nextPosition, bool movingY)
        {
            if (Position.Y > ziel.Y)
            {
                nextPosition.Y = Position.Y - 1;
                return movingY;
            }
            else if (Position.Y < ziel.Y)
            {
                nextPosition.Y = Position.Y + 1;
                return movingY;
            }
            else
            {
                return movingY = false;
            }
        }
    }
}
