using AION.Encdec.Formats;
using AION.Encdec.Utils;

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace AION.Encdec.Tasks
{
    public static class Unpack
    {
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
