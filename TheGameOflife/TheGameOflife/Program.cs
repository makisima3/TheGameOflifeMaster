using System;
using System.Threading;

namespace TheGameOfLifeSesson
{
    class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                Console.CursorVisible = false;

                GameOfLifeSesson session = new GameOfLifeSesson(50, 50, true);

                Console.ReadKey();

                while (true)
                {
                    Draw(session.grid);
                    session.CalculateNextGeneration();
                }
            }
        }

        public static void Draw(bool[,] grid)
        {
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("■■ ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("■■ ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
