using AION.Encdec.Utils;

using System;
using System.IO;
using System.Windows.Forms;

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
            try
            {
                string pathTmp = path.Replace(".xml", "_tmp.xml");
                string program = Path.Combine(Application.StartupPath, "bin", "AIONdisasm.exe");
                int exit = Proc.Start(program, [path, pathTmp]);
                Level level = exit == -1 ? Level.Skipped : exit == 0 ? Level.Success : Level.Error;

                if (exit > 0)
                {
                    program = Path.Combine(Application.StartupPath, "bin", "xml.exe");
                    exit = Proc.Start(program, [path, pathTmp]);
                    level = exit == -1 ? Level.Skipped : exit == 0 ? Level.Success : Level.Error;
                }
                if (File.Exists(pathTmp))
                {
                    if (File.ReadAllBytes(pathTmp).Length > 0)
                        File.Replace(pathTmp, path, null);

                    if (File.Exists(pathTmp))
                        File.Delete(pathTmp);
                }
                Log.WriteLine(level, Path.GetRelativePath(Program.Arguments.Input, path));
            }
            catch (Exception e)
            {
                Log.WriteLine(Level.Error, e.Message);
            }
        }
    }
}
