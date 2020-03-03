using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Iswenzz.AION.Encdec.Format
{
    /// <summary>
    /// Represent a PAK file that can be converted.
    /// </summary>
    public class PAK : IConvertibleAsset
    {
        public string FilePath { get; set; }

        /// <summary>
        /// Initialize a new <see cref="PAK"/> object.
        /// </summary>
        /// <param name="pak">PAK filepath</param>
        public PAK(string pak)
        {
            FilePath = pak;
        }

        /// <summary>
        /// Decode the PAK file.
        /// </summary>
        public void Decode()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            string pak_name = Path.GetFileNameWithoutExtension(FilePath);
            Encdec.ConsoleInfo.LogWait(Level.Debug, "Extracting " + pak_name.ToUpper());

            // PAK2ZIP
            Proc.Start(Path.Combine(Application.StartupPath, "bin", "pak2zip.exe"),
                "\"" + FilePath + "\" \"" + FilePath.Replace(".pak", ".zip") + "\"", false);

            // 7z
            Proc.Start(Path.Combine(Application.StartupPath, "bin", "7z.exe"),
                "x \"" + Path.Combine(Program.Arguments.Input, pak_name + ".zip")
                + "\"" + " -aos -o\"" +
                Path.Combine(Program.Arguments.Input, pak_name) + "\" *.* -r", false);

            File.Delete(Path.Combine(Program.Arguments.Input, pak_name + ".zip"));
            timer.Stop();
            Encdec.ConsoleInfo.LogWait(Level.Info, "Extracted " + pak_name.ToUpper() + " in " 
                + timer.Elapsed.ToString("ss\\.ff") + "s.");
            Encdec.ConsoleInfo.LogWait(Level.Debug, "");
        }

        /// <summary>
        /// Encode the PAK file.
        /// </summary>
        public void Encode()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            string folder_name = Path.GetFileName(FilePath);
            Encdec.ConsoleInfo.LogWait(Level.Debug, "Repacking " + folder_name.ToUpper() + " PAK.");

            // 7z
            Proc.Start(Path.Combine(Application.StartupPath, "bin", "7z.exe"), "a -tZip \""
                + Path.Combine(Application.StartupPath, Program.Arguments.Output, folder_name + ".zip")
                + "\" \"" + Path.Combine(Program.Arguments.Input, folder_name, "*") + "\"", false);

            // AIONencdec
            Proc.Start(Path.Combine(Application.StartupPath, "bin", "AIONencdec.exe"), "-e \""
                + Path.Combine(Application.StartupPath, Program.Arguments.Output, folder_name + ".zip")
                + "\" \"" + Path.Combine(Application.StartupPath, Program.Arguments.Output, folder_name + ".pak") + "\"", false);

            File.Delete(Path.Combine(Application.StartupPath, Program.Arguments.Output, folder_name + ".zip"));

            timer.Stop();
            Encdec.ConsoleInfo.LogWait(Level.Info, "Repacked " + folder_name.ToUpper() + " PAK in "
                + timer.Elapsed.ToString("ss\\.ff") + "s.");
            Encdec.ConsoleInfo.LogWait(Level.Debug, "");
        }
    }
}
