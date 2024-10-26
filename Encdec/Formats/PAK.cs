using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

using AION.Encdec.Utils;

namespace AION.Encdec.Formats
{
    /// <summary>
    /// PAK file class.
    /// </summary>
    public static class PAK
    {
        /// <summary>
        /// Unpack the PAK file.
        /// </summary>
        /// <param name="path">The file path.</param>
        public static void Unpack(string path)
        {
            Stopwatch timer = Stopwatch.StartNew();
            string filename = Path.GetFileNameWithoutExtension(path);
            string pathZip = path.Replace(".pak", ".zip");
            string pathFolder = path.Replace(".pak", "");

            Log.WriteLine(Level.Debug, $"Extracting {filename}");
            string program = Path.Combine(Application.StartupPath, "bin", "pak2zip.exe");
            Proc.Start(program, [path, pathZip]);

            program = Path.Combine(Application.StartupPath, "bin", "7z.exe");
            Proc.Start(program, ["x", pathZip, "-aos", $"-o{pathFolder}", "*", "-r"]);
            File.Delete(pathZip);

            timer.Stop();
            Log.WriteLine(Level.Info, $"Extracted {filename} in {timer.Elapsed:ss\\.ff}s");
        }

        /// <summary>
        /// Repack the PAK file.
        /// </summary>
        /// <param name="path">The file path.</param>
        public static void Repack(string path)
        {
            Stopwatch timer = Stopwatch.StartNew();
            string filename = Path.GetFileNameWithoutExtension(path);
            string pathFolder = path.Replace(".pak", "");
            string pathFolderContent = Path.Combine(pathFolder, "*");
            string pathZip = path.Replace(".pak", ".zip");
            string pathRepack = Path.Combine(Program.Arguments.Output, filename + ".pak");

            if (!Directory.Exists(pathFolder))
                return;

            Log.WriteLine(Level.Debug, $"Repacking {filename}");
            string program = Path.Combine(Application.StartupPath, "bin", "7z.exe");
            Proc.Start(program, ["a", "-tzip", pathZip, pathFolderContent]);

            program = Path.Combine(Application.StartupPath, "bin", "AIONencdec.exe");
            Proc.Start(program, ["-e", pathZip, pathRepack]);
            File.Delete(pathZip);

            timer.Stop();
            Log.WriteLine(Level.Info, $"Repacked {filename} in {timer.Elapsed:ss\\.ff}s");
        }
    }
}
