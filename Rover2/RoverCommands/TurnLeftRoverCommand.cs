

using Rover.Direction;
using Rover.RoverCommands;

namespace Rover.Commands
{
    public class TurnLeftRoverCommand(Dictionary<char, IDirection> directions) : ARoverRotationCommand(directions)
    {
        public override char Label => 'L';

        public override void Apply(Vehicule.Rover rover)
        {
            rover.LeftRotation(this._directions[rover.Direction.Previous]);
        }
    }
}
