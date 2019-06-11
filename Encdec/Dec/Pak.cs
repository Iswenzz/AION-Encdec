﻿using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Iswenzz.AION.Encdec.Dec
{
    public class Pak
    {
        public Pak(string pak)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            string pak_name = Path.GetFileNameWithoutExtension(pak);
            Encdec.ConsoleInfo.LogWait(Level.Debug, "Extracting " + pak.Replace("./PAK/", "").ToUpper());

            Proc.Start(Application.StartupPath + "\\bin\\pak2zip.exe", pak + " " + pak.Replace(".pak", ".zip"), false);
            Proc.Start(Application.StartupPath + "\\bin\\7z.exe", "x \"" + Application.StartupPath + "\\PAK\\" +
                pak_name + ".zip\"" + " -aos -o\"" + Application.StartupPath + "\\PAK\\" + pak_name + "\" *.* -r",
                false);

            File.Delete("./PAK/" + pak_name + ".zip");
            timer.Stop();
            Encdec.ConsoleInfo.LogWait(Level.Info, "Extracted " + pak.Replace("./PAK/", "").ToUpper() + " in " + timer.Elapsed.ToString("ss\\.ff") + "s.");
            Encdec.ConsoleInfo.LogWait(Level.Debug, "");
        }
    }
}
