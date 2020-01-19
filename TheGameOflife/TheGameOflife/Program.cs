using System;
using System.Threading;

namespace TheGameOfLife
{
    class Program
    {
        public static int gridSize = 20;
        static void Main(string[] args)
        {
            int[,] grid = Make2DArray(gridSize, gridSize);
            int[,] nextGrid = grid;

            NextGeneration(grid, nextGrid);
        }

        public static void NextGeneration(int[,] grid, int[,] nextGrid)
        {
            while (true)
            {
                Draw(grid);

                for (int i = 0; i < gridSize; i++)
                {
                    for (int j = 0; j < gridSize; j++)
                    {
                        int state = grid[i, j];
                        int neighbors = CountNeighbors(grid, i, j);

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

                    grid = nextGrid;
                    Thread.Sleep(1);
                }
            }
        }

        public static void Draw(int[,] grid)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
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
                }

                Console.WriteLine();
            }
        }

        public static int CountNeighbors(int[,] grid, int x, int y)
        {
            int sum = 0;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int col = (x + i + gridSize) % gridSize;
                    int row = (y + j + gridSize) % gridSize;
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
