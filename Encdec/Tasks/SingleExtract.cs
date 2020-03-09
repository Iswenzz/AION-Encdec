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

            PakReader?.Dispose();
            PakReader = new PakReader(pakFilePath);

            foreach (PakCentralDirFile file in PakReader.Files.Values)
            {
                Match match = Regex.Match(file.filename.ToLower(), fileMatch.ToLower());
                if (match.Success)
                {
                    byte[] fileBytes = PakReader.GetFile(match.Value);
                    Encdec.ConsoleInfo.LogWait(Level.Info, "{Extract} " + match.Value);
                    if (fileBytes != null)
                    {
                        FileInfo f = new FileInfo(Path.Combine(Program.Arguments.Input,
                            Path.GetFileNameWithoutExtension(pakFilePath),match.Value).Replace("/", "\\"));
                        f.Directory.Create();
                        if (!File.Exists(f.FullName))
                            File.WriteAllBytes(f.FullName, fileBytes);
                        else
                        {
                            int idx = 1;
                            string newPath;
                            while (File.Exists(newPath = Path.Combine(f.Directory.FullName, 
                                Path.GetFileNameWithoutExtension(f.Name) + "_" + idx + f.Extension)))
                                idx++;
                            File.WriteAllBytes(newPath, fileBytes);
                        }
                    }
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
            Encdec.ConsoleInfo.LogWait(Level.Info, "{Extract} " + fileMatch);
            if (fileBytes != null)
            {
                FileInfo f = new FileInfo(Path.Combine(Program.Arguments.Input, 
                    Path.GetFileNameWithoutExtension(pakFilePath), fileMatch).Replace("/", "\\"));
                f.Directory.Create();
                if (!File.Exists(f.FullName))
                    File.WriteAllBytes(f.FullName, fileBytes);
                else
                {
                    int idx = 1;
                    string newPath;
                    while (File.Exists(newPath = Path.Combine(f.Directory.FullName,
                        Path.GetFileNameWithoutExtension(f.Name) + "_" + idx + f.Extension)))
                        idx++;
                    File.WriteAllBytes(newPath, fileBytes);
                }
            }
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
