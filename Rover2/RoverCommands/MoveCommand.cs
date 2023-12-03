

namespace Rover.Commands
{
    public sealed class MoveRoverCommand : IRoverCommand
    {
        private readonly char _label;
        public char Label { get { return _label; } }

        public MoveRoverCommand()
        {
            _label = 'M';
        }

        public void Apply(Vehicule.Rover rover)
        {
            rover.Move();
        }
    }
}
