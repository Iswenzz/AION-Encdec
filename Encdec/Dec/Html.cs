using System.IO;
using System.Windows.Forms;

namespace Iswenzz.AION.Encdec.Dec
{
    public class Html
    {
        public Html(string html)
        {
            int html_exit = Proc.Start(Application.StartupPath + "\\bin\\AIONdisasm.exe",
                            "-r " + html + " " + html + "_tmp", false);

            if (!Proc.ExitError(html_exit))
            {
                File.Delete(html);
                File.Move(html + "_tmp", html);
            }
            if (File.Exists(html + "_tmp"))
                File.Delete(html + "_tmp");

            if (html_exit == -1)
            {
                Out.Log(Out.Level.Skipped, Path.GetFileName(html));
                return;
            }
            Out.Log(Proc.ExitError(html_exit) ? Out.Level.Error : Out.Level.Verbose, Path.GetFileName(html));
        }
    }
}
