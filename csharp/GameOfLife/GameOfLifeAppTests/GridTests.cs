using Xunit;
using GameOfLifeApp;

public class GridTests
{
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
    public void NextGeneration_TwoLiveCells_StayAlive()
    {
        // Arrange
        var grid = new Grid(3, 3);
        grid.grid[1, 1] = new LiveCell();
        grid.grid[1, 2] = new LiveCell();

        // Act
        grid.NextGeneration();

        // Assert
        Assert.True(grid.grid[1, 1] is LiveCell);
        Assert.True(grid.grid[1, 2] is LiveCell);
    }

    [Fact]
    public void NextGeneration_ThreeLiveCells_StayAlive()
    {
        // Arrange
        var grid = new Grid(3, 3);
        grid.grid[1, 1] = new LiveCell();
        grid.grid[1, 2] = new LiveCell();
        grid.grid[1, 3] = new LiveCell();

        // Act
        grid.NextGeneration();

        // Assert
        Assert.True(grid.grid[1, 1] is LiveCell);
        Assert.True(grid.grid[1, 2] is LiveCell);
        Assert.True(grid.grid[1, 3] is LiveCell);
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
        Assert.Equal(2, count);
    }
}
