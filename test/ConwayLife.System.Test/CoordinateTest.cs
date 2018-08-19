using System.Linq;
using System.Collections.Generic;

using Xunit;

using ConwayLife.System.Extensions;

namespace ConwayLife.System.Test
{
    public class CoordinateTest
    {
        [Fact(DisplayName = "Apply Orthogonality [3;3] to [0;0] ")]
        public void Orthonogal_Top_Bottom_()
        {
            // Arrange
            var coordinate = new Coordinate(3,3);

            // Act
            var orthonogalCoordinate = coordinate.ApplyOrthogonality(2, 2);

            // Assert

            Assert.Equal(new Coordinate(0, 0), orthonogalCoordinate);
        }

        [Fact(DisplayName = "Apply Orthogonality [-1;-1] to [2;2] ")]
        public void Orthonogal_Bottom_Top()
        {
            // Arrange
            var coordinate = new Coordinate(-1, -1);

            // Act
            var orthonogalCoordinate = coordinate.ApplyOrthogonality(2, 2);

            // Assert

            Assert.Equal(new Coordinate(2, 2), orthonogalCoordinate);
        }

        [Fact(DisplayName = "Apply Orthogonality [-1;3] to [3;0] ")]
        public void Orthonogal_Bottom_Top_Top_Bottom()
        {
            // Arrange
            var coordinate = new Coordinate(-1, 3);

            // Act
            var orthonogalCoordinate = coordinate.ApplyOrthogonality(2, 2);

            // Assert

            Assert.Equal(new Coordinate(2, 0), orthonogalCoordinate);
        }

        [Fact(DisplayName="Neighbour coordinates of the [2;2]")]
        public void Neighbour_2x2()
        {
            // Arrange & Act
            var neigbours = new Stack<Coordinate>(
                new Coordinate(2, 2)
                    .NeighbourCoordinates
                    .Take(8)
                    .Reverse()
                    .ToList()
            );

            // Assert

            /*
                * - Neighbour
                0 - Coordinate
                x - __________

                x x x x
                x * * *
                x * 0 *
                x * * *
            */

            Assert.Equal(new Coordinate(1, 1), neigbours.Pop());
            Assert.Equal(new Coordinate(1, 2), neigbours.Pop());
            Assert.Equal(new Coordinate(1, 3), neigbours.Pop());
            Assert.Equal(new Coordinate(2, 1), neigbours.Pop());
            Assert.Equal(new Coordinate(2, 3), neigbours.Pop());
            Assert.Equal(new Coordinate(3, 1), neigbours.Pop());
            Assert.Equal(new Coordinate(3, 2), neigbours.Pop());
            Assert.Equal(new Coordinate(3, 3), neigbours.Pop());
        }

        [Fact(DisplayName="Neighbour coordinates of the [0;0]")]
        public void Neighbour_0x0_Orthogonal()
        {
            // Arrange & Act
            var neigbours = new Stack<Coordinate>(
                new Coordinate(0, 0)
                    .NeighbourCoordinates
                    .Orthogonal(maxX: 3, maxY: 3)
                    .Take(8)
                    .Reverse()
                    .ToList()
            );

            // Assert


            /*
                * - Neighbour
                0 - Coordinate
                x - __________
                
                0 * x *
                * * x *
                x x x x
                * * x *
            */

            Assert.Equal(new Coordinate(3, 3), neigbours.Pop());
            Assert.Equal(new Coordinate(3, 0), neigbours.Pop());
            Assert.Equal(new Coordinate(3, 1), neigbours.Pop());
            Assert.Equal(new Coordinate(0, 3), neigbours.Pop());
            Assert.Equal(new Coordinate(0, 1), neigbours.Pop());
            Assert.Equal(new Coordinate(1, 3), neigbours.Pop());
            Assert.Equal(new Coordinate(1, 0), neigbours.Pop());
            Assert.Equal(new Coordinate(1, 1), neigbours.Pop());
        }
    }
}
