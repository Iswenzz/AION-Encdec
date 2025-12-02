using AION.Encdec.Utils;

using System;
using System.IO;
using System.Windows.Forms;

namespace AION.Encdec.Formats
{
    public static class HTML
    {
        public static void Decode(string path)
        {
            try
            {
                string pathTmp = path.Replace(".html", "_tmp.html");
                string program = Path.Combine(Application.StartupPath, "bin", "AIONdisasm.exe");
                int exit = Proc.Start(program, ["-r", path, pathTmp]);
                Level level = exit == -1 ? Level.Skipped : exit == 0 ? Level.Success : Level.Error;

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
