namespace ConwayLife.System
{
    public readonly struct Cell
    {
        public Cell(bool isAlive, Coordinate coordinate) : this()
        {
            IsAlive = isAlive;
            Coordinate = coordinate;
        }

        public bool IsAlive { get; }
        public Coordinate Coordinate { get; }
    }
}