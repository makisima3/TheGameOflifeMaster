using System;

class TheGameOfLife
{
    public bool[,] Grid
    {
        get
        {
            return grid;
        }
    }
    public bool[,] NextGrid
    {
        get
        {
            NextGeneration(grid, nextGrid);
            (grid, nextGrid) = (nextGrid, grid);
            return grid;
        }
    }

    private static int gridSize = 20;
    private bool[,] grid = Make2DArray(gridSize, gridSize);
    private bool[,] nextGrid = Make2DArray(gridSize, gridSize);

    private static void NextGeneration(bool[,] grid, bool[,] nextGrid)
    {
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                nextGrid[i, j] = CellProcessing(grid, i, j);
            }
        }
    }

    private static bool CellProcessing(bool[,] grid, int i, int j)
    {
        bool state = grid[i, j];
        int neighbors = CountNeighbors(grid, i, j);

        if (state == false && neighbors == 3)
        {
            return true;
        }
        else if (state == true && (neighbors < 2 || neighbors > 3))
        {
            return false;
        }
        else
        {
            return state;
        }
    }

    private static int CountNeighbors(bool[,] grid, int x, int y)
    {
        int sum = 0;

        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                int col = (x + i + gridSize) % gridSize;
                int row = (y + j + gridSize) % gridSize;

                if (grid[col, row] == true)
                {
                    sum += 1;
                }
            }
        }

        if (grid[x, y] == true)
        {
            sum -= 1;
        }

        return sum;
    }

    public static bool[,] Make2DArray(int col, int row)
    {
        Random random = new Random();
        bool[,] array = new bool[col, row];

        for (int i = 0; i < col; i++)
        {
            for (int g = 0; g < col; g++)
            {
                if (random.Next(0, 2) == 0)
                {
                    array[i, g] = false;
                }
                else
                {
                    array[i, g] = true;
                }
            }
        }
        return array;
    }

    public static void SetGridSize(int size)
    {
        gridSize = size;
    }

    public TheGameOfLife(int size)
    {
        SetGridSize(size);
    }
}

