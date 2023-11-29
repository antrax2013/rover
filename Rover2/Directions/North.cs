
namespace Rover.Direction
{
    public class North (ushort max) : IDirection
    {
        public char Label => 'N';
        private readonly ushort _max = max;

        public char Previous => 'W';
        public char Next => 'E';

        public Coordinate Translate(Coordinate coordinate)
        {
            var Y = coordinate.Y;
            if(Y< _max)
                Y++;
            return new Coordinate(coordinate.X, Y);
        }
    }
}
