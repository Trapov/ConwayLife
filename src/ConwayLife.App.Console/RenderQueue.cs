using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace ConwayLife.App.Console
{
    public class RenderQueue : BlockingCollection<Action>
    {
        public async Task RenderAsync(CancellationToken cancelationToken, TimeSpan renderDelay)
        {
            while (!cancelationToken.IsCancellationRequested)
            {
                await Task.Run(Take(cancelationToken), cancelationToken);
                await Task.Delay(renderDelay, cancelationToken);
            }
        }
    }
}