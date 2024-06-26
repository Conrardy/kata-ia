namespace GameOfLifeTests
{
    public class CellTests
    {
        [Fact]
        public void AnyLiveCellWithTwoOrThreeLiveNeighboursLivesOnToTheNextGeneration()
        {
            Cell cell = new LiveCell();
            int nbNeighbours = 2;

            Cell newCell = cell.NextGeneration(nbNeighbours);

            Assert.IsType<LiveCell>(newCell);
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
            return null;
        }
    }
}
