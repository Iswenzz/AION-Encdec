using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

using Iswenzz.AION.Encdec.Format;

namespace Iswenzz.AION.Encdec.Tasks
{
    /// <summary>
    /// Represent the paks decoding task.
    /// </summary>
    public class Decode : IDisposable
    {
        public Task Task { get; set; }
        public CancellationToken CancellationToken { get; set; }
        public CancellationTokenSource CancellationTokenSource { get; set; }

        /// <summary>
        /// Initialize a new <see cref="Decode"/> object and start the decoding task.
        /// </summary>
        public Decode()
        {
            CancellationTokenSource = new CancellationTokenSource();
            CancellationToken = CancellationTokenSource.Token;
            Task = Task.Factory.StartNew(Init, CancellationToken);
        }

        /// <summary>
        /// Start the decoding task.
        /// </summary>
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

                Encdec.ConsoleInfo.LogWait(Level.Info, "{Decrypting} " + folder_name.ToUpper() + " Folder.");

                if (folder_xml.Length > 0)
                {
                    Parallel.ForEach(folder_xml, (xml) =>
                    {
                        CancellationToken.ThrowIfCancellationRequested();
                        new XML(xml).Decode();
                    });
                }
                if (folder_html.Length > 0)
                {
                    Parallel.ForEach(folder_html, (html) =>
                    {
                        CancellationToken.ThrowIfCancellationRequested();
                        new HTML(html).Decode();
                    });
                }

                timer.Stop();
                Encdec.ConsoleInfo.LogWait(Level.Info, "{Decrypted} " + folder_name.ToUpper() + " Folder in " + timer.Elapsed.ToString("ss\\.ff") + "s.");
            }
            SDK.SetWorking(false);
        }

        /// <summary>
        /// Dispose all resources.
        /// </summary>
        public void Dispose()
        {
            CancellationTokenSource?.Cancel();
            CancellationTokenSource?.Dispose();
            Task?.Dispose();
        }
    }
}
