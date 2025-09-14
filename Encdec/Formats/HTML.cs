using AION.Encdec.Utils;
using System;
using System.IO;
using System.Windows.Forms;

namespace AION.Encdec.Formats
{
    /// <summary>
    /// HTML file class.
    /// </summary>
    public static class HTML
    {
        /// <summary>
        /// Decode the HTML file.
        /// </summary>
        /// <param name="path">The file path.</param>
        public static void Decode(string path)
        {
            string filename = Path.GetFileName(path);
            string pathTmp = path.Replace(".html", "_tmp.html");
            
            try
            {
                string program = Path.Combine(Application.StartupPath, "bin", "AIONdisasm.exe");
                int exit = Proc.Start(program, ["-r", path, pathTmp]);
                Level level = exit == 0 ? Level.Success : Level.Error;

                if (File.Exists(pathTmp))
                {
                    if (File.ReadAllBytes(pathTmp).Length > 0)
                        File.Replace(pathTmp, path, null);

                    if (File.Exists(pathTmp))
                        File.Delete(pathTmp);
                }
                Log.WriteLine(level, filename);
            }
            catch (Exception e)
            {
                Log.WriteLine(Level.Error, e.Message);
            }
        }
    }
}
