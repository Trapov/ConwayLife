using ConwayLife.System;

using System;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

using Output = Colorful.Console;
using System.Threading;

namespace ConwayLife.App.Console
{
    public static class Program
    {
        private static readonly RenderQueue RenderQueue = new RenderQueue();

        public static void Main()
        {
            var sourceToken = new CancellationTokenSource();
            Task.Run(() =>
            {
                var world = new World(9);

                var generation = world.Generation(new List<Coordinate>()
                {
                    new Coordinate(1, 2),
                    new Coordinate(2, 2),
                    new Coordinate(3, 2),

                    new Coordinate(4, 5),
                    new Coordinate(5, 5),
                    new Coordinate(6, 5),

                    new Coordinate(0, 6),
                    new Coordinate(0, 7),
                    new Coordinate(1, 6),
                    new Coordinate(1, 7),

                }).ToList().AsReadOnly();

                while (!sourceToken.IsCancellationRequested)
                {
                    if (RenderQueue.Count > 25) continue;

                    generation = world.Generation(generation).ToList().AsReadOnly();
                    RenderQueue.Add(() => RenderGrid(9, generation), sourceToken.Token);
                }
            }, sourceToken.Token);

            RenderQueue.RenderAsync(sourceToken.Token, TimeSpan.FromMilliseconds(360));

            Output.ReadLine();
            sourceToken.Cancel();
        }

        private static int GetWorkingThreads()
        {
            ThreadPool.GetMaxThreads(out var maxThreads, out _);

            ThreadPool.GetAvailableThreads(out var availableThreads, out _);

            return maxThreads - availableThreads;
        }

        private static void RenderGrid(int gridSize, IReadOnlyCollection<Coordinate> coordinates)
        {
            Output.Clear();

            Output.WriteLine(" ProcessName: " + Process.GetCurrentProcess()
                .ProcessName, Color.Aquamarine);
            Output.WriteLine(" ProcessId: " + Process.GetCurrentProcess()
                .Id, Color.Aquamarine);
            Output.WriteLine(" WorkingSet64: " + Process.GetCurrentProcess()
                .WorkingSet64*0.000001 + " Mb", Color.Aquamarine);
            Output.WriteLine(" Threads: " + GetWorkingThreads(), Color.Aquamarine);
            Output.WriteLine();

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
