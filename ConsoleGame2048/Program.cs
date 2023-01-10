using System;

namespace ConsoleGame2048
{
    class Program
    {
        public static void Main()
        {
            Grid grid = new Grid();
            grid.CreateGrid();
            while (true)
            {
                Console.WriteLine(grid.ReturnGrid());
                var move = Console.ReadKey();
                if (move.Key == ConsoleKey.D)
                {
                    Console.Clear();
                    grid.MoveCharactersToRight();
                }

                if (move.Key == ConsoleKey.A)
                {
                    Console.Clear();
                    grid.MoveCharactersToLeft();
                }

                if (move.Key == ConsoleKey.W)
                {
                    Console.Clear();
                    grid.MoveCharactersToUpAndDown("Up");
                }

                if (move.Key == ConsoleKey.S)
                {
                    Console.Clear();
                    grid.MoveCharactersToUpAndDown("Down");
                }
            }
        }
    }
}