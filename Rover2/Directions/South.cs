
namespace Rover.Direction
{
    public class South : IDirection
    {
        public char Label => 'S';

        public char Previous => 'W';
        public char Next => 'E';

        public Coordinate Translate(Coordinate coordinate)
        {
            var Y = coordinate.Y;
            if(Y>0)
                Y--;
            return new Coordinate(coordinate.X, Y);
        }
    }
}
