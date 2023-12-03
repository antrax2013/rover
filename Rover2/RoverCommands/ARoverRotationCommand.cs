using Rover.Commands;
using Rover.Directions;

namespace Rover.RoverCommands
{
    public abstract class ARoverRotationCommand(Dictionary<char, IDirection> directions) : IRoverCommand
    {
        protected readonly Dictionary<char, IDirection> _directions = directions;

        public abstract char Label { get; }

        public abstract void Apply(Vehicule.Rover rover);
    }
}
