using System.IO;
using System.Windows.Forms;

namespace Iswenzz.AION.Encdec.Dec
{
    public class HtmlDec
    {
        public HtmlDec(string html)
        {
            int html_exit = Proc.Start(Path.Combine(Application.StartupPath, "bin", "AIONdisasm.exe"),
                "-r \"" + html + "\" \"" + html + "_tmp\"", false);

            if (!Proc.ExitError(html_exit))
            {
                File.Delete(html);
                File.Move(html + "_tmp", html);
            }
            if (File.Exists(html + "_tmp"))
                File.Delete(html + "_tmp");

            if (html_exit == -1)
            {
                Encdec.ConsoleInfo.LogWait(Level.Skipped, Path.GetFileName(html));
                return;
            }
            Encdec.ConsoleInfo.LogWait(Proc.ExitError(html_exit) ? Level.Error : Level.Verbose, Path.GetFileName(html));
        }
    }
}
