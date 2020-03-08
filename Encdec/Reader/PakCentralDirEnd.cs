using System;
using System.IO;

namespace Iswenzz.AION.Encdec.Reader
{
    /// <summary>
    /// Represent a PAK File
    /// </summary>
    public class PakCentralDirEnd
    {
        public const int HeaderSize = 22;

        public ushort signature1;
        public ushort signature2;
        public ushort diskNum;
        public ushort firstDisk;
        public ushort thisDiskCentralDirCount;
        public ushort totalCentralDirCount;
        public uint centralDirSize;
        public uint centralDirOffset;
        public ushort commentLength;

        /// <summary>
        /// Read PAK from specified <see cref="BinaryReader"/>.
        /// </summary>
        /// <param name="br">PAK <see cref="BinaryReader"/></param>
        /// <returns></returns>
        public static PakCentralDirEnd Read(BinaryReader br)
        {
            var result = new PakCentralDirEnd
            {
                signature1 = br.ReadUInt16(),
                signature2 = br.ReadUInt16(),
                diskNum = br.ReadUInt16(),
                firstDisk = br.ReadUInt16(),
                thisDiskCentralDirCount = br.ReadUInt16(),
                totalCentralDirCount = br.ReadUInt16(),
                centralDirSize = br.ReadUInt32(),
                centralDirOffset = br.ReadUInt32(),
                commentLength = br.ReadUInt16()
            };

            if (result.signature1 != PakConstants.PAK_SIGNATURE1 ||
                result.signature2 != PakConstants.PAK_SIGNATURE2_END)
            {
                if (result.signature1 != PakConstants.ZIP_SIGNATURE1 ||
                    result.signature2 != PakConstants.ZIP_SIGNATURE2_END)
                    throw new InvalidOperationException("bad EOCD signature");
            }

            if (result.diskNum != 0)
                throw new InvalidOperationException("expected disk 0. multi disk not supported");

            if (result.thisDiskCentralDirCount == 0)
                throw new InvalidOperationException("unexpected empty dir count");

            if (result.thisDiskCentralDirCount != result.totalCentralDirCount)
                throw new InvalidOperationException("expected matching counts");

            return result;
        }
    }
}
