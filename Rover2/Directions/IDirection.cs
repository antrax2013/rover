namespace Rover.Orientation
{
    public interface IDirection
    {
        public char Value { get; }
        public char Previous { get; }
        public char Next { get; }

        public Coordinate Translate(Coordinate coordinate);
    }
}
