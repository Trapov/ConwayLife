using System.Linq;

using ConwayLife.System.Extensions;

namespace ConwayLife.System
{
    public class World
    {
        public Cell[,] Generation(Cell[,] oldGeneration)
        {
            var size = oldGeneration.Length / (oldGeneration.Rank * 2);
            var newGeneration = new Cell[size, size];
            size -= 1;

            foreach (var cell in oldGeneration)
            {
                var aliveNeighbours = cell
                                    .Coordinate
                                    .NeighbourCoordinates
                                    .Orthogonal(size, size)
                                    .Count(coord => oldGeneration[coord.Y, coord.X].IsAlive);

                if(aliveNeighbours==3 && !cell.IsAlive)
                    newGeneration[cell.Coordinate.Y, cell.Coordinate.X] = new Cell(true, cell.Coordinate);
                else if (aliveNeighbours != 2)
                    newGeneration[cell.Coordinate.Y, cell.Coordinate.X] = new Cell(false, cell.Coordinate);
                else
                    newGeneration[cell.Coordinate.Y, cell.Coordinate.X] = cell;
            }
            return newGeneration;
        }
    }
}
