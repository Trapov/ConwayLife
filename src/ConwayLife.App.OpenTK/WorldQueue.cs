using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace ConwayLife.App.OpenTK
{
    public class WorldQueue<T> : ConcurrentQueue<T>
    {
        public async Task PerformLogicAsync(CancellationToken cancelationToken, Func<T, T> feederFunc, T seed)
        {
            var result = await Task.Run(() => feederFunc.Invoke(seed), cancelationToken);
            while (!cancelationToken.IsCancellationRequested)
            {
                if (Count > 30) continue;
                result = await Task.Run(() => feederFunc.Invoke(result), cancelationToken);
                await Task.Delay(300, cancelationToken);
                Enqueue(result);
            }
        }

        public bool TryTakeReady(out T result) => TryDequeue(out result);
    }
}