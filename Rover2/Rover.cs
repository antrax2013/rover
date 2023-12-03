using Rover.Directions;
using Rover;

namespace Vehicule
{
    public sealed class Rover(Coordinate coordinate, IDirection direction)
    {
        public Coordinate Coordinate { get; private set; } = coordinate;
        public IDirection Direction { get; private set; } = direction;

        public void Move() { 
            Coordinate = Direction.Translate(Coordinate);
        }

        public void LeftRotation(IDirection direction)
        {
            if (Direction.Previous != direction.Label)
                throw new InvalidOperationException($"Invalid left rotation : current {direction.Label} - expected { Direction.Previous}");
            Direction = direction;
        }

        public void RightRotation(IDirection direction)
        {
            if (Direction.Next != direction.Label)
                throw new InvalidOperationException($"Invalid right rotation : current {direction.Label} - expected {Direction.Next}");
            Direction = direction;
        }

        public override string ToString()
        {
            return $"{ Coordinate.X } { Coordinate.Y} { Direction.Label}";
        }
    }
}
