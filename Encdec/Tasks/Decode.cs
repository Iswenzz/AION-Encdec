using AION.Encdec.Formats;
using AION.Encdec.Utils;

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace AION.Encdec.Tasks
{
    /// <summary>
    /// Decode PAK files.
    /// </summary>
    public static class Decode
    {
        /// <summary>
        /// Start the unpack task.
        /// </summary>
        /// <param name="folders">The folders.</param>
        public static void Run(List<string> folders)
        {
            Parallel.ForEach(folders, folder =>
            {
                if (!Directory.Exists(folder)) return;
                string name = Path.GetFileName(folder);
                Log.WriteLine(Level.Debug, $"Decrypting {name}");

                string[] xmls = Directory.GetFiles(folder, "*.xml", SearchOption.AllDirectories);
                string[] htmls = Directory.GetFiles(folder, "*.html", SearchOption.AllDirectories);

                Stopwatch timer = Stopwatch.StartNew();
                Parallel.ForEach(xmls, XML.Decode);
                Parallel.ForEach(htmls, HTML.Decode);
                timer.Stop();

                Log.WriteLine(Level.Info, $"Decrypted {name} in {timer.Elapsed:ss\\.ff}s");
            });
        }
    }
}
