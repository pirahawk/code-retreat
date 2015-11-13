using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            const int dimension = 3;
            var board = new BoardFactory().CreateBoard(dimension, dimension);

            PrintBoard(board);
        }

        public static void PrintBoard(Board board)
        {
            foreach (var line in board.TableLines)
            {
                var lineJoined = string.Join(", ", line.Select(cell => cell.CellState.ToString()));
                Console.WriteLine(lineJoined);
            }
        }
    }
}
