using Rover.Directions;
using Rover.Exceptions;

namespace Rover
{
    public sealed class RoverSimulationFactory(Coordinate topRightCorner)
    {
        private readonly Coordinate _topRightCorner = topRightCorner;
        private readonly Dictionary<char, IDirection> _directions = FourCardinalDirections.Build(topRightCorner);
        private readonly List<RoverController> _roverControllers = [];

        public void AddRover(Vehicule.Rover rover, string instructions) {
            if (!IsValid(rover)) {
                throw new InvalidArguementException($"The rover {rover} is out of the area");
            }
            _roverControllers.Add(new RoverController(instructions, rover, _directions));
        }
            
        private bool IsValid(Vehicule.Rover rover) {
            return rover.Coordinate.X < _topRightCorner.X && rover.Coordinate.Y < _topRightCorner.Y;
        }

        public List<Tuple<string, string, string>> Run() {

            List<Tuple<string, string, string>> results = [];
            
            foreach (var item in _roverControllers)
            {
                item.Run();
                results.Add(new Tuple<string,string,string>(item.Rover.Coordinate.X.ToString(), item.Rover.Coordinate.Y.ToString(), item.Rover.Direction.Label.ToString()));
            }
            return results;
        }
    }
}
