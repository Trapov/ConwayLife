using System.Linq;
using System.Collections.Generic;

using ConwayLife.System.Extensions;

namespace ConwayLife.System
{
    public class World
    {
        private readonly int _size;

        public World(int size)
        {
            _size = size;
        }

        /// <summary>
        /// Generates a new generation
        /// </summary>
        /// <param name="oldGeneration"></param>
        /// <returns></returns>
        public IEnumerable<Coordinate> Generation(IEnumerable<Coordinate> oldGeneration)
        {
            var allNeighbhours = oldGeneration.SelectMany(cell => cell
               .NeighbourCoordinates
               .Orthogonal(_size, _size)).ToList();

            return allNeighbhours.Where(
                x => allNeighbhours.Count(innerCell => innerCell.Equals(x)) == 3 ||
                (allNeighbhours.Count(innerCell => innerCell.Equals(x)) == 2 && oldGeneration.Contains(x))
            ).Distinct();
        }
    }
}
