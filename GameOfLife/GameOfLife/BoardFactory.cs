using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class BoardFactory
    {
        public Board CreateBoard(int width, int height)
        {
            var tableLines = CreateBoardTableLines(width, height);
            return new Board(tableLines);
        }

        public IEnumerable<IEnumerable<Cell>> CreateBoardTableLines(int width, int height)
        {
            var tablesLines = new List<IEnumerable<Cell>>();

            // Style 2
            for (int i = 0; i < height; i++)
            {
                IEnumerable<Cell> line = CreateLine(width);
                tablesLines.Add(line);
            }

            return tablesLines;


            // Style 1
            //var cells = Enumerable.Range(0, height).Select(x => CreateLine(width));
            //return cells;
        }

        public IEnumerable<Cell> CreateLine(int width)
        {
            return Enumerable.Range(0, width)
                .Select(i => new Cell(CellState.Dead));
            //.Select(i => new Cell(new Random().Next(10) % 2 == 0 ? CellState.Alive : CellState.Dead));
        }
    }
}