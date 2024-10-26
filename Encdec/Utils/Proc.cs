using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace AION.Encdec.Utils
{
    /// <summary>
    /// Process utility class.
    /// </summary>
    public static class Proc
    {
        /// <summary>
        /// Start a new <see cref="Process"/>.
        /// </summary>
        /// <param name="path">The path of the program executable.</param>
        /// <param name="args">The arguments arguments.</param>
        /// <returns></returns>
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
