using System.Diagnostics;
using System.IO;

using Iswenzz.AION.Encdec.Dec;

namespace Iswenzz.AION.Encdec.Task
{
    public static class Decode
    {
        public static void Init()
        {
            if (SDK.Working) return;
            SDK.Working = true;
            foreach (var folder in Directory.GetDirectories("./PAK/"))
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();

                string folder_name = folder.Replace("./PAK/", "");
                string[] folder_xml = Directory.GetFiles(folder, "*.xml", SearchOption.AllDirectories);
                string[] folder_html = Directory.GetFiles(folder, "*.html", SearchOption.AllDirectories);

                Out.Log(Out.Level.Debug, "Decrypting " + folder_name.ToUpper() + " Folder.");

                foreach (string xml in folder_xml) new Dec.Xml(xml);
                foreach (string html in folder_html) new Dec.Html(html);

                timer.Stop();
                Out.Log(Out.Level.Info, "Decrypted " + folder_name.ToUpper() + " Folder in " + timer.Elapsed.ToString("ss\\.ff") + "s.");
                Out.Log(Out.Level.Debug, "");
            }
            SDK.Working = false;
        }
    }
}
