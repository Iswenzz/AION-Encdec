using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace AION.Encdec.Utils
{
    public static class Proc
    {
        public static int Start(string path, List<string> args)
        {
            using Process proc = new();
            args.ForEach(proc.StartInfo.ArgumentList.Add);
            proc.StartInfo.FileName = path;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.WorkingDirectory = Application.StartupPath;
            proc.Start();
            proc.WaitForExit();
            return proc.ExitCode;
        }
    }
}
