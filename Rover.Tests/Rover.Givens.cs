using Rover.Direction;

namespace Rover.Givens
{
    public class RoverGivens
    {
        public static readonly Coordinate TopRigthCorner = new(5, 5);
        public static readonly Coordinate Origin = new(0, 0);
        public static readonly Coordinate C1x1 = new(1, 1);

        public static readonly Dictionary<char, IDirection> Directions;

        static RoverGivens()
        {
            var north = new North(TopRigthCorner.Y);
            var west = new West();
            var south = new South();
            var east = new East(TopRigthCorner.X);

            Directions = new Dictionary<char, IDirection> {
                { north.Label, north },
                { west.Label, west },
                { south.Label, south },
                { east.Label, east },
            };
        }

        public static (Vehicule.Rover, IDirection, Coordinate) NorthOrientedRoverInBottomLeftCorner()
        {
            var coordinate = Origin;
            var north = Directions['N'];
            var rover = new Vehicule.Rover(coordinate, north);

            return (rover, north, coordinate);
        }

        public static (Vehicule.Rover, IDirection, Coordinate) NorthOrientedRoverInTopRightCorner()
        {
            var coordinate = TopRigthCorner;
            var north = Directions['N'];
            var rover = new Vehicule.Rover(coordinate, north);

            return (rover, north, coordinate);
        }

        public static (Vehicule.Rover, IDirection, Coordinate) WestOrientedRoverInBottomLeftCorner()
        {
            var coordinate = Origin;
            var west = Directions['W'];
            var rover = new Vehicule.Rover(coordinate, west);

            return (rover, west, coordinate);
        }

        public static (Vehicule.Rover, IDirection, Coordinate) WestOrientedRoverInC1x1()
        {
            var coordinate = C1x1;
            var west = Directions['W'];
            var rover = new Vehicule.Rover(coordinate, west);

            return (rover, west, coordinate);
        }

        public static (Vehicule.Rover, IDirection, Coordinate) SouthOrientedRoverInBottomLeftCorner()
        {
            var coordinate = Origin;
            var south = Directions['S'];
            var rover = new Vehicule.Rover(coordinate, south);

            return (rover, south, coordinate);
        }

        public static (Vehicule.Rover, IDirection, Coordinate) SouthOrientedRoverInC1x1()
        {
            var coordinate = C1x1;
            var south = Directions['S'];
            var rover = new Vehicule.Rover(coordinate, south);

            return (rover, south, coordinate);
        }

        public static (Vehicule.Rover, IDirection, Coordinate) EastOrientedRoverInBottomLeftCorner()
        {
            var coordinate = Origin;
            var east = Directions['E'];
            var rover = new Vehicule.Rover(coordinate, east);

            return (rover, east, coordinate);
        }

        public static (Vehicule.Rover, IDirection, Coordinate) EastOrientedRoverInTopRightCorner()
        {
            var coordinate = TopRigthCorner;
            var east = Directions['E'];
            var rover = new Vehicule.Rover(coordinate, east);

            return (rover, east, coordinate);
        }
    }
}
