namespace Rover.Commands
{
    public interface IRoverCommand
    {
        public char Label { get; }
        public void Apply(Vehicule.Rover rover);
    }
}
