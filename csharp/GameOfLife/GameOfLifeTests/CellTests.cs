using GameOfLifeApp;

namespace GameOfLifeTests
{
    public class CellTests
    {
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void AnyLiveCellWithTwoOrThreeLiveNeighboursLivesOnToTheNextGeneration(
            int nbNeighbours
        )
        {
            // Arrange
            Cell cell = new LiveCell();

            // Act
            Cell newCell = cell.NextGeneration(nbNeighbours);

            // Assert
            Assert.IsType<LiveCell>(newCell);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void AnyLiveCellWithFewerThanTwoLiveNeighboursDiesAsIfCausedByUnderpopulation(
            int nbNeighbours
        )
        {
            // Arrange
            Cell cell = new LiveCell();

            // Act
            Cell newCell = cell.NextGeneration(nbNeighbours);

            // Assert
            Assert.IsType<DeadCell>(newCell);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public void AnyLiveCellWithMoreThanThreeLiveNeighboursDiesAsIfByOvercrowding(
            int nbNeighbours
        )
        {
            // Arrange
            Cell cell = new LiveCell();

            // Act
            Cell newCell = cell.NextGeneration(nbNeighbours);

            // Assert
            Assert.IsType<DeadCell>(newCell);
        }

        [Fact]
        public void AnyDeadCellWithExactlyThreeLiveNeighboursBecomesALiveCell()
        {
            // Arrange
            Cell cell = new DeadCell();

            // Act
            Cell newCell = cell.NextGeneration(3);

            // Assert
            Assert.IsType<LiveCell>(newCell);
        }

        [Fact]
        public void DeadCellDisplay0()
        {
            // Arrange
            Cell cell = new DeadCell();

            // Act
            string display = cell.ToString();

            // Assert
            Assert.Equal("0", display);
        }

        [Fact]
        public void LiveCellDisplayX()
        {
            // Arrange
            Cell cell = new LiveCell();

            // Act
            string display = cell.ToString();

            // Assert
            Assert.Equal("X", display);
        }
    }
}