using NUnit.Framework;
using Rover.Commands;
using Rover.Givens;

namespace Rover.Tests.Command.Should
{
    internal class Move
    {
        [Test]
        public void GivenNorthOrientedRoverInBottomLeftCorner_WhenMoveCommandFired_ThenRoverMoveTo0x1()
        {
            (var rover, _, _) = RoverGivens.NorthOrientedRoverInBottomLeftCorner();
            var expectedCoodinate = new Coordinate(rover.Coordinate.X, Convert.ToUInt16(rover.Coordinate.Y + 1));
            var expectedDirection = rover.Direction;

            var moveRoverCommand = new MoveRoverCommand();
            moveRoverCommand.Apply(rover);

            Assert.Multiple(() =>
            {
                Assert.That(moveRoverCommand.Label, Is.EqualTo('M'));
                Assert.That(rover.Direction.Label, Is.EqualTo(expectedDirection.Label));
                Assert.That(rover.Coordinate.X, Is.EqualTo(expectedCoodinate.X));
                Assert.That(rover.Coordinate.Y, Is.EqualTo(expectedCoodinate.Y));
            });
        }

        [Test]
        public void GivenNorthOrientedRoverInTopRightCorner_WhenMoveCommandFired_ThenRoverNotMoved()
        {
            (var rover, _, _) = RoverGivens.NorthOrientedRoverInTopRightCorner();
            var expectedCoodinate = new Coordinate(rover.Coordinate.X, Convert.ToUInt16(rover.Coordinate.Y));
            var expectedDirection = rover.Direction;

            var moveRoverCommand = new MoveRoverCommand();
            moveRoverCommand.Apply(rover);

            Assert.Multiple(() =>
            {
                Assert.That(moveRoverCommand.Label, Is.EqualTo('M'));
                Assert.That(rover.Direction.Label, Is.EqualTo(expectedDirection.Label));
                Assert.That(rover.Coordinate.X, Is.EqualTo(expectedCoodinate.X));
                Assert.That(rover.Coordinate.Y, Is.EqualTo(expectedCoodinate.Y));
            });
        }
    }
}
