namespace GameOfLifeApp
{
    class Program
    {
        static void Main(string[] args)
        {
			// Taille de la grid
			int rows = 5;
			int cols = 5;
			if (args.Length == 2) {
				rows = int.Parse(args[0]);
				cols = int.Parse(args[1]);
			}

			// Seed de la grid
			Cell[,]? seed = null;
			Console.WriteLine("Select seeding method:");
			Console.WriteLine("1: Random seeding");
			Console.WriteLine("2: Manual seeding");
			Console.WriteLine("3: Parse seeding");
			Console.WriteLine();

			string? seedingMethod = Console.ReadLine();

			switch (seedingMethod) {
				case "":
				case "1":
					break;

				case "2":
					seed = new Cell[rows, cols];
					Console.WriteLine("Enter the initial state of the grid:");
					Console.WriteLine("Use 'X' for live cells and '.' for dead cells");
					Console.WriteLine("Press enter after each row");

					for (int i = 0; i < rows; i++) {
						string? row = Console.ReadLine();
						for (int j = 0; j < cols; j++) {
							if (row[j] == 'X' || row[j] == 'x') {
								// live cell
								seed[i, j] = new LiveCell();
							} else {
								// dead cell
								seed[i, j] = new DeadCell();
							}
						}
					}
					break;

				case "3":
					Console.WriteLine("Enter the seeding map:");
					seed = new Cell[rows, cols];
					string? map = Console.ReadLine();
					if (map == null) {
						throw new Exception("Invalid seeding map");
					}
					// xxxxx/xxxxx/xxxxx/xxxxx/xxxxx
					// for each character in the string create a cell in the grid if it is an 'X' then the cell is alive otherwise it is dead
					// for each '/' create a new row
					int curRow = 0;
					int curCol = 0;
					foreach (char c in map)
					{
						switch (c) {
							case '/':
								// new row
								curCol = 0;
								curRow++;
								break;

							case 'X':
							case 'x':
								// live cell
								seed[curRow, curCol] = new LiveCell();
								curCol++;
								break;

							case '.':
								// dead cell
								seed[curRow, curCol] = new DeadCell();
								curCol++;
								break;

							default:
								throw new Exception("Invalid character in seeding map: " + c);
						}
					};
					break;
			}

			Console.WriteLine("Starting Game of Life with rows: " + rows + " and cols: " + cols);
            var game = new GameOfLife(rows, cols);
			if (seed != null) {
				game.setSeed(seed);
			}
            game.Start();
        }
    }
}
