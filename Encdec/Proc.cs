using System.Diagnostics;

namespace Iswenzz.AION.Encdec
{
    /// <summary>
    /// Process utility class.
    /// </summary>
    public static class Proc
    {
        /// <summary>
        /// Start a new <see cref="Process"/> from specified path, args.
        /// </summary>
        /// <param name="path">Path of the process executable.</param>
        /// <param name="arg">Command line arguments.</param>
        /// <param name="visible">Process visible state.</param>
        /// <returns></returns>
        public static int Start(string path, string arg, bool visible)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = path;
            proc.StartInfo.Arguments = arg;
            proc.StartInfo.UseShellExecute = visible;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            proc.WaitForExit();

            int Exitcode = proc.ExitCode;
            proc.Close();
            proc.Dispose();

            return Exitcode;
        }

        /// <summary>
        /// Test if the process exit is successful.
        /// </summary>
        /// <param name="ErrorCode">Exit code.</param>
        /// <returns></returns>
        public static bool ExitError(int ErrorCode) => ErrorCode != 0;
    }
}
