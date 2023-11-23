namespace Rover.Commands
{
    public interface ICommand
    {
        public static char Value { get; }
        public static void Apply(Vehicule.Rover rover) { }
    }
}
