using System;

using Xunit;

namespace MarcinHoppe.LangtonsAnts.Tests
{
    public class DirectionTests
    {
        [Fact]
        public void Construction()
        {
            Assert.IsType<Up>(Direction.Up());
            Assert.IsType<Down>(Direction.Down());
            Assert.IsType<Left>(Direction.Left());
            Assert.IsType<Right>(Direction.Right());
        }

        [Fact]
        public void LeftTurns()
        {
            Assert.IsType<Left>(Direction.Up().TurnLeft());
            Assert.IsType<Right>(Direction.Down().TurnLeft());
            Assert.IsType<Down>(Direction.Left().TurnLeft());
            Assert.IsType<Up>(Direction.Right().TurnLeft());
        }

        [Fact]
        public void RightTurns()
        {
            Assert.IsType<Right>(Direction.Up().TurnRight());
            Assert.IsType<Left>(Direction.Down().TurnRight());
            Assert.IsType<Up>(Direction.Left().TurnRight());
            Assert.IsType<Down>(Direction.Right().TurnRight());
        }

        [Fact]
        public void Translation()
        {
            var position = new Position { Row = 10, Column = 7 };
            Assert.Equal(PositionAt(9, 7), Direction.Up().Translate(position));
            Assert.Equal(PositionAt(11, 7), Direction.Down().Translate(position));
            Assert.Equal(PositionAt(10, 6), Direction.Left().Translate(position));
            Assert.Equal(PositionAt(10, 8), Direction.Right().Translate(position));
        }

        private Position PositionAt(int row, int column)
        {
            return new Position { Row = row, Column = column };
        }
    }
}
