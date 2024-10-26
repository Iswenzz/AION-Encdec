using System.IO;
using System.Windows.Forms;

using AION.Encdec.Utils;

namespace AION.Encdec.Formats
{
    /// <summary>
    /// XML file class.
    /// </summary>
    public static class XML
    {
        /// <summary>
        /// Decode the XML file.
        /// </summary>
        /// <param name="path">The file path.</param>
        public static void Decode(string path)
        {
            string filename = Path.GetFileName(path);
            string pathTmp = path.Replace(".xml", "_tmp.xml");
            string program = Path.Combine(Application.StartupPath, "bin", "AIONdisasm.exe");
            int exit = Proc.Start(program, [path, pathTmp]);
            Level level = exit == 0 ? Level.Success : Level.Error;

            if (exit == -1)
                level = Level.Skipped;

            if (exit > 0)
            {
                program = Path.Combine(Application.StartupPath, "bin", "xml.exe");
                exit = Proc.Start(program, [path, pathTmp]);
                level = exit == 0 ? Level.Success : Level.Error;
            }
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
