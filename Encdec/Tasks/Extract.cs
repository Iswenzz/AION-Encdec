using System;
using System.Threading;
using System.Threading.Tasks;
using Iswenzz.AION.Encdec.Format;

namespace Iswenzz.AION.Encdec.Tasks
{
    /// <summary>
    /// Represent the paks extraction task.
    /// </summary>
    public class Extract : IDisposable
    {
        public Task Task { get; set; }
        public CancellationToken CancellationToken { get; set; }
        public CancellationTokenSource CancellationTokenSource { get; set; }

        /// <summary>
        /// Initialize a new <see cref="Extract"/> object and start the extracting task.
        /// </summary>
        public Extract()
        {
            CancellationTokenSource = new CancellationTokenSource();
            CancellationToken = CancellationTokenSource.Token;
            Task = Task.Factory.StartNew(Init, CancellationToken);
        }

        /// <summary>
        /// Start the extracting task.
        /// </summary>
        public void Init()
        {
            SDK.SetWorking(true);
            Parallel.ForEach(Explorer.GetSelectedPAKs(), (pak) =>
            {
                CancellationToken.ThrowIfCancellationRequested();
                new PAK(pak).Decode();
            });
            SDK.SetWorking(false);
        }

        /// <summary>
        /// Dispose all resources.
        /// </summary>
        public void Dispose()
        {
            CancellationTokenSource?.Cancel();
            CancellationTokenSource?.Dispose();
            Task?.Dispose();
        }
    }
}
