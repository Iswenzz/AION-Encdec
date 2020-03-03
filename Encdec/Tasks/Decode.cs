using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

using Iswenzz.AION.Encdec.Dec;

namespace Iswenzz.AION.Encdec.Tasks
{
    public class Decode : IDisposable
    {
        public Task Task { get; set; }
        public CancellationToken CancellationToken { get; set; }
        public CancellationTokenSource CancellationTokenSource { get; set; }

        public Decode()
        {
            CancellationTokenSource = new CancellationTokenSource();
            CancellationToken = CancellationTokenSource.Token;
            Task = Task.Factory.StartNew(Init, CancellationToken);
        }

        public void Init()
        {
            SDK.SetWorking(true);
            foreach (var folder in Explorer.GetSelectedFolders())
            {
                CancellationToken.ThrowIfCancellationRequested();
                Stopwatch timer = new Stopwatch();
                timer.Start();

                string folder_name = Path.GetFileName(folder);
                string[] folder_xml = Directory.GetFiles(folder, "*.xml", SearchOption.AllDirectories);
                string[] folder_html = Directory.GetFiles(folder, "*.html", SearchOption.AllDirectories);

                Encdec.ConsoleInfo.LogWait(Level.Debug, "Decrypting " + folder_name.ToUpper() + " Folder.");

                Parallel.ForEach(folder_xml, (xml) =>
                {
                    CancellationToken.ThrowIfCancellationRequested();
                    new XmlDec(xml);
                });
                Parallel.ForEach(folder_html, (html) =>
                {
                    CancellationToken.ThrowIfCancellationRequested();
                    new HtmlDec(html);
                });

                timer.Stop();
                Encdec.ConsoleInfo.LogWait(Level.Info, "Decrypted " + folder_name.ToUpper() + " Folder in " + timer.Elapsed.ToString("ss\\.ff") + "s.");
                Encdec.ConsoleInfo.LogWait(Level.Debug, "");
            }
            SDK.SetWorking(false);
        }

        public void Dispose()
        {
            CancellationTokenSource?.Cancel();
            CancellationTokenSource?.Dispose();
            Task?.Dispose();
        }
    }
}
