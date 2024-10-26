using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

using AION.Encdec.Formats;
using AION.Encdec.Utils;

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
        public static void Run()
        {
            if (Program.IsWorking) return;

            Program.IsWorking = true;
            Parallel.ForEach(Program.Files, path =>
            {
                Stopwatch timer = Stopwatch.StartNew();
                string filename = Path.GetFileNameWithoutExtension(path);
                string pathFolder = path.Replace(".pak", "");

                if (!Directory.Exists(pathFolder))
                    return;

                string[] xmls = Directory.GetFiles(pathFolder, "*.xml", SearchOption.AllDirectories);
                string[] htmls = Directory.GetFiles(pathFolder, "*.html", SearchOption.AllDirectories);

                Log.WriteLine(Level.Debug, $"Decrypting {filename}");
                Parallel.ForEach(xmls, XML.Decode);
                Parallel.ForEach(htmls, HTML.Decode);

                timer.Stop();
                Log.WriteLine(Level.Info, $"Decrypted {filename} in {timer.Elapsed:ss\\.ff}s");
            });
            Program.IsWorking = false;
        }
    }
}
