namespace GameOfLife
{
    public class Cell
    {
        public CellState CellState { get; private set; }

        public Cell(CellState cellState)
        {
            CellState = cellState;
        }
    }

    public enum CellState
    {
        Alive,
        Dead
    }
}