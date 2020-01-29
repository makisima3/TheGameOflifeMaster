using System;

namespace TheGameOfLifeSesson
{
    class GameOfLifeSesson
    {


        private int width;
        private int height;
        public bool[,] grid;
        private bool[,] nextGrid;
        public GameOfLifeSesson(int Height, int Width, bool RandomFill)
        {
            width = Width;
            height = Height;
            if(RandomFill == true)
            {
                grid = Make2DArrayWithRandom(Height, Width);
                nextGrid = Make2DArrayWithRandom(Height, Width);
            }
            else
            {
                grid = Make2DArrayEmpty(Height, Width);
                nextGrid = Make2DArrayEmpty(Height, Width);
            }     
        }

        public bool this[int x, int y]
        {
            get { return grid[x, y]; }
            set { grid[x, y] = value; }
        }

        private void NextGeneration(bool[,] grid, bool[,] nextGrid)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    nextGrid[y, x] = CellProcessing(grid, y, x);
                }
            }
        }

        private bool CellProcessing(bool[,] grid, int y, int x)
        {
            bool isAlive = grid[y, x];
            int neighbors = CountNeighbors(grid, y, x);

            if ((!isAlive && neighbors == 3) || (isAlive && (neighbors == 2 || neighbors == 3)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int CountNeighbors(bool[,] grid, int y, int x)
        {
            int sum = 0;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int col = (x + i + width) % width;
                    int row = (y + j + height) % height;

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

        private bool[,] Make2DArrayWithRandom(int height, int width)
        {
            Random random = new Random();
            bool[,] array = new bool[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (random.Next(0, 2) == 0)
                    {
                        array[y, x] = false;
                    }
                    else
                    {
                        array[y, x] = true;
                    }
                }
            }
            return array;
        }

        private bool[,] Make2DArrayEmpty(int width, int height)
        {
            bool[,] array = new bool[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int g = 0; g < width; g++)
                {
                    array[i, g] = false;
                }
            }
            return array;
        }

        public void CalculateNextGeneration()
        {
            NextGeneration(grid, nextGrid);

            (grid, nextGrid) = (nextGrid, grid);
        }
    }
}
