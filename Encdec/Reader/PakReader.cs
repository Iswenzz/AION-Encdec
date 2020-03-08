using System;
using System.Collections.Generic;

namespace Iswenzz.AION.Encdec.Reader
{
    /// <summary>
    /// Represent a PAK reader which gets all files inside the pak file.
    /// </summary>
    public class PakReader : IDisposable
    {
        private PakReaderSlim PakReaderSlim { get; set; }
        public Dictionary<string, PakCentralDirFile> Files { get; private set; }
        public string OriginalPakPath => PakReaderSlim.OriginalPakPath;

        /// <summary>
        /// Initialize a new <see cref="PakReader"/> object with the specified pak path.
        /// </summary>
        /// <param name="filename">The pak path</param>
        public PakReader(string filename)
        {
            PakReaderSlim = new PakReaderSlim(filename);
            LoadFileListing();
        }

        /// <summary>
        /// Load all PAK files.
        /// </summary>
        private void LoadFileListing()
        {
            Dictionary<string, PakCentralDirFile> result = new Dictionary<string, PakCentralDirFile>();

            foreach (PakCentralDirFile cd in PakReaderSlim.ReadCentralDir())
                result.Add(cd.filename, cd);

            Files = result;
        }

        /// <summary>
        /// Get a specific file from the loaded PAK files.
        /// </summary>
        /// <param name="filename">File name</param>
        /// <returns></returns>
        public byte[] GetFile(string filename) =>
            PakReaderSlim.ReadFileBytes(Files[PakUtil.NormalizeFilename(filename)]);

        /// <summary>
        /// Close the reader.
        /// </summary>
        public void Close()
        {
            Files?.Clear();
            Files = null;
            PakReaderSlim?.Close();
        }

        /// <summary>
        /// Release all resources
        /// </summary>
        public void Dispose() =>
            Close();
    }
}
