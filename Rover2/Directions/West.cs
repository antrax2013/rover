namespace Rover.Directions
{
    public sealed class West() : IDirection
    {
        public char Label => 'W';

        public char Previous => 'S';
        public char Next => 'N';

        public Coordinate Translate(Coordinate coordinate)
        {
            var X = coordinate.X;
            if(X>0)
                X--;
            return new Coordinate(X, coordinate.Y);
        }
    }
}
