using System.Diagnostics;

namespace Iswenzz.AION.Encdec
{
    public static class Proc
    {
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

        public static bool ExitError(int ErrorCode)
        {
            return ErrorCode == 0 ? false : true;
        }
    }
}
