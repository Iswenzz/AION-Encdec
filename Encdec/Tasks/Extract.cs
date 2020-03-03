using System;
using System.Threading;
using System.Threading.Tasks;

using Iswenzz.AION.Encdec.Dec;

namespace Iswenzz.AION.Encdec.Tasks
{
    public class Extract : IDisposable
    {
        public Task Task { get; set; }
        public CancellationToken CancellationToken { get; set; }
        public CancellationTokenSource CancellationTokenSource { get; set; }

        public Extract()
        {
            CancellationTokenSource = new CancellationTokenSource();
            CancellationToken = CancellationTokenSource.Token;
            Task = Task.Factory.StartNew(Init, CancellationToken);
        }

        public void Init()
        {
            SDK.SetWorking(true);
            Parallel.ForEach(Explorer.GetSelectedPAKs(), (pak) =>
            {
                CancellationToken.ThrowIfCancellationRequested();
                new PakDec(pak);
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
