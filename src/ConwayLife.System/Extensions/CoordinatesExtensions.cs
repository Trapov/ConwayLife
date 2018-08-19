using System.Linq;
using System.Collections.Generic;

namespace ConwayLife.System.Extensions
{
    public static class CoordinatesExtensions 
    {
        public static IEnumerable<Coordinate> Orthogonal(this IEnumerable<Coordinate> coordinates, int maxX, int maxY)
        {
            return coordinates.Select( x => x.ApplyOrthogonality(maxX, maxY));
        }
    }
}