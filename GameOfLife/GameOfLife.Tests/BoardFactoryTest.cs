using System.Linq;
using Xunit;

namespace GameOfLife.Tests
{
    public class BoardFactoryTest
    {
        [Fact]
        public void CreatesRowAsExpected()
        {
            int width = 5;
            int height = 4;

            var board = new BoardFactory().CreateBoard(width, height);
            
            Assert.Equal(board.TableLines.Count(), height);

            foreach (var line in board.TableLines)
            {
                Assert.Equal(line.Count(), width);
            }
        }

        /*[Fact]
        public void CreatesBoardLinesCorrectly()
        {
            const int dimension = 3;
            var rows = new BoardFactory().CreateBoardRows(dimension);
            Assert.Equal(dimension, rows.Count());
            Assert.True();
        }*/
    }
}