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

		public void setSeed(Cell[,] seed)  {
			this.grid.cells = seed;
		}

        public void Start()
        {
			run();
        }

		public void run()
		{
			while (true)
            {
                Console.Clear();
                grid.Print();
                grid.NextGeneration();
                System.Threading.Thread.Sleep(1000);
            }
            // Add the logic for the Game of Life rules here
		}
    }
}
