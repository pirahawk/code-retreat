using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Board
    {
        private readonly IEnumerable<IEnumerable<Cell>> _cells;

        public Board(IEnumerable<IEnumerable<Cell>> cells)
        {
            if (cells == null) throw new ArgumentNullException("cells");
            _cells = cells;
        }
    }

    public class BoardFactory
    {
        public Board CreateBoard(int dimension)
        {
            var cells = Enumerable.Range(0, dimension).Select(CreateLine);
            return new Board(cells);
        }

        public IEnumerable<Cell> CreateLine(int dimension)
        {
            return Enumerable.Range(0, dimension).Select(i => new Cell(i % 2 == 0 ? CellState.Alive : CellState.Dead));
        }
    }
}