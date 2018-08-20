using System;
using System.Collections.Generic;

namespace ConwayLife.System
{
    /// <summary>
    /// X and Y
    /// </summary>
    public readonly struct Coordinate : IEquatable<Coordinate>
    {
        public int Y { get; }
        public int X { get; }

        public Coordinate(int y, int x) : this()
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Finds all the neighbours
        ///     <![CDATA[
        ///     * - Neighbour
        ///     0 - Coordinate
        ///     x - __________
        ///
        ///     x x x x
        ///     x * * * 
        ///     x * 0 *
        ///     x * * *
        ///     ]]>
        /// </summary>
        public IEnumerable<Coordinate> NeighbourCoordinates
        {
            get
            {
                yield return new Coordinate(Y-1, X-1);
                yield return new Coordinate(Y-1,   X);
                yield return new Coordinate(Y-1, X+1);
                yield return new Coordinate(Y, X-1);
                yield return new Coordinate(Y, X+1);
                yield return new Coordinate(Y+1, X-1);
                yield return new Coordinate(Y+1, X);
                yield return new Coordinate(Y+1, X+1);
            }
        }

        public override string ToString() => $"Y: {Y} | X: {X}";

        public bool Equals(Coordinate other) => X == other.X && Y == other.Y;
    }
}