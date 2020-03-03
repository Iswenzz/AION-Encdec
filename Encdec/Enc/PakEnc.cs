using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Iswenzz.AION.Encdec.Enc
{
    public class PakEnc
    {
        public PakEnc(string folder)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            string folder_name = Path.GetFileName(folder);
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
            Encdec.ConsoleInfo.LogWait(Level.Info, "Repacked " + folder_name.ToUpper() + " PAK in " + timer.Elapsed.ToString("ss\\.ff") + "s.");
            Encdec.ConsoleInfo.LogWait(Level.Debug, "");
        }
    }
}
