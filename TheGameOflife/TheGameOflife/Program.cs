using System;
using System.Threading;

namespace TheGameOflife
{
    class Program
    {
        public static int numberOfColAndRow = 30;

        static void Main(string[] args)
        {
            int[,] grid = Make2DArray(numberOfColAndRow, numberOfColAndRow);
            int[,] nextGrid = Make2DArray(numberOfColAndRow, numberOfColAndRow);

            Console.Clear();
            Console.CursorVisible = false;

            while (true)
            {
                Console.SetCursorPosition(0, 0);

                for (int i = 0; i < numberOfColAndRow; i++)
                {
                    for (int j = 0; j < numberOfColAndRow; j++)
                    {
                        if (grid[i, j] == 1)
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

                        int state = grid[i, j];
                        int neighbors = countNeighbors(grid, i, j);

                        if (state == 0 && neighbors == 3)
                        {

                            nextGrid[i, j] = 1;
                        }
                        else if (state == 1 && (neighbors < 2 || neighbors > 3))
                        {
                            nextGrid[i, j] = 0;
                        }
                        else
                        {
                            nextGrid[i, j] = state;
                        }

                    }

                    Console.WriteLine();
                    grid = nextGrid;
                    Thread.Sleep(0);
                }
            }
        }

        public static int countNeighbors(int[,] grid, int x, int y)
        {
            int sum = 0;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int col = (x + i + numberOfColAndRow) % numberOfColAndRow;
                    int row = (y + j + numberOfColAndRow) % numberOfColAndRow;
                    sum += grid[col, row];
                }
            }

            sum -= grid[x, y];
            return sum;
        }

        public static int[,] Make2DArray(int col, int row)
        {
            Random random = new Random();
            int[,] array = new int[col, row];

            for (int i = 0; i < col; i++)
            {
                for (int g = 0; g < col; g++)
                {
                    array[i, g] = random.Next(0, 2);
                }
            }

            return array;
        }
    }
}