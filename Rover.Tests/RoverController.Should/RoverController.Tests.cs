using NUnit.Framework;
using Rover.Exceptions;
using Rover.Givens;

namespace Rover.Tests.Controller.Should
{
    public class RoverControllerShould
    {
        [Test]
        public void Creation_GivenStartSituationWhenRoverControllerIsConstructedThenRoverControllerIsCorrectlyInitialize() {
            (var expectedRover, var expectedDireection, var expectedCoordinate) = RoverGivens.NorthOrientedRoverInBottomLeftCorner();
            var expectedDirections = RoverGivens.Directions;
            var expectedInstructions = "LMLRRLMMLM";
            var controller = new RoverController(expectedInstructions, expectedRover, expectedDirections);

            Assert.Multiple(() => { 
                Assert.That(controller, Is.Not.Null);
                Assert.That(controller.Instructions, Is.EquivalentTo(expectedInstructions));                
                Assert.That(controller.Rover, Is.EqualTo(expectedRover));
                Assert.That(controller.Directions, Is.EquivalentTo(expectedDirections));

                for (var i = 0; i < controller.Instructions.Count; i++) {
                    Assert.That(controller.Instructions[i], Is.EqualTo(expectedInstructions[i]));
                }
            });
        }

        [Test]
        public void Creation_GivenBadInstructionsListToInitWhenRoverControllerIsConstructedThenInvalidArguementExceptionFired()
        {
            (var rover, _, _) = RoverGivens.NorthOrientedRoverInBottomLeftCorner();
            var directions = RoverGivens.Directions;
            var invalidInstructions = "LMRAM";

            var expectedMessage = $"The instruction A is not in the authorized instructions list";

            var exception = Assert.Throws<InvalidArguementException>(() => new RoverController(invalidInstructions, rover, directions));
            Assert.That(exception.Message, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void Run_GivenStartSituationWhenControllerRunInstructionsThenRoverIsIn1x2EastOriented()
        {
            (var rover, _, _) = RoverGivens.NorthOrientedRoverInBottomLeftCorner();
            var directions = RoverGivens.Directions;
            var instructions = "MMRM";

            var expectedDirection = directions['E'];
            var expectedCoordinate = new Coordinate(1, 2);

            new RoverController(instructions, rover, directions).Run();

            Assert.Multiple(() => {
                Assert.That(rover.Coordinate.X, Is.EqualTo(expectedCoordinate.X));
                Assert.That(rover.Coordinate.Y, Is.EqualTo(expectedCoordinate.Y));
                Assert.That(rover.Direction.Label, Is.EqualTo(expectedDirection.Label));
            });
        }

    }
}
