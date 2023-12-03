using NUnit.Framework;
using Rover.Exceptions;
using Rover.Givens;

namespace Rover.Tests.RoverSimulationFactory.Should
{
    public class RoverSimulationFactoryShould
    {
        [Test]
        public void Creation_GivenCorrectSituationWhenARoverIsAddedThenNoExcpetionFire()
        {
            var simulation = new Rover.RoverSimulationFactory(RoverGivens.TopRigthCorner);
            (var rover, _, _) = RoverGivens.NorthOrientedRoverInBottomLeftCorner();
            Assert.DoesNotThrow(() => simulation.AddRover(rover, "MM"));
        }

        [Test]
        public void Creation_GivenOutOfAreaRoverWhenTheRoverIsAddedThenAInvalidArguementExceptionIsFired()
        {
            var simulation = new Rover.RoverSimulationFactory(RoverGivens.C1x1);
            (var rover, _, _) = RoverGivens.NorthOrientedRoverInTopRightCorner();

            var expectedMessage = $"The rover {rover} is out of the area";

            var exception = Assert.Throws<InvalidArguementException>(() => simulation.AddRover(rover, "MM"));
            Assert.That(exception.Message, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void Creation_GivenBadInstructionsListWhenARoverIsAddedThenExcpetionFire()
        {
            var simulation = new Rover.RoverSimulationFactory(RoverGivens.TopRigthCorner);
            (var rover, _, _) = RoverGivens.NorthOrientedRoverInBottomLeftCorner();
            var expectedMessage = $"The instruction P is not in the authorized instructions list";

            var exception = Assert.Throws<InvalidArguementException>(() => simulation.AddRover(rover, "MP"));

            Assert.That(exception.Message, Is.EqualTo(expectedMessage));
        }

        private static readonly object[] _standardTestCases =
        {
            new object[] { new Vehicule.Rover(new Coordinate(1, 2), RoverGivens.Directions['N']), "LMLMLMLMM", new Coordinate(1,3), 'N' },
            new object[] { new Vehicule.Rover(new Coordinate(3, 3), RoverGivens.Directions['E']), "MMRMMRMRRM", new Coordinate(5,1), 'E'  },
        };

        [TestCaseSource(nameof(_standardTestCases))]
        public void Run_GivenCorrectSituationWhenASimulationRunThenResutls(Vehicule.Rover rover, string instructions, Coordinate expectedCoordinate, char expectionLabelDirection)
        {
            var simulation = new Rover.RoverSimulationFactory(RoverGivens.TopRigthCorner);
            simulation.AddRover(rover, instructions);

            var results = simulation.Run();

            var firstResutl = results[0];

            Assert.Multiple(() =>
            {
                Assert.That(results, Has.Count.EqualTo(1));
                Assert.That(firstResutl.Item1, Is.EqualTo(expectedCoordinate.X.ToString()));
                Assert.That(firstResutl.Item2, Is.EqualTo(expectedCoordinate.Y.ToString()));
                Assert.That(firstResutl.Item3, Is.EqualTo(expectionLabelDirection.ToString()));
            });
        }

        [Test]
        public void Run_GivenCorrectSituationWith2RoversWhenASimulationRunThenResutls()
        {
            var simulation = new Rover.RoverSimulationFactory(RoverGivens.TopRigthCorner);
            simulation.AddRover(new Vehicule.Rover(new Coordinate(1, 2), RoverGivens.Directions['N']), "LMLMLMLMM");
            simulation.AddRover(new Vehicule.Rover(new Coordinate(3, 3), RoverGivens.Directions['E']), "MMRMMRMRRM");

            List<Tuple<string, string, string>> expectedResults = [
                new Tuple<string, string, string>("1", "3", "N"),
                new Tuple<string, string, string>("5", "1", "E"),
            ];

            var results = simulation.Run();

            Assert.Multiple(() =>
            {
                Assert.That(results, Has.Count.EqualTo(2));

                for(var i =0; i < results.Count; i++)
                {
                    Assert.That(results[i], Is.EqualTo(expectedResults[i]));
                }
            });
        }
    }
}
