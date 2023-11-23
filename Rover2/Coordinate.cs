namespace Rover
{
    public sealed class Coordinate(UInt16 x, UInt16 y)
    {
        public UInt16 X { get; private set; } = x;
        public UInt16 Y { get; private set; } = y;
    }
}
