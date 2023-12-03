namespace Rover.Directions
{
    public sealed class South : IDirection
    {
        public char Label => 'S';

        public char Previous => 'E';
        public char Next => 'W';

        public Coordinate Translate(Coordinate coordinate)
        {
            var Y = coordinate.Y;
            if(Y>0)
                Y--;
            return new Coordinate(coordinate.X, Y);
        }
    }
}
