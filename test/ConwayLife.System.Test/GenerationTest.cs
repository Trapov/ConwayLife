using System.Collections.Generic;

using Xunit;

namespace ConwayLife.System.Test
{
    public class GenerationTest
    {
        [Fact(DisplayName="New generation with a Blinker")]
        public void Blinker()
        {
            // Arrange & Act

            var seed = new List<Coordinate>
            {

                /*

                    x 0 x
                    x 0 x
                    x 0 x

                */

                new Coordinate(1, 2),
                new Coordinate(2, 2),
                new Coordinate(3, 2)
            };

            var world = new World(3);

            var newGeneration = world.Generation(seed);

            // Assert

            /*

                x x x
                0 0 0
                x x x
             
            */
            Assert.DoesNotContain(newGeneration, x => x.Equals(new Coordinate(1, 2)));
            Assert.DoesNotContain(newGeneration, x => x.Equals(new Coordinate(3, 2)));

            Assert.Contains(newGeneration, x => x.Equals(new Coordinate(2, 2)));
            Assert.Contains(newGeneration, x => x.Equals(new Coordinate(2, 3)));
            Assert.Contains(newGeneration, x => x.Equals(new Coordinate(2, 1)));

            newGeneration = world.Generation(newGeneration);

            /*

                x 0 x
                x 0 x
                x 0 x
             
            */
            Assert.DoesNotContain(newGeneration, x => x.Equals(new Coordinate(2, 3)));
            Assert.DoesNotContain(newGeneration, x => x.Equals(new Coordinate(2, 1)));

            Assert.Contains(newGeneration, x => x.Equals(new Coordinate(1, 2)));
            Assert.Contains(newGeneration, x => x.Equals(new Coordinate(2, 2)));
            Assert.Contains(newGeneration, x => x.Equals(new Coordinate(3, 2)));

            newGeneration = world.Generation(newGeneration);

            /*

                x x x
                0 0 0
                x x x

            */
            Assert.DoesNotContain(newGeneration, x => x.Equals(new Coordinate(1, 2)));
            Assert.DoesNotContain(newGeneration, x => x.Equals(new Coordinate(3, 2)));

            Assert.Contains(newGeneration, x => x.Equals(new Coordinate(2, 2)));
            Assert.Contains(newGeneration, x => x.Equals(new Coordinate(2, 3)));
            Assert.Contains(newGeneration, x => x.Equals(new Coordinate(2, 1)));

            newGeneration = world.Generation(newGeneration);

            /*

                x 0 x
                x 0 x
                x 0 x

            */
            Assert.DoesNotContain(newGeneration, x => x.Equals(new Coordinate(2, 3)));
            Assert.DoesNotContain(newGeneration, x => x.Equals(new Coordinate(2, 1)));

            Assert.Contains(newGeneration, x => x.Equals(new Coordinate(1, 2)));
            Assert.Contains(newGeneration, x => x.Equals(new Coordinate(2, 2)));
            Assert.Contains(newGeneration, x => x.Equals(new Coordinate(3, 2)));

            newGeneration = world.Generation(newGeneration);

            /*

                x x x
                0 0 0
                x x x

            */
            Assert.DoesNotContain(newGeneration, x => x.Equals(new Coordinate(1, 2)));
            Assert.DoesNotContain(newGeneration, x => x.Equals(new Coordinate(3, 2)));

            Assert.Contains(newGeneration, x => x.Equals(new Coordinate(2, 2)));
            Assert.Contains(newGeneration, x => x.Equals(new Coordinate(2, 3)));
            Assert.Contains(newGeneration, x => x.Equals(new Coordinate(2, 1)));
        }

        [Fact(DisplayName = "New generation with a Block")]
        public void Block ()
        {
            // Arrange & Act

            var seed = new List<Coordinate>
            {

                /*

                    0 0 x
                    0 0 x
                    x x x

                */

                new Coordinate(0, 0),
                new Coordinate(0, 1),
                new Coordinate(1, 0),
                new Coordinate(1, 1),
            };

            var world = new World(3);

            var newGeneration = world.Generation(seed);

            // Assert

            /*

                0 0 x
                0 0 x
                x x x
             
            */

            Assert.Contains(newGeneration, x => x.Equals(new Coordinate(0, 0)));
            Assert.Contains(newGeneration, x => x.Equals(new Coordinate(0, 1)));
            Assert.Contains(newGeneration, x => x.Equals(new Coordinate(1, 0)));
            Assert.Contains(newGeneration, x => x.Equals(new Coordinate(1, 1)));

            newGeneration = world.Generation(newGeneration);

            /*
                0 0 x
                0 0 x
                x x x
             
            */
            Assert.Contains(newGeneration, x => x.Equals(new Coordinate(0, 0)));
            Assert.Contains(newGeneration, x => x.Equals(new Coordinate(0, 1)));
            Assert.Contains(newGeneration, x => x.Equals(new Coordinate(1, 0)));
            Assert.Contains(newGeneration, x => x.Equals(new Coordinate(1, 1)));

            newGeneration = world.Generation(newGeneration);

            /*

                0 0 x
                0 0 x
                x x x

            */
            Assert.Contains(newGeneration, x => x.Equals(new Coordinate(0, 0)));
            Assert.Contains(newGeneration, x => x.Equals(new Coordinate(0, 1)));
            Assert.Contains(newGeneration, x => x.Equals(new Coordinate(1, 0)));
            Assert.Contains(newGeneration, x => x.Equals(new Coordinate(1, 1)));
        }
    }
}
