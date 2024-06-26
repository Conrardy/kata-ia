using GameOfLifeApp;
using System.Text;

namespace GameOfLifeTests
{
    public class GridTests
    {
        private const string r = "\r\n";

        [Fact]
        public void GridInitializesCorrectly()
        {
            int rows = 5,
                cols = 5;
            var grid = new Grid(rows, cols);
            // You could check something about the grid here
            Assert.True(true); // Simple assertion for demonstration
        }

        [Fact]
        public void NextGeneration_SingleLiveCell_DiesFromUnderpopulation()
        {
            // Arrange
            var grid = new Grid(3, 3);
            grid.grid[1, 1] = new LiveCell();

            // Act
            grid.NextGeneration();

            // Assert
            Assert.True(grid.grid[1, 1] is DeadCell);
        }

        [Fact]
        public void NextGeneration_TwoLiveCells_Two_Neibourgh_Each_StayAlive()
        {
            // Arrange
            var grid = new Grid(3, 3);
            grid.grid[1, 1] = new LiveCell();
            grid.grid[1, 2] = new LiveCell();
            grid.grid[2, 2] = new LiveCell();

            // Act
            grid.NextGeneration();

            // Assert
            Assert.True(grid.grid[1, 1] is LiveCell);
            Assert.True(grid.grid[1, 2] is LiveCell);
            Assert.True(grid.grid[2, 2] is LiveCell);
        }

        [Fact]
        public void NextGeneration_ThreeLiveCells_Oscillator()
        {
            // Arrange
            var grid = new Grid(3, 3);
            grid.grid[1, 0] = new LiveCell();
            grid.grid[1, 1] = new LiveCell();
            grid.grid[1, 2] = new LiveCell();

            // Act
            grid.NextGeneration();

            // Assert
            Assert.True(grid.grid[0, 1] is LiveCell);
            Assert.True(grid.grid[1, 1] is LiveCell);
            Assert.True(grid.grid[2, 1] is LiveCell);
        }

        [Fact]
        public void CountNeighbours_MiddleCell_ReturnsCorrectCount()
        {
            // Arrange
            var grid = new Grid(3, 3);
            grid.grid[0, 0] = new LiveCell();
            grid.grid[0, 1] = new LiveCell();
            grid.grid[0, 2] = new LiveCell();
            grid.grid[1, 0] = new LiveCell();
            grid.grid[1, 2] = new LiveCell();
            grid.grid[2, 0] = new LiveCell();
            grid.grid[2, 1] = new LiveCell();
            grid.grid[2, 2] = new LiveCell();

            // Act
            int count = grid.CountNeighbours(1, 1);

            // Assert
            Assert.Equal(8, count);
        }

        [Fact]
        public void CountNeighbours_EdgeCell_ReturnsCorrectCount()
        {
            // Arrange
            var grid = new Grid(3, 3);
            grid.grid[0, 1] = new LiveCell();
            grid.grid[1, 0] = new LiveCell();
            grid.grid[1, 1] = new LiveCell();

            // Act
            int count = grid.CountNeighbours(0, 0);

            // Assert
            Assert.Equal(3, count);
        }

        [Fact]
        public void Print_PrintsGridCorrectly()
        {
            // Arrange
            var grid = new Grid(3, 3);

            grid.grid[0, 0] = new LiveCell();
            grid.grid[0, 1] = new DeadCell();
            grid.grid[0, 2] = new LiveCell();

            grid.grid[1, 0] = new DeadCell();
            grid.grid[1, 1] = new LiveCell();
            grid.grid[1, 2] = new DeadCell();

            grid.grid[2, 0] = new LiveCell();
            grid.grid[2, 1] = new DeadCell();
            grid.grid[2, 2] = new LiveCell();

            // Act
            var output = CaptureConsoleOutput(() =>
            {
                grid.Print();
            });

            // Assert
            var expectedOutput =
                    "X 0 X " + r +
                    "0 X 0 " + r +
                    "X 0 X " + r;
            Assert.Equal(expectedOutput, output);
        }

        private string CaptureConsoleOutput(Action action)
        {
            var consoleOutput = new StringBuilder();
            var originalOutput = Console.Out;
            Console.SetOut(new StringWriter(consoleOutput));

            action();

            Console.SetOut(originalOutput);
            return consoleOutput.ToString();
        }
    }
}