using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameOfLife.Tests
{
    public class UnderPopulationRuleTest
    {
        [Fact]
        public void AssertCellDiesWhenLessThan2Neighbours()
        {
            var cell = new Cell(CellState.Alive);

            var dead1 = new Cell(CellState.Dead);
            var dead2 = new Cell(CellState.Dead);
            var alive = new Cell(CellState.Alive);

            var ruleState = new RuleState(cell, new[] { dead1, dead2, alive });


            new UnderPopulationRule().Evaluate(ruleState);

            Assert.Equal(CellState.Dead, cell.CellState);
        }

        [Fact]
        public void CellStateIsAsIsWhenMoreThan2LivingNeighbours()
        {
            var cell = new Cell(CellState.Alive);

            var dead1 = new Cell(CellState.Dead);
            var alive1 = new Cell(CellState.Alive);
            var alive2 = new Cell(CellState.Alive);

            var ruleState = new RuleState(cell, new[] { dead1, alive1, alive2 });


            new UnderPopulationRule().Evaluate(ruleState);

            Assert.Equal(CellState.Alive, cell.CellState);
        }
    }


    public class LivesToNextGenerstionRuleTest
    {
        [Fact]
        public void CellStateLivesOnWithTwoOrThreeLivingNeighbours()
        {
            var cell = new Cell(CellState.Alive);

            var dead1 = new Cell(CellState.Dead);
            var alive1 = new Cell(CellState.Alive);
            var alive2 = new Cell(CellState.Alive);

            var ruleState = new RuleState(cell, new[] { dead1, alive1, alive2 });


            new LivesToNextGenerstionRule().Evaluate(ruleState);

            Assert.Equal(CellState.Alive, cell.CellState);
        }


        [Fact]
        public void DeadCellStateIsStillDeadWithTwoOrThreeLivingNeighbours()
        {
            var cell = new Cell(CellState.Dead);

            var dead1 = new Cell(CellState.Dead);
            var alive1 = new Cell(CellState.Alive);
            var alive2 = new Cell(CellState.Alive);

            var ruleState = new RuleState(cell, new[] { dead1, alive1, alive2 });


            new LivesToNextGenerstionRule().Evaluate(ruleState);

            Assert.Equal(CellState.Dead, cell.CellState);
        }


        [Fact]
        public void CellStateDiesWithLessThanTwoOrThreeLivingNeighbours()
        {
            var cell = new Cell(CellState.Alive);

            var dead1 = new Cell(CellState.Dead);
            var alive1 = new Cell(CellState.Alive);
            var alive2 = new Cell(CellState.Alive);

            var ruleState = new RuleState(cell, new[] { dead1, alive1, alive2 });


            new LivesToNextGenerstionRule().Evaluate(ruleState);

            Assert.Equal(CellState.Alive, cell.CellState);
        }

        [Fact]
        public void LiveCellWithMoreThanThreeLivingNeighboursDies()
        {
            var cell = new Cell(CellState.Alive);

            var dead1 = new Cell(CellState.Dead);
            var alive1 = new Cell(CellState.Alive);
            var alive2 = new Cell(CellState.Alive);
            var alive3 = new Cell(CellState.Alive);
            var alive4 = new Cell(CellState.Alive);

            var ruleState = new RuleState(cell, new[] { dead1, alive1, alive2, alive3, alive4 });


            new DeadTHroughOverpopulationRule().Evaluate(ruleState);

            Assert.Equal(CellState.Dead, cell.CellState);
        }


        [Fact]
        public void DeadCellWithMoreThanThreeLivingNeighboursStaysDead()
        {
            var cell = new Cell(CellState.Dead);

            var dead1 = new Cell(CellState.Dead);
            var alive1 = new Cell(CellState.Alive);
            var alive2 = new Cell(CellState.Alive);
            var alive3 = new Cell(CellState.Alive);
            var alive4 = new Cell(CellState.Alive);

            var ruleState = new RuleState(cell, new[] { dead1, alive1, alive2, alive3, alive4 });


            new DeadTHroughOverpopulationRule().Evaluate(ruleState);

            Assert.Equal(CellState.Dead, cell.CellState);
        }

        [Fact]
        public void DeadCellWithThreeLivingNeighboursComesToLifeThroughReproduction()
        {
            var cell = new Cell(CellState.Dead);

            var dead1 = new Cell(CellState.Dead);
            var alive1 = new Cell(CellState.Alive);
            var alive2 = new Cell(CellState.Alive);
            var alive3 = new Cell(CellState.Alive);
            //var alive4 = new Cell(CellState.Alive);

            var ruleState = new RuleState(cell, new[] { dead1, alive1, alive2, alive3});


            new ReproductionRule().Evaluate(ruleState);

            Assert.Equal(CellState.Alive, cell.CellState);
        }
    }
}
