using System.IO;
using System.Windows.Forms;

using AION.Encdec.Utils;

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
            string program = Path.Combine(Application.StartupPath, "bin", "AIONdisasm.exe");
            int exit = Proc.Start(program, ["-r", path, pathTmp]);
            Level level = exit == 0 ? Level.Success : Level.Error;

            if (File.Exists(pathTmp))
            {
                if (File.ReadAllBytes(pathTmp).Length > 0)
                    File.Replace(pathTmp, path, null);

                File.Delete(pathTmp);
            }
            Log.WriteLine(level, filename);
        }
    }
}
