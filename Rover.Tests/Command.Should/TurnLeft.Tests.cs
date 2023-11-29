using NUnit.Framework;
using Rover.Commands;
using Rover.Givens;

namespace Rover.Tests.Command.Should
{
    public class TurnLeftCommand
    {
        [Test]
        public void GivenNorthOrientedRoverInBottomLeftCorner_WhenLeftRotationCommandFired_ThenRoverIsTurnedFrontOfWestDirection()
        {
            (var rover, _, _) = RoverGivens.NorthOrientedRoverInBottomLeftCorner();
            var expectedCoodinate = rover.Coordinate;
            var expectedDirection = RoverGivens.Directions['W'];

            var turnLeftRoverCommand = new TurnLeftRoverCommand(RoverGivens.Directions);
            turnLeftRoverCommand.Apply(rover);

            Assert.Multiple(() =>
            {
                Assert.That(turnLeftRoverCommand.Label, Is.EqualTo('L'));
                Assert.That(rover.Direction.Label, Is.EqualTo(expectedDirection.Label));
                Assert.That(rover.Coordinate.X, Is.EqualTo(expectedCoodinate.X));
                Assert.That(rover.Coordinate.Y, Is.EqualTo(expectedCoodinate.Y));
            });
        }

        [Test]
        public void GivenNorthOrientedRoverInBottomLeftCorner_WhenTurnLeftTwice_ThenRoverIsTurnedFrontOfSouthDirection()
        {
            (var rover, _, _) = RoverGivens.NorthOrientedRoverInBottomLeftCorner();
            var expectedCoodinate = rover.Coordinate;
            var expectedDirection = RoverGivens.Directions['S'];

            var turnLeftRoverCommand = new TurnLeftRoverCommand(RoverGivens.Directions);
            turnLeftRoverCommand.Apply(rover);
            turnLeftRoverCommand.Apply(rover);

            Assert.Multiple(() =>
            {
                Assert.That(turnLeftRoverCommand.Label, Is.EqualTo('L'));
                Assert.That(rover.Direction.Label, Is.EqualTo(expectedDirection.Label));
                Assert.That(rover.Coordinate.X, Is.EqualTo(expectedCoodinate.X));
                Assert.That(rover.Coordinate.Y, Is.EqualTo(expectedCoodinate.Y));
            });
        }
    }
}
