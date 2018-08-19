using System.Collections.Generic;

namespace ConwayLife.System
{
    public readonly struct Coordinate
    {
        public int Y { get; }
        public int X { get; }

        public Coordinate(int y, int x) : this()
        {
            X = x;
            Y = y;
        }

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

        internal Coordinate ApplyOrthogonality(int maxY, int maxX) 
        {
            return new Coordinate(Y>(maxY) ? 0 : (Y<0) ? maxY : Y, X > (maxX) ? 0 : (X < 0) ? maxX : X);
        }

        public override string ToString() => $"Y: {Y} | X: {X}";
    }
}