using Iswenzz.AION.Encdec.Tasks;

namespace Iswenzz.AION.Encdec
{
    /// <summary>
    /// Global state of the app.
    /// </summary>
    public static class SDK
    {
        public static Extract Extract { get; set; }
        public static Decode Decode { get; set; }
        public static Repack Repack { get; set; }
        public static bool IsWorking { get; set; }

        /// <summary>
        /// Blocks other tasks from being called if the app is busy.
        /// </summary>
        /// <param name="state">Working state</param>
        public static void SetWorking(bool state) =>
            IsWorking = state;

        /// <summary>
        /// Start a task to extract all selected paks.
        /// </summary>
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

        /// <summary>
        /// Start a task to decode all selected paks.
        /// </summary>
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

        /// <summary>
        /// Start a task to repack all selected paks.
        /// </summary>
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

        /// <summary>
        /// Abort all running tasks.
        /// </summary>
        public static void AbortThreads()
        {
            if (!Extract.Task.IsCompleted) Extract.CancellationTokenSource.Cancel();
            if (!Decode.Task.IsCompleted) Decode.CancellationTokenSource.Cancel();
            if (!Repack.Task.IsCompleted) Repack.CancellationTokenSource.Cancel();
            Encdec.ConsoleInfo.LogWait(Level.Info, "Terminating all threads.");
        }
    }
}