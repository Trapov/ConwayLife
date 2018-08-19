namespace ConwayLife.System.Extensions
{
    public static class CellsExtensions
    {
        public static Cell[,] MapToArray(this Cell[,] oldCollection)
        {
            for (var y = 0; y < oldCollection.Length/4; y++)
            {
                for (var x = 0; x < oldCollection.Length/4; x++)
                {
                    oldCollection[y,x] = new Cell(oldCollection[y,x].IsAlive, new Coordinate(y,x));
                }
            }

            return oldCollection;
        }
    }
}