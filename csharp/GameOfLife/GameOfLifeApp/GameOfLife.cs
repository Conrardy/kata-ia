using System;

namespace GameOfLifeApp
{
    public class GameOfLife
    {
        private Grid grid;

        public GameOfLife(int rows, int cols)
        {
            grid = new Grid(rows, cols);
        }

        public void Start()
        {
            grid.Print();
            // Add the logic for the Game of Life rules here
        }
    }
}
