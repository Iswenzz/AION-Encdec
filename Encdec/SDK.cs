using Iswenzz.AION.Encdec.Tasks;

namespace Iswenzz.AION.Encdec
{
    public static class SDK
    {
        public static Extract Extract { get; set; }
        public static Decode Decode { get; set; }
        public static Repack Repack { get; set; }
        public static bool IsWorking { get; set; }

        public static void SetWorking(bool state) =>
            IsWorking = state;

        public static void InitExtraction()
        {
            if (IsWorking)
                return;
            else
            {
                Extract?.Dispose();
                Extract = new Extract();
            }
        }

        public static void InitDecoding()
        {
            if (IsWorking)
                return;
            else
            {
                Decode?.Dispose();
                Decode = new Decode();
            }
        }

        public static void InitRepacking()
        {
            if (IsWorking)
                return;
            else
            {
                Repack?.Dispose();
                Repack = new Repack();
            }
        }

        public static void AbortThreads()
        {
            if (!Extract.Task.IsCompleted) Extract.CancellationTokenSource.Cancel();
            if (!Decode.Task.IsCompleted) Decode.CancellationTokenSource.Cancel();
            if (!Repack.Task.IsCompleted) Repack.CancellationTokenSource.Cancel();
            Encdec.ConsoleInfo.LogWait(Level.Info, "Terminating all threads.");
        }
    }
}