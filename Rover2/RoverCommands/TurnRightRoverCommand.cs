using Rover.Directions;
using Rover.RoverCommands;

namespace Rover.Commands
{
    public sealed class TurnRightRoverCommand(Dictionary<char, IDirection> directions) : ARoverRotationCommand(directions)
    {
        public override char Label => 'R';

        public override void Apply(Vehicule.Rover rover)
        {
            rover.RightRotation(this._directions[rover.Direction.Next]);
        }
    }
}
