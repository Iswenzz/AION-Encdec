using System;
using System.Threading;
using System.Threading.Tasks;

using Iswenzz.AION.Encdec.Enc;

namespace Iswenzz.AION.Encdec.Tasks
{
    public class Repack : IDisposable
    {
        public Task Task { get; set; }
        public CancellationToken CancellationToken { get; set; }
        public CancellationTokenSource CancellationTokenSource { get; set; }

        public Repack()
        {
            CancellationTokenSource = new CancellationTokenSource();
            CancellationToken = CancellationTokenSource.Token;
            Task = Task.Factory.StartNew(Init, CancellationToken);
        }

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

        public void Dispose()
        {
            CancellationTokenSource?.Cancel();
            CancellationTokenSource?.Dispose();
            Task?.Dispose();
        }
    }
}
