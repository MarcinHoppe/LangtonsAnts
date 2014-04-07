using System;

using Moq;
using Xunit;

namespace MarcinHoppe.LangtonsAnts.Tests
{
    public class AntTests
    {
        [Fact]
        public void AntTurnsRightOnWhiteSquare()
        {
            // Arrange
            var ant = AntAt(10, 7);
            var board = Mock.Of<Board>(b => b.ColorAt(PositionAt(10, 7)) == Colors.White);

            // Act
            ant.MoveOn(board);

            // Assert
            Assert.Equal(PositionAt(10, 8), ant.Position);
        }

        [Fact]
        public void AntTurnsLeftOnBlackSquare()
        {
            // Arrange
            var ant = AntAt(10, 7);
            var board = Mock.Of<Board>(b => b.ColorAt(PositionAt(10, 7)) == Colors.Black);

            // Act
            ant.MoveOn(board);

            // Assert
            Assert.Equal(PositionAt(10, 6), ant.Position);
        }

        private Ant AntAt(int row, int column)
        {
            return new Ant() 
            { 
                Position = new Position { Row = row, Column = column } 
            };
        }

        private Position PositionAt(int row, int column)
        {
            return new Position
            {
                Row = row, Column = column
            };
        }
    }
}
