using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Board
    {
        public IEnumerable<IEnumerable<Cell>> TableLines = new List<IEnumerable<Cell>>();

        public Board(IEnumerable<IEnumerable<Cell>> tableLines)
        {
            if (tableLines == null) 
                throw new ArgumentNullException("cells");
            
            TableLines = tableLines;
        }
    }
}