using System;

namespace GameOfLifeApp
{
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

        public override string ToString()
        {
            return "X";
        }
    }

    public class DeadCell : Cell
    {
        public override Cell NextGeneration(int nbNeighbours)
        {
            if (nbNeighbours == 3)
            {
                return new LiveCell();
            }
            return new DeadCell();
        }

        public override string ToString()
        {
            return "0";
        }
    }
}
