using System;
using System.Collections.Generic;

namespace ConwayLife.System
{
    public readonly struct Coordinate
    {
        public int X { get; }
        public int Y { get; }

        public Coordinate(int x, int y) : this()
        {
            X = x;
            Y = y;
        }

        public override string ToString() => $"X: {X} | Y: {Y}";
        
        public IEnumerable<Coordinate> NeighbourCoordinates
        {
            get
            {
                yield return new Coordinate(X-1, Y-1);
                yield return new Coordinate(X, Y-1);
                yield return new Coordinate(X+1, Y-1);
                yield return new Coordinate(X-1, Y);
                yield return new Coordinate(X+1, Y);
                yield return new Coordinate(X-1, Y+1);
                yield return new Coordinate(X, Y+1);
                yield return new Coordinate(X+1, Y+1);
            }
        }

        internal Coordinate ApplyOrthogonality(int maxX, int maxY) 
        {
            return new Coordinate(X>(maxX) ? 0 : (X<0) ? maxX : X, Y>(maxY) ? 0 : (Y<0) ? maxY : Y);
        }
    }
}