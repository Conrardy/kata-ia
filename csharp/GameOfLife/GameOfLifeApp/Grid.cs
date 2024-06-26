using System;

namespace GameOfLifeApp
{
    public class Grid
    {
        private Cell[,] grid;

        public Grid(int rows, int cols)
        {
            grid = new Cell[rows, cols];
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
