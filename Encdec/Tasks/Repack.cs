using System;
using System.Threading;
using System.Threading.Tasks;

using Iswenzz.AION.Encdec.Enc;

namespace Iswenzz.AION.Encdec.Tasks
{
    /// <summary>
    /// Represent the paks repacking task.
    /// </summary>
    public class Repack : IDisposable
    {
        public Task Task { get; set; }
        public CancellationToken CancellationToken { get; set; }
        public CancellationTokenSource CancellationTokenSource { get; set; }

        /// <summary>
        /// Initialize a new <see cref="Repack"/> object and start the repacking task.
        /// </summary>
        public Repack()
        {
            CancellationTokenSource = new CancellationTokenSource();
            CancellationToken = CancellationTokenSource.Token;
            Task = Task.Factory.StartNew(Init, CancellationToken);
        }

        /// <summary>
        /// Start the repacking task.
        /// </summary>
        public void Init()
        {
            SDK.SetWorking(true);
            Parallel.ForEach(Explorer.GetSelectedFolders(), (folder) =>
            {
                CancellationToken.ThrowIfCancellationRequested();
                new PakEnc(folder);
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
