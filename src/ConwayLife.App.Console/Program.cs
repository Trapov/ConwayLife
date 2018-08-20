using ConwayLife.System;

using System;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;
using System.Collections.Generic;

using Output = Colorful.Console;
using System.Threading;

namespace ConwayLife.App.Console
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var sourceToken = new CancellationTokenSource();
            var task = Task.Run(() =>
            {
                var world = new World(3);

                var generation = world.Generation(new List<Coordinate>()
                {
                    new Coordinate(1, 2),
                    new Coordinate(2, 2),
                    new Coordinate(3, 2)
                });

                Task renderTask = Task.CompletedTask;
                while (true)
                {
                    generation = world.Generation(generation);
                    renderTask.GetAwaiter().GetResult();
                    renderTask = Task.Run(() => RenderGrid(4, generation.ToList().AsReadOnly()));
                    Task.Delay(300).GetAwaiter().GetResult();
                }
            }, sourceToken.Token);

            Output.ReadLine();
            sourceToken.Cancel();
            task.GetAwaiter().GetResult();
        }

        public static void RenderGrid(int gridSize, IReadOnlyCollection<Coordinate> coordinates)
        {
            Output.Clear();
            for (var y = 0; y<gridSize; y++)
            {
                for (var x = 0; x < gridSize; x++)
                {
                    if(coordinates.Contains(new Coordinate(y,x)))
                        Output.Write(" * ", Color.ForestGreen);
                    else
                        Output.Write(" x ", Color.Red);
                }
                Output.WriteLine();
            }
        }
    }
}
