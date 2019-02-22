using System.Threading;

namespace Iswenzz.AION.Encdec
{
    public static class SDK
    {
        public static Thread Extract;
        public static Thread Decode;
        public static Thread Repack;
        public static bool Working = false;

        public static void AbortThreads()
        {
            if (Extract.IsAlive) Extract.Abort();
            if (Decode.IsAlive) Decode.Abort();
            if (Repack.IsAlive) Repack.Abort();
            Out.Log(Out.Level.Info, "Terminating all threads.");
        }
    }
}