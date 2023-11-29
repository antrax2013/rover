namespace Rover.Should
{
    using NUnit.Framework;
    using Rover.Givens;
    using Rover;

    public class RoverShould
    {
        
        [Test]
        public void ToString_WhenRoverHasFinishedThenItDisplayInformation()
        {
            (var rover, var north, var coordinate) = RoverGivens.NorthOrientedRoverInBottomLeftCorner();

            Assert.That(rover.ToString(), Is.EqualTo(
                $"{ coordinate.X } { coordinate.Y } { north.Label }"));
        }

        [Test]
        public void Creation_WhenRoverIsCreatedWithCoordinatesAndDirectionThenRoverHasCoordinates()
        {
            (var rover, var north, var coordinate) = RoverGivens.NorthOrientedRoverInBottomLeftCorner();

            Assert.That(rover, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(rover.Coordinate, Is.EqualTo(coordinate));
                Assert.That(rover.Direction, Is.EqualTo(north));
            });
        }

        #region Move
        [Test]
        public void Move_WhenNorthOrientedRoverInBottomLeftCornerMovesThenRoverYCoordinateIsIncremented()
        {
            (var rover, _, var coordinate) = RoverGivens.NorthOrientedRoverInBottomLeftCorner();
            ushort Y = coordinate.Y;
            Y++;
            var expectedCoordinate = new Coordinate(coordinate.X, Y);
            
            rover.Move();
            
            Assert.Multiple(() =>
            {
                Assert.That(rover.Coordinate, Is.Not.EqualTo(coordinate));
                Assert.That(rover.Coordinate.X, Is.EqualTo(expectedCoordinate.X));
                Assert.That(rover.Coordinate.Y, Is.EqualTo(expectedCoordinate.Y));
            });
        }

        [Test]
        public void Move_WhenEastOrientedRoverInBottomLeftCornerMovesThenRoverXCoordinateIsIncremented()
        {
            (var rover, _, var coordinate) = RoverGivens.EastOrientedRoverInBottomLeftCorner();
            ushort X = coordinate.X;
            X++;
            var expectedCoordinate = new Coordinate(X, coordinate.Y);

            rover.Move();

            Assert.Multiple(() =>
            {
                Assert.That(rover.Coordinate, Is.Not.EqualTo(coordinate));
                Assert.That(rover.Coordinate.X, Is.EqualTo(expectedCoordinate.X));
                Assert.That(rover.Coordinate.Y, Is.EqualTo(expectedCoordinate.Y));
            });
        }

        [Test]
        public void Move_WhenSouthOrientedRoverInC1x1MovesThenRoverYCoordinateIsDecremented()
        {
            (var rover, _, var coordinate) = RoverGivens.SouthOrientedRoverInC1x1();
            ushort Y = coordinate.Y;
            Y--;
            var expectedCoordinate = new Coordinate(coordinate.X, Y);

            rover.Move();

            Assert.Multiple(() =>
            {
                Assert.That(rover.Coordinate.X, Is.EqualTo(expectedCoordinate.X));
                Assert.That(rover.Coordinate.Y, Is.EqualTo(expectedCoordinate.Y));
            });
        }

        [Test]
        public void Move_WhenWestOrientedRoverInC1x1MovesThenRoverXCoordinateIsDecremented()
        {
            (var rover, _, var coordinate) = RoverGivens.WestOrientedRoverInC1x1();
            ushort X = coordinate.X;
            X--;
            var expectedCoordinate = new Coordinate(X, coordinate.Y);

            rover.Move();

            Assert.Multiple(() =>
            {
                Assert.That(rover.Coordinate.X, Is.EqualTo(expectedCoordinate.X));
                Assert.That(rover.Coordinate.Y, Is.EqualTo(expectedCoordinate.Y));
            });
        }

        [Test]
        public void Move_WhenSouthOrientedRoverInBottomLeftCornerMovesThenRoverYCoordinateIsNotDecremented()
        {
            (var rover, _, var coordinate) = RoverGivens.SouthOrientedRoverInBottomLeftCorner();
            var expectedCoordinate = coordinate;
            
            rover.Move();
            
            Assert.Multiple(() =>
            {
                Assert.That(rover.Coordinate.X, Is.EqualTo(expectedCoordinate.X));
                Assert.That(rover.Coordinate.Y, Is.EqualTo(expectedCoordinate.Y));
            });
        }

        [Test]
        public void Move_WhenEastOrientedRoverMoveThenRoverXCoordinateIsNotDecremented()
        {
            (var rover, _, var coordinate) = RoverGivens.EastOrientedRoverInTopRightCorner();
            var expectedCoordinate = coordinate;

            rover.Move();

            Assert.Multiple(() =>
            {
                Assert.That(rover.Coordinate.X, Is.EqualTo(expectedCoordinate.X));
                Assert.That(rover.Coordinate.Y, Is.EqualTo(expectedCoordinate.Y));
            });
        }

        [Test]
        public void Move_WhenNorthOrientedRoverInTopRightCornerMovesThenRoverYCoordinateIsNotIncremented()
        {
            (var rover, _, var coordinate) = RoverGivens.NorthOrientedRoverInTopRightCorner();
            var expectedCoordinate = coordinate;

            rover.Move();

            Assert.Multiple(() =>
            {
                Assert.That(rover.Coordinate.X, Is.EqualTo(expectedCoordinate.X));
                Assert.That(rover.Coordinate.Y, Is.EqualTo(expectedCoordinate.Y));
            });
        }
        #endregion Moves

        #region Rotates
        [Test]
        public void Rotate_WhenNorthOrientedRoverMakeLeftRotationThenRoverIsWestOriented()
        {
            (var rover, var north, var coordinate) = RoverGivens.NorthOrientedRoverInTopRightCorner();
            var expectedOrientation = RoverGivens.Directions['W'];

            rover.LeftRotation(expectedOrientation);

            Assert.Multiple(() =>
            {
                Assert.That(rover.Coordinate, Is.EqualTo(coordinate));
                Assert.That(rover.Direction, Is.Not.EqualTo(north));
                Assert.That(rover.Direction, Is.EqualTo(expectedOrientation));
            });
        }

        [Test]
        public void Rotate_WhenNorthOrientedRoverMakeBadLeftRotationThenInvalidOperationExceptionFired()
        {
            (var rover, var north, var coordinate) = RoverGivens.NorthOrientedRoverInTopRightCorner();
            var newOrientation = RoverGivens.Directions['S'];

            var exception = Assert.Throws<InvalidOperationException>(() => rover.LeftRotation(newOrientation));


            Assert.Multiple(() =>
            {
                Assert.That(exception.Message, Is.EqualTo($"Invalid left rotation : current {newOrientation.Label} - expected {north.Previous}"));
                Assert.That(rover.Coordinate, Is.EqualTo(coordinate));
                Assert.That(rover.Direction, Is.Not.EqualTo(newOrientation));
                Assert.That(rover.Direction, Is.EqualTo(north));                
            });
        }

        [Test]
        public void Rotate_WhenNorthOrientedRoverMakeBadRighttRotationThenInvalidOperationExceptionFired()
        {
            (var rover, var north, var coordinate) = RoverGivens.NorthOrientedRoverInTopRightCorner();
            var newOrientation = RoverGivens.Directions['S'];

            var exception = Assert.Throws<InvalidOperationException>(() => rover.RightRotation(newOrientation));

            Assert.Multiple(() =>
            {
                Assert.That(exception.Message, Is.EqualTo($"Invalid right rotation : current {newOrientation.Label} - expected {north.Next}"));
                Assert.That(rover.Coordinate, Is.EqualTo(coordinate));
                Assert.That(rover.Direction, Is.Not.EqualTo(newOrientation));
                Assert.That(rover.Direction, Is.EqualTo(north));
            });
        }
        #endregion Rotates
    }
}