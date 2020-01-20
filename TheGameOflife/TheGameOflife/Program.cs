using System;
using System.Threading;

namespace TheGameOfLifeProject
{
    class Program
    {
        public static int gridSize = 20;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            TheGameOfLife tol = new TheGameOfLife(gridSize);

            bool[,] grid;
                      
            while (true)
            { 
                grid = tol.Grid;
                Draw(grid);

                grid = tol.NextGrid;
            }
        }

        public static void Draw(bool[,] grid)
        {
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
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
