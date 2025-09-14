using AION.Encdec.Utils;
using System;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Windows.Forms;

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
        /// <param name="createFolder">Create a folder.</param>
        public static void Unpack(string path, bool createFolder)
        {
            string pathCurrent = Path.GetDirectoryName(path);
            string pathZip = path.Replace(".pak", ".zip");
            string pathFolder = path.Replace(".pak", "");

            try
            {
                string program = Path.Combine(Application.StartupPath, "bin", "pak2zip.exe");
                Proc.Start(program, [path, pathZip]);

                program = Path.Combine(Application.StartupPath, "bin", "7z.exe");
                Proc.Start(program, ["x", pathZip, "-aos", $"-o{(createFolder ? pathFolder : pathCurrent)}"]);

                if (File.Exists(pathZip))
                    File.Delete(pathZip);
            }
            catch (Exception e)
            {
                Log.WriteLine(Level.Error, e.Message);
            }
        }

        /// <summary>
        /// Repack the PAK file.
        /// </summary>
        /// <param name="path">The folder path.</param>
        public static void Repack(string path)
        {
            string pathFolderContent = Path.Combine(path, "*");
            string pathZip = path + ".zip";
            string pathPak = path + ".pak";

            try
            {
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
