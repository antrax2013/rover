namespace Rover.Directions
{
    public static class FourCardinalDirections
    {
        public static Dictionary<char, IDirection> Build(Coordinate topRigthCorner) {
            var north = new North(topRigthCorner.Y);
            var west = new West();
            var south = new South();
            var east = new East(topRigthCorner.X);

            return new Dictionary<char, IDirection> {
                { north.Label, north },
                { west.Label, west },
                { south.Label, south },
                { east.Label, east },
            };
        }   
    }
}
