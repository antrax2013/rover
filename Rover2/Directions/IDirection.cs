namespace Rover.Directions
{
    public interface IDirection
    {
        public char Label { get; }
        public char Previous { get; }
        public char Next { get; }

        public Coordinate Translate(Coordinate coordinate);
    }
}
