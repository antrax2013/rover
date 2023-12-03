namespace Rover.Directions
{
    public sealed class East(ushort max) : IDirection
    {
        public char Label => 'E';
        private readonly ushort _max = max;

        public char Previous => 'N';
        public char Next => 'S';

        public Coordinate Translate(Coordinate coordinate)
        {
            var X = coordinate.X;
            if (X < _max)
                X++;
            return new Coordinate(X, coordinate.Y);
        }
    }
}
