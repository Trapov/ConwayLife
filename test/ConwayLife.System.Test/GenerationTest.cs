using Xunit;

namespace ConwayLife.System.Test
{
    public class GenerationTest
    {
        [Fact(DisplayName="Generate new generation with a Blinker")]
        public void Blinker()
        {
            // Arrange & Act

            var seed = new Coordinate?[4,4];

            seed[2,2] = new Coordinate(2,2);
            seed[2,3] = new Coordinate(2,3);
            seed[2,1] = new Coordinate(2,1);

            var world = new World();

            var newGeneration = world.Generation(seed);

            // Assert
            Assert.Null(newGeneration[2,3]);
            Assert.Null(newGeneration[2,1]);

            Assert.NotNull(newGeneration[2,2]);
            Assert.NotNull(newGeneration[3,2]);
            Assert.NotNull(newGeneration[1,2]);
        }
    }
}
