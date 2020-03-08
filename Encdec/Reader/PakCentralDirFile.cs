using System;
using System.IO;

namespace Iswenzz.AION.Encdec.Reader
{
    /// <summary>
    /// Represent a file in a PAK archive.
    /// </summary>
    public class PakCentralDirFile
    {
        public bool isAionFormat; // true for aion header, false for zip format

        public ushort signature1;
        public ushort signature2;
        public ushort createVersion;
        public ushort extractVersion;
        public ushort flags;
        public ushort compressionMethod;
        public ushort time;
        public ushort date;
        public uint crc;
        public uint compressedSize;
        public uint uncompressedSize;
        public ushort filenameLength;
        public ushort extraFieldLength;
        public ushort fileCommentLength;
        public ushort diskNumStart;
        public ushort internalFileAttr;
        public uint externalFileAttr;
        public uint localHeaderOffset;

        public string filename;

        /// <summary>
        /// Read the file chunk from specified <see cref="BinaryReader"/>.
        /// </summary>
        /// <param name="br">PAK <see cref="BinaryReader"/></param>
        /// <returns></returns>
        public static PakCentralDirFile Read(BinaryReader br)
        {
            PakCentralDirFile result = new PakCentralDirFile
            {
                signature1 = br.ReadUInt16(),
                signature2 = br.ReadUInt16(),
                createVersion = br.ReadUInt16(),
                extractVersion = br.ReadUInt16(),
                flags = br.ReadUInt16(),
                compressionMethod = br.ReadUInt16(),
                time = br.ReadUInt16(),
                date = br.ReadUInt16(),
                crc = br.ReadUInt32(),
                compressedSize = br.ReadUInt32(),
                uncompressedSize = br.ReadUInt32(),
                filenameLength = br.ReadUInt16(),
                extraFieldLength = br.ReadUInt16(),
                fileCommentLength = br.ReadUInt16(),
                diskNumStart = br.ReadUInt16(),
                internalFileAttr = br.ReadUInt16(),
                externalFileAttr = br.ReadUInt32(),
                localHeaderOffset = br.ReadUInt32()
            };

            result.filename = PakUtil.ReadFilename(br, result.filenameLength);

            if (result.signature1 == PakConstants.PAK_SIGNATURE1 &&
                result.signature2 == PakConstants.PAK_SIGNATURE2_DIR)
                result.isAionFormat = true;
            else
            {
                if (result.signature1 != PakConstants.ZIP_SIGNATURE1 ||
                    result.signature2 != PakConstants.ZIP_SIGNATURE2_DIR)
                    throw new InvalidOperationException("bad central dir signature");
            }
            if (result.extraFieldLength != 0)
                br.ReadBytes(result.extraFieldLength);

            if (result.fileCommentLength != 0)
                throw new InvalidOperationException("file comment not supported");

            if (result.diskNumStart != 0)
                throw new InvalidOperationException("disk num not supported");

            return result;
        }
    }
}
