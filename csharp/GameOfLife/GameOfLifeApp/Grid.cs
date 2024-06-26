using System;

namespace GameOfLifeApp
{
    public class Grid
    {
        public Cell[,] grid;

        public Grid(int rows, int cols)
        {
            grid = new Cell[rows, cols];

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = new DeadCell();
                }
            }
        }

        public void NextGeneration()
        {
            Cell[,] newGrid = new Cell[grid.GetLength(0), grid.GetLength(1)];

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    int nbNeighbours = CountNeighbours(i, j);
                    newGrid[i, j] = grid[i, j].NextGeneration(nbNeighbours);
                }
            }

            grid = newGrid;
        }

        public int CountNeighbours(int i, int j)
        {
            int count = 0;

            for (int x = i - 1; x <= i + 1; x++)
            {
                for (int y = j - 1; y <= j + 1; y++)
                {
                    if (
                        x >= 0
                        && x < grid.GetLength(0)
                        && y >= 0
                        && y < grid.GetLength(1)
                        && !(x == i && y == j)
                    )
                    {
                        if (grid[x, y] is LiveCell)
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        public void Print()
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
