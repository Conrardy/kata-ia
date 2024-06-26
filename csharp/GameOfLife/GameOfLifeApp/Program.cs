namespace GameOfLifeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new GameOfLife(5, 5);
            game.Start();
        }
    }
}
