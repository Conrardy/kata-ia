using System;

namespace GameOfLifeApp
{
    public class Grid
    {
        public Cell[,] cells;

        public Grid(int rows, int cols)
        {
            cells = new Cell[rows, cols];

            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    cells[i, j] = new DeadCell();
                }
            }
        }

        public void NextGeneration()
        {
            Cell[,] newGrid = new Cell[cells.GetLength(0), cells.GetLength(1)];

            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    int nbNeighbours = CountNeighbours(i, j);
                    newGrid[i, j] = cells[i, j].NextGeneration(nbNeighbours);
                }
            }

            cells = newGrid;
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
                        && x < cells.GetLength(0)
                        && y >= 0
                        && y < cells.GetLength(1)
                        && !(x == i && y == j)
                    )
                    {
                        if (cells[x, y] is LiveCell)
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
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    Console.Write(cells[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
