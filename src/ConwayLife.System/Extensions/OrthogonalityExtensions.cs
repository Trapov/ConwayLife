using System.Linq;
using System.Collections.Generic;

namespace ConwayLife.System.Extensions
{
    public static class OrthogonalityExtensions
    {
        /// <summary>
        /// Applies orthogonality to the given collection of coordinates.
        /// </summary>
        /// <param name="coordinates">The coordinates to which apply the orthogonality function.</param>
        /// <param name="maxY">Maximum value of Y</param>
        /// <param name="maxX">Maximum value of X</param>
        /// <returns></returns>
        public static IEnumerable<Coordinate> Orthogonal(this IEnumerable<Coordinate> coordinates, int maxY, int maxX)
        {
            return coordinates.Select( x => x.ApplyOrthogonality(maxY, maxX));
        }

        /// <summary>
        /// Applies orthogonality to the given coordinate.
        /// </summary>
        /// <param name="coordinate">The coordinate to which apply the orthogonality function.</param>
        /// <param name="maxY">Maximum value of Y</param>
        /// <param name="maxX">Maximum value of X</param>
        /// <returns></returns>
        internal static Coordinate ApplyOrthogonality(this Coordinate coordinate, int maxY, int maxX)
        {
            return new Coordinate(
                coordinate.Y > (maxY) ? 0 : 
                    (coordinate.Y < 0) ? maxY : coordinate.Y,
                coordinate.X > (maxX) ? 0 : 
                    (coordinate.X < 0) ? maxX : coordinate.X
            );
        }
    }
}