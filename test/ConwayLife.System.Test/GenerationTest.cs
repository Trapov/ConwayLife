using Xunit;

using ConwayLife.System.Extensions;

namespace ConwayLife.System.Test
{
    public class GenerationTest
    {
        [Fact(DisplayName="Generate new generation with a Blinker")]
        public void Blinker()
        {
            // Arrange & Act

            var seed = new Cell[4,4];

            /*

                x 0 x
                x 0 x
                x 0 x
             
            */

            seed[1,2] = new Cell(true, new Coordinate(1,2));
            seed[2,2] = new Cell(true, new Coordinate(2,2));
            seed[3,2] = new Cell(true, new Coordinate(3,2));

            var world = new World();

            var newGeneration = world.Generation(seed.MapToArray());

            // Assert

            /*

                x x x
                0 0 0
                x x x
             
            */
            Assert.False(newGeneration[1,2].IsAlive);
            Assert.False(newGeneration[3,2].IsAlive);

            Assert.True(newGeneration[2,2].IsAlive);
            Assert.True(newGeneration[2,3].IsAlive);
            Assert.True(newGeneration[2,1].IsAlive);

            newGeneration = world.Generation(newGeneration);

            /*

                x 0 x
                x 0 x
                x 0 x
             
            */
            Assert.False(newGeneration[2, 3].IsAlive);
            Assert.False(newGeneration[2, 1].IsAlive);

            Assert.True(newGeneration[1, 2].IsAlive);
            Assert.True(newGeneration[2, 2].IsAlive);
            Assert.True(newGeneration[3, 2].IsAlive);

            newGeneration = world.Generation(seed.MapToArray());

            /*

                x x x
                0 0 0
                x x x

            */
            Assert.False(newGeneration[1, 2].IsAlive);
            Assert.False(newGeneration[3, 2].IsAlive);

            Assert.True(newGeneration[2, 2].IsAlive);
            Assert.True(newGeneration[2, 3].IsAlive);
            Assert.True(newGeneration[2, 1].IsAlive);
        }
    }
}
