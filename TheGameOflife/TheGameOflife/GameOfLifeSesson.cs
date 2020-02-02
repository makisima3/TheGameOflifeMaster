using System;

namespace GameOfLife
{
    class GameOfLifeSession
    {
        private bool[,] grid;
        private bool[,] nextGrid;

        public int Width { get; set; }

        public int Height { get; set; }

        public GameOfLifeSession(int height, int width)
        {
            Width = width;
            Height = height;

            grid = MakeEmptyGrid();
            nextGrid = MakeEmptyGrid();
        }

        public void CalculateNextGeneration()
        {
            NextGeneration();

            (grid, nextGrid) = (nextGrid, grid);
        }

        private void NextGeneration()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    nextGrid[y, x] = CellProcessing(y, x);
                }
            }
        }

        private bool CellProcessing(int y, int x)
        {
            bool isAlive = grid[y, x];
            int neighbors = CountNeighbors(y, x);

            if ((!isAlive && neighbors == 3) || (isAlive && (neighbors == 2 || neighbors == 3)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int CountNeighbors(int y, int x)
        {
            int sum = 0;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int col = (x + i + Width) % Width;
                    int row = (y + j + Height) % Height;

                    if (grid[row, col] == true)
                    {
                        sum += 1;
                    }
                }
            }

            if (grid[y, x] == true)
            {
                sum -= 1;
            }

            return sum;
        }

        private bool[,] MakeEmptyGrid()
        {
            bool[,] array = new bool[Height, Width];

            for (int i = 0; i < Height; i++)
            {
                for (int g = 0; g < Width; g++)
                {
                    array[i, g] = false;
                }
            }
            return array;
        }

        public bool this[int x, int y]
        {
            get => grid[x, y];
            set => grid[x, y] = value;
        }
    }
}
