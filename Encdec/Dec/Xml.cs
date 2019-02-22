using System.IO;
using System.Windows.Forms;

namespace Iswenzz.AION.Encdec.Dec
{
    public class Xml
    {
        public Xml(string xml)
        {
            int xml_exit = Proc.Start(Application.StartupPath + "\\bin\\AIONdisasm.exe",
                        xml + " " + xml + "_tmp", false);

            if (!Proc.ExitError(xml_exit))
            {
                File.Delete(xml);
                File.Move(xml + "_tmp", xml);
            }
            if (File.Exists(xml + "_tmp"))
                File.Delete(xml + "_tmp");

            if (xml_exit == -1) // Already decoded
            {
                Out.Log(Out.Level.Skipped, Path.GetFileName(xml));
                return;
            }

            if (Proc.ExitError(xml_exit)) // Last try
                xml_exit = Proc.Start(Application.StartupPath + "\\bin\\xml.exe", xml + " " + xml, false);

            Out.Log(Proc.ExitError(xml_exit) ? Out.Level.Error : Out.Level.Verbose, Path.GetFileName(xml));
        }
    }
}
