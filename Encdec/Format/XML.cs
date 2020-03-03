using System.IO;
using System.Windows.Forms;

namespace Iswenzz.AION.Encdec.Format
{
    /// <summary>
    /// Represent an XML file that can be converted.
    /// </summary>
    public class XML : IConvertibleAsset
    {
        public string FilePath { get; set; }

        /// <summary>
        /// Initialize a new <see cref="XML"/> object.
        /// </summary>
        /// <param name="xml">XML Filepath</param>
        public XML(string xml)
        {
            FilePath = xml;
        }

        /// <summary>
        /// Decode the XML file.
        /// </summary>
        public void Decode()
        {
            int xml_exit = Proc.Start(Path.Combine(Application.StartupPath, "bin", "AIONdisasm.exe"),
                "\"" + FilePath + "\" \"" + FilePath + "_tmp\"", false);

            if (!Proc.ExitError(xml_exit))
            {
                File.Delete(FilePath);
                File.Move(FilePath + "_tmp", FilePath);
            }
            if (File.Exists(FilePath + "_tmp"))
                File.Delete(FilePath + "_tmp");

            if (xml_exit == -1) // Already decoded
            {
                Encdec.ConsoleInfo.LogWait(Level.Skipped, Path.GetFileName(FilePath));
                return;
            }
            if (Proc.ExitError(xml_exit)) // Last try
                xml_exit = Proc.Start(Path.Combine(Application.StartupPath, "bin", "xml.exe"),
                    "\"" + FilePath + "\" \"" + FilePath + "\"", false);

            Encdec.ConsoleInfo.LogWait(Proc.ExitError(xml_exit) ? Level.Error : Level.Verbose, 
                Path.GetFileName(FilePath));
        }

        /// <summary>
        /// Encode the XML file.
        /// </summary>
        public void Encode()
        {
            throw new System.NotImplementedException();
        }
    }
}
