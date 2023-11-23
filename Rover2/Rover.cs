using Rover.Orientation;
using Rover;

namespace Vehicule
{
    public sealed class Rover(Coordinate coordinate, IDirection orientation)
    {
        public Coordinate Coordinate { get; private set; } = coordinate;
        public IDirection Orientation { get; private set; } = orientation;

        public void Move() { 
            Coordinate = Orientation.Translate(Coordinate);
        }

        public void LeftRotation(IDirection orientation)
        {
            if (Orientation.Previous != orientation.Value)
                throw new InvalidOperationException($"Invalid left rotation : current {orientation.Value} - expected { Orientation.Previous}");
            Orientation = orientation;
        }

        public void RightRotation(IDirection orientation)
        {
            if (Orientation.Next != orientation.Value)
                throw new InvalidOperationException($"Invalid right rotation : current {orientation.Value} - expected {Orientation.Next}");
            Orientation = orientation;
        }

        public override string ToString()
        {
            return $"{ Coordinate.X } { Coordinate.Y} { Orientation.Value}";
        }
    }
}
