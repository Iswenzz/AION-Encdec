using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Iswenzz.AION.Encdec.Enc
{
    public class Pak
    {
        public Pak(string folder)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            string folder_name = folder.Replace("./PAK/", "");
            Out.Log(Out.Level.Debug, "Repacking " + folder_name.ToUpper() + " PAK.");

            Proc.Start(Application.StartupPath + "\\bin\\7z.exe", "a -tZip ./recompiled_PAK/"
                + folder_name + ".zip ./PAK/" + folder_name + "/*", false);
            Proc.Start(Application.StartupPath + "\\bin\\AIONencdec.exe", "-e ./recompiled_PAK/"
                + folder_name + ".zip ./recompiled_PAK/" + folder_name + ".pak", false);
            File.Delete("./recompiled_PAK/" + folder_name + ".zip");

            timer.Stop();
            Out.Log(Out.Level.Info, "Repacked " + folder_name.ToUpper() + " PAK in " + timer.Elapsed.ToString("ss\\.ff") + "s.");
            Out.Log(Out.Level.Debug, "");
        }
    }
}
