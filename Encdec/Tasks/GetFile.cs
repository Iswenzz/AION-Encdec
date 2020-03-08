using Iswenzz.AION.Encdec.Reader;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace Iswenzz.AION.Encdec.Tasks
{
    /// <summary>
    /// Get a file from specified PAK.
    /// </summary>
    public class GetFile : IDisposable
    {
        public PakReader PakReader { get; set; }
        public string AbsolutePAKFilePath { get; set; }
        public string PAKFilePath { get; set; }
        public string FileName { get; set; }
        public byte[] FileBytes { get; set; }

        /// <summary>
        /// Initialize a new <see cref="GetFile"/> object and get the file from specified absolute path.
        /// </summary>
        /// <param name="fullpath">Absolute path to a file in a PAK archive.</param>
        public GetFile(string fullpath)
        {
            AbsolutePAKFilePath = fullpath;
            Get(fullpath);
        }

        /// <summary>
        /// Get file bytes from specified absolute path.
        /// </summary>
        /// <param name="fullpath">Absolute path to a file in a PAK archive.</param>
        /// <returns></returns>
        public byte[] Get(string fullpath)
        {
            PAKFilePath = Regex.Match(fullpath, ".*.pak").Value;
            FileName = Path.GetFileName(Regex.Replace(fullpath, ".*.pak", "").Trim());

            PakReader?.Dispose();
            PakReader = new PakReader(PAKFilePath);
            return FileBytes = PakReader.GetFile(FileName);
        }

        /// <summary>
        /// Save the file to specified path.
        /// </summary>
        /// <param name="path">Path to save the file.</param>
        public void Save(string path)
        {
            if (FileBytes != null)
                File.WriteAllBytes(path, FileBytes);
        }

        /// <summary>
        /// Release all resources.
        /// </summary>
        public void Dispose()
        {
            PakReader?.Dispose();
        }
    }
}
