using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Iswenzz.AION.Encdec.Reader
{
    /// <summary>
    /// Core binary reader for PAK files. Check <see cref="PakReader"/> for easy implementation.
    /// </summary>
    public class PakReaderSlim : IDisposable
    {
        public string OriginalPakPath { get => FS.Name; }
        private FileStream FS { get; set; }
        private BinaryReader Reader { get; set; }

        private PakCentralDirEnd EO_CentralDir;

        /// <summary>
        /// Initialize a new <see cref="PakReaderSlim"/> object with the specified PAK path.
        /// </summary>
        /// <param name="filename">The PAK path</param>
        public PakReaderSlim(string filename)
        {
            FS = File.OpenRead(filename);
            Reader = new BinaryReader(FS);

            ReadCentralDirEnd();
        }

        /// <summary>
        /// Decode bytes from specified PAK file bytes.
        /// </summary>
        /// <param name="dirfile">File chunk</param>
        /// <param name="bytesToModify">File bytes.</param>
        private void DecodeAionBytes(PakCentralDirFile dirfile, byte[] bytesToModify)
        {
            int tbloff = (int)dirfile.compressedSize & 0x3FF;
            for (int i = 0; i < bytesToModify.Length && i < 32; i++)
                bytesToModify[i] ^= PakConstants.table2[tbloff + i];
        }

        /// <summary>
        /// Get a specific file in the PAK.
        /// </summary>
        /// <param name="dirfile">File chunk.</param>
        /// <returns></returns>
        public byte[] ReadFileBytes(PakCentralDirFile dirfile)
        {
            FS.Seek(dirfile.localHeaderOffset, SeekOrigin.Begin);
            var fileheader = PakFileEntry.Read(Reader);

            if (!dirfile.filename.Equals(fileheader.filename, StringComparison.OrdinalIgnoreCase) ||
                dirfile.compressedSize != fileheader.compressedSize ||
                dirfile.uncompressedSize != fileheader.uncompressedSize ||
                dirfile.compressionMethod != fileheader.compressionMethod)
                throw new InvalidOperationException("header mismatch");

            byte[] result;
            if (dirfile.compressionMethod == 0)
            {
                result = Reader.ReadBytes((int)dirfile.compressedSize);
                if (dirfile.isAionFormat)
                    DecodeAionBytes(dirfile, result);
            }
            else if (dirfile.compressionMethod == 8)
            {
                Stream zip = (dirfile.isAionFormat ? new EncryptedAionPakReader(FS, dirfile) : (Stream)FS);
                using (var tmp = new DeflateStream(zip, CompressionMode.Decompress, true))
                {
                    var br = new BinaryReader(tmp);
                    result = br.ReadBytes((int)dirfile.uncompressedSize);
                }
            }
            else
                throw new InvalidOperationException("unsupported compression method");

            return result;
        }

        /// <summary>
        /// List all files in the specified PAK file.
        /// </summary>
        /// <returns></returns>
        public List<PakCentralDirFile> ReadCentralDir()
        {
            var result = new List<PakCentralDirFile>(EO_CentralDir.thisDiskCentralDirCount);
            FS.Seek(EO_CentralDir.centralDirOffset, SeekOrigin.Begin);

            for (int i = 0; i < EO_CentralDir.thisDiskCentralDirCount; i++)
            {
                var dirfile = PakCentralDirFile.Read(Reader);
                result.Add(dirfile);
            }

            return result;
        }

        /// <summary>
        /// Seek PAK to end.
        /// </summary>
        private void ReadCentralDirEnd()
        {
            FS.Seek(-PakCentralDirEnd.HeaderSize, SeekOrigin.End);
            EO_CentralDir = PakCentralDirEnd.Read(Reader);
        }

        /// <summary>
        /// Close the reader.
        /// </summary>
        public void Close()
        {
            Reader?.Close();
            Reader = null;
            FS?.Close();
            FS = null;
        }

        /// <summary>
        /// Release all resources.
        /// </summary>
        public void Dispose() =>
            Close();
    }
}
