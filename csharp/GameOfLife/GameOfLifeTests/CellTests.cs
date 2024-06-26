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
    }

    public abstract class Cell
    {
        public virtual Cell NextGeneration(int nbNeighbours)
        {
            return null;
        }
    }

    public class LiveCell : Cell
    {
        public override Cell NextGeneration(int nbNeighbours)
        {
            if (nbNeighbours == 2 || nbNeighbours == 3)
            {
                return new LiveCell();
            }
            return new DeadCell();
        }
    }

    public class DeadCell : Cell { }
}
