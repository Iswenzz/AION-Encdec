using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Iswenzz.AION.Encdec.Dec
{
    public class PakDec
    {
        public PakDec(string pak)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            string pak_name = Path.GetFileNameWithoutExtension(pak);
            Encdec.ConsoleInfo.LogWait(Level.Debug, "Extracting " + pak_name.ToUpper());

            // PAK2ZIP
            Proc.Start(Path.Combine(Application.StartupPath, "bin", "pak2zip.exe"),
                "\"" + pak + "\" \"" + pak.Replace(".pak", ".zip") + "\"", false);

            // 7z
            Proc.Start(Path.Combine(Application.StartupPath, "bin", "7z.exe"),
                "x \"" + Path.Combine(Application.StartupPath, "PAK", pak_name + ".zip") 
                + "\"" + " -aos -o\"" + 
                Path.Combine(Application.StartupPath, "PAK", pak_name) + "\" *.* -r", false);

            File.Delete(Path.Combine(Application.StartupPath, "PAK", pak_name + ".zip"));
            timer.Stop();
            Encdec.ConsoleInfo.LogWait(Level.Info, "Extracted " + pak_name.ToUpper() + " in " + timer.Elapsed.ToString("ss\\.ff") + "s.");
            Encdec.ConsoleInfo.LogWait(Level.Debug, "");
        }
    }
}
