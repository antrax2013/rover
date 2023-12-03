namespace Rover
{
    public sealed class Coordinate(ushort x, ushort y)
    {
        public ushort X { get; private set; } = x;
        public ushort Y { get; private set; } = y;
    }
}
