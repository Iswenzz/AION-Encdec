using AION.Encdec.Formats;
using AION.Encdec.Utils;

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace AION.Encdec.Tasks
{
    /// <summary>
    /// Repack PAK files.
    /// </summary>
    public static class Repack 
    {
        /// <summary>
        /// Start the repack task.
        /// </summary>
        /// <param name="folders">The folders.</param>
        public static void Run(List<string> folders)
        {
            Parallel.ForEach(folders, folder =>
            {
                if (!Directory.Exists(folder)) return;
                string name = Path.GetFileName(folder);
                Log.WriteLine(Level.Debug, $"Repacking {name}");

                Stopwatch timer = Stopwatch.StartNew();
                PAK.Repack(folder);
                timer.Stop();

                Log.WriteLine(Level.Info, $"Repacked {name} in {timer.Elapsed:ss\\.ff}s");
            });
        }
    }
}
