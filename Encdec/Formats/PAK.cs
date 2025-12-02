using AION.Encdec.Utils;

using System;
using System.IO;
using System.Windows.Forms;

namespace AION.Encdec.Formats
{
    public static class PAK
    {
        public static void Unpack(string path, bool createFolder, bool unzip)
        {
            try
            {
                string pathCurrent = Path.GetDirectoryName(path);
                string pathZip = path.Replace(".pak", ".zip");
                string pathFolder = path.Replace(".pak", "");

                string program = Path.Combine(Application.StartupPath, "bin", "pak2zip.exe");
                Proc.Start(program, [path, pathZip]);

                if (unzip)
                {
                    program = Path.Combine(Application.StartupPath, "bin", "7z.exe");
                    Proc.Start(program, ["x", pathZip, "-aos", $"-o{(createFolder ? pathFolder : pathCurrent)}"]);

                    if (File.Exists(pathZip))
                        File.Delete(pathZip);
                }
            }
            catch (Exception e)
            {
                Log.WriteLine(Level.Error, e.Message);
            }
        }

        public static void Repack(string path)
        {
            try
            {
                string pathFolderContent = Path.Combine(path, "*");
                string pathZip = path + ".zip";
                string pathPak = path + ".pak";

                string program = Path.Combine(Application.StartupPath, "bin", "7z.exe");
                Proc.Start(program, ["a", "-tzip", pathZip, pathFolderContent]);

                program = Path.Combine(Application.StartupPath, "bin", "AIONencdec.exe");
                Proc.Start(program, ["-e", pathZip, pathPak]);

                if (File.Exists(pathZip))
                    File.Delete(pathZip);
            } 
            catch (Exception e)
            {
                Log.WriteLine(Level.Error, e.Message);
            }
        }
    }
}
