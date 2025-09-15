using AION.Encdec.Formats;
using AION.Encdec.Utils;

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace AION.Encdec.Tasks
{
    /// <summary>
    /// Unpack PAK files.
    /// </summary>
    public static class Unpack
    {
        /// <summary>
        /// Start the unpack task.
        /// </summary>
        /// <param name="paks">The paks files.</param>
        /// <param name="createFolder">Create folders.</param>
        /// <param name="unzip">Unzip the archive.</param>
        public static void Run(List<string> paks, bool createFolder, bool unzip)
        {
            Parallel.ForEach(paks, pak =>
            {
                if (!File.Exists(pak)) return;
                string name = Path.GetFileNameWithoutExtension(pak);
                Log.WriteLine(Level.Debug, $"Extracting {name}");

                Stopwatch timer = Stopwatch.StartNew();
                PAK.Unpack(pak, createFolder, unzip);
                timer.Stop();

                Log.WriteLine(Level.Info, $"Extracted {name} in {timer.Elapsed:ss\\.ff}s");
            });
        }
    }
}
