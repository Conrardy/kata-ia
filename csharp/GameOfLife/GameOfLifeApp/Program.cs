namespace GameOfLifeApp
{
    class Program
    {
        static void Main(string[] args)
        {
			int rows = 5;
			int cols = 5;

			if (args.Length == 2) {
				rows = int.Parse(args[0]);
				cols = int.Parse(args[1]);
			}

			Console.WriteLine("Starting Game of Life with rows: " + rows + " and cols: " + cols);
            var game = new GameOfLife(rows, cols);
			Console.ReadLine();
            game.Start();
        }
    }
}
