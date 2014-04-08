using System;
using System.Linq;

using Moq;
using Xunit;

namespace MarcinHoppe.LangtonsAnts.Tests
{
    public class SimulationTests
    {
        [Fact]
        public void SimulationReadsBoardCenterAtStart()
        {
            // Arrange
            var mock = new Mock<Board>();
            mock.Setup(b => b.Center).Returns(Position.At(10, 7));
                        
            // Act 
            var simulation = new Simulation(mock.Object);

            // Assert
            mock.VerifyGet(b => b.Center);
        }

        [Fact]
        public void SimulationDoesNothingIfAntNotOnBoard()
        {
            // Arrange
            var outsideOfTheBoard = Position.At(10, 7);
            var mock = new Mock<Board>(MockBehavior.Strict);
            mock.Setup(b => b.Center).Returns(outsideOfTheBoard);
            mock.Setup(b => b.Contains(outsideOfTheBoard)).Returns(false);

            // Act 
            var simulation = new Simulation(mock.Object);
            simulation.MakeStep();

            // Assert
            mock.VerifyAll();
        }

        [Fact]
        public void SimulationFlipsColorAtAntPositionIfAntOnBoard()
        {
            // Arrange
            var antPosition = Position.At(10, 7);
            var mock = new Mock<Board>();
            mock.Setup(b => b.Center).Returns(antPosition);
            mock.Setup(b => b.Contains(antPosition)).Returns(true);
            mock.Setup(b => b.FlipColorAt(antPosition));

            // Act 
            var simulation = new Simulation(mock.Object);
            simulation.MakeStep();

            // Assert
            mock.Verify(b => b.FlipColorAt(antPosition));
        }

        [Fact]
        public void SimulationFlipsColorAtAllPositionsVisitedByAnt()
        {
            // Arrange
            Position[] antPositions = new Position[] 
            {
                Position.At(10, 7),
                Position.At(10, 8),
                Position.At(11, 8)
            };
            var mock = new Mock<Board>();
            mock.Setup(b => b.Center).Returns(antPositions.First());
            mock.Setup(b => b.Contains(It.IsAny<Position>())).Returns(true);
            mock.Setup(b => b.ColorAt(It.IsAny<Position>())).Returns(Colors.White);

            // Act
            var simulation = new Simulation(mock.Object);
            simulation.MakeStep();
            simulation.MakeStep();
            simulation.MakeStep();

            // Assert
            mock.Verify(b => b.FlipColorAt(antPositions[0]), Times.Once());
            mock.Verify(b => b.FlipColorAt(antPositions[1]), Times.Once());
            mock.Verify(b => b.FlipColorAt(antPositions[2]), Times.Once());
        }
    }
}
