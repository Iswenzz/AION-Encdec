using System.IO;
using System.Windows.Forms;

namespace Iswenzz.AION.Encdec.Format
{
    /// <summary>
    /// Represent an HTML file that can be converted.
    /// </summary>
    public class HTML : IConvertibleAsset
    {
        public string FilePath { get; set; }

        /// <summary>
        /// Initialize a new <see cref="HTML"/> object.
        /// </summary>
        /// <param name="html">HTML filepath</param>
        public HTML(string html)
        {
            FilePath = html;
        }

        /// <summary>
        /// Decode the HTML file.
        /// </summary>
        public void Decode()
        {
            int html_exit = Proc.Start(Path.Combine(Application.StartupPath, "bin", "AIONdisasm.exe"),
                "-r \"" + FilePath + "\" \"" + FilePath + "_tmp\"", false);

            if (!Proc.ExitError(html_exit))
            {
                File.Delete(FilePath);
                File.Move(FilePath + "_tmp", FilePath);
            }
            if (File.Exists(FilePath + "_tmp"))
                File.Delete(FilePath + "_tmp");

            if (html_exit == -1)
            {
                Encdec.ConsoleInfo.LogWait(Level.Skipped, Path.GetFileName(FilePath));
                return;
            }
            Encdec.ConsoleInfo.LogWait(Proc.ExitError(html_exit) ? Level.Error : Level.Verbose, 
                Path.GetFileName(FilePath));
        }

        /// <summary>
        /// Encode the HTML file.
        /// </summary>
        public void Encode()
        {
            throw new System.NotImplementedException();
        }
    }
}
