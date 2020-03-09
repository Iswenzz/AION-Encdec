using System;
using System.IO;
using System.Text.RegularExpressions;

using Iswenzz.AION.Encdec.Reader;

namespace Iswenzz.AION.Encdec.Tasks
{
    /// <summary>
    /// Extract files from specified PAK.
    /// </summary>
    public class SingleExtract : IDisposable
    {
        private PakReader PakReader { get; set; }

        /// <summary>
        /// Initialize a new <see cref="SingleExtract"/> object and get the files from specified absolute path.
        /// </summary>
        /// <param name="fullpath">Absolute path to a file in a PAK archive.</param>
        public SingleExtract(string fullpath)
        {
            if (fullpath.Contains("*"))
                ExtractFiles(fullpath);
            else
                ExtractFile(fullpath);
        }

        /// <summary>
        /// Extract all files from absolute path with patern matching.
        /// </summary>
        /// <param name="fullpath">Absolute path to a file in a PAK archive with patern matching.</param>
        public void ExtractFiles(string fullpath)
        {
            string pakFilePath = Regex.Match(fullpath, ".*.pak").Value;
            string fileMatch = Path.GetFileName(Regex.Replace(fullpath, ".*.pak", "").Trim()).Replace("*", ".*");
            Console.WriteLine("Patern: " + fileMatch);

            PakReader?.Dispose();
            PakReader = new PakReader(pakFilePath);

            foreach (PakCentralDirFile file in PakReader.Files.Values)
            {
                Match match = Regex.Match(file.filename, fileMatch);
                if (match.Success)
                {
                    Console.WriteLine("Matched: " + match.Value);
                    byte[] fileBytes = PakReader.GetFile(match.Value);
                    if (fileBytes != null)
                        File.WriteAllBytes(Path.Combine(Program.Arguments.Input, match.Value), fileBytes);
                }
            }
        }

        /// <summary>
        /// Extract all files from absolute path.
        /// </summary>
        /// <param name="fullpath">Absolute path to a file in a PAK archive.</param>
        public void ExtractFile(string fullpath)
        {
            string pakFilePath = Regex.Match(fullpath, ".*.pak").Value;
            string fileMatch = Path.GetFileName(Regex.Replace(fullpath, ".*.pak", "").Trim());

            PakReader?.Dispose();
            PakReader = new PakReader(pakFilePath);
            byte[] fileBytes = PakReader.GetFile(fileMatch);
            if (fileBytes != null)
                File.WriteAllBytes(Path.Combine(Program.Arguments.Input, fileMatch), fileBytes);
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
