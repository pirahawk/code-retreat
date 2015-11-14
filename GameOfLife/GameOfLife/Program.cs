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
        }
    }


    public class Cell
    {
        public CellState CellState { get; set; }

        public Cell(CellState cellState)
        {
            CellState = cellState;
        }
    }

    public enum CellState
    {
        Dead,
        Alive
    }

    public class UnderPopulationRule
    {
        public void Evaluate(RuleState state)
        {
            //Do evalution
            var countOfLivingNeighbours = state.Neighbours.Count(n => n.CellState == CellState.Alive);

            //Write out the result to the state
            if (countOfLivingNeighbours < 2)
            {
                state.Cell.CellState = CellState.Dead;
            }
            //else
            //{
            //    state.Result = state.Cell.CellState;
            //}
        }
    }

    public class RuleState
    {
        public Cell Cell { get; set; }
        public IEnumerable<Cell> Neighbours { get; set; }
        

        public RuleState(Cell cell, IEnumerable<Cell> neighbours)
        {
            Cell = cell;
            Neighbours = neighbours;
        }
    }

    public class LivesToNextGenerstionRule
    {
        public void Evaluate(RuleState state)
        {
            //Do evalution
            var countOfLivingNeighbours = state.Neighbours.Count(n => n.CellState == CellState.Alive);

            //Write out the result to the state
            if (countOfLivingNeighbours == 2 || countOfLivingNeighbours == 3)
            {
                state.Cell.CellState = state.Cell.CellState;
            }
            //else
            //{
            //    state.Result = state.Cell.CellState;
            //}
        }
    }

    public class DeadTHroughOverpopulationRule
    {
        public void Evaluate(RuleState state)
        {
            //Do evalution
            var countOfLivingNeighbours = state.Neighbours.Count(n => n.CellState == CellState.Alive);

            //Write out the result to the state
            if (countOfLivingNeighbours > 3)
            {
                state.Cell.CellState = CellState.Dead;
            }
            //else
            //{
            //    state.Result = state.Cell.CellState;
            //}
        }
    }

    public class ReproductionRule
    {
        public void Evaluate(RuleState state)
        {
            //Do evalution
            var countOfLivingNeighbours = state.Neighbours.Count(n => n.CellState == CellState.Alive);

            //Write out the result to the state
            if (countOfLivingNeighbours == 3)
            {
                state.Cell.CellState = CellState.Alive;
            }
            //else
            //{
            //    state.Result = state.Cell.CellState;
            //}
        }
    }

    public class CellStateCalculator
    {
        public void CalculateCellState(RuleState state)
        {
            new UnderPopulationRule().Evaluate(state);
            new LivesToNextGenerstionRule().Evaluate(state);
            new DeadTHroughOverpopulationRule().Evaluate(state);
            new ReproductionRule().Evaluate(state);
        }
    }
}
