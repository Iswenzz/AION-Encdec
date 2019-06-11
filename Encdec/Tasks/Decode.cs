using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Iswenzz.AION.Encdec.Tasks
{
    public static class Decode
    {
        public static void Init()
        {
            if (SDK.Working) return;
            SDK.Working = true;
            foreach (var folder in Explorer.GetSelectedFolders())
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();

                string folder_name = Path.GetFileName(folder);
                string[] folder_xml = Directory.GetFiles(folder, "*.xml", SearchOption.AllDirectories);
                string[] folder_html = Directory.GetFiles(folder, "*.html", SearchOption.AllDirectories);

                Encdec.ConsoleInfo.LogWait(Level.Debug, "Decrypting " + folder_name.ToUpper() + " Folder.");

                Parallel.ForEach(folder_xml, (xml) => new Dec.Xml(xml));
                Parallel.ForEach(folder_html, (html) => new Dec.Html(html));

                timer.Stop();
                Encdec.ConsoleInfo.LogWait(Level.Info, "Decrypted " + folder_name.ToUpper() + " Folder in " + timer.Elapsed.ToString("ss\\.ff") + "s.");
                Encdec.ConsoleInfo.LogWait(Level.Debug, "");
            }
            SDK.Working = false;
        }
    }
}
