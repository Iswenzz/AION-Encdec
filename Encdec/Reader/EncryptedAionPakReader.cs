using System;
using System.IO;

namespace Iswenzz.AION.Encdec.Reader
{
    /// <summary>
    /// Represent an encrypted PAK reader.
    /// </summary>
    public class EncryptedAionPakReader : Stream
    {
        public override bool CanRead => true;
        public override bool CanSeek => false;
        public override bool CanWrite => false;

        public override long Length => m_dirfile.uncompressedSize;
        public override long Position { get => m_currentPosition; set => throw new NotImplementedException(); }
        public override void Flush() => throw new NotImplementedException();

        Stream m_underlying;
        PakCentralDirFile m_dirfile;
        long m_startPosition;
        long m_currentPosition;

        /// <summary>
        /// Initialize a new <see cref="EncryptedAionPakReader"/> object with the specified stream & PAK file.
        /// </summary>
        /// <param name="stream">PAK stream reader</param>
        /// <param name="dirfile">PAK file</param>
        public EncryptedAionPakReader(Stream stream, PakCentralDirFile dirfile)
        {
            m_underlying = stream;
            m_startPosition = stream.Position;
            m_dirfile = dirfile;

            if (!dirfile.isAionFormat)
                throw new InvalidOperationException("zip stream is not encrypted!");
        }

        /// <summary>
        /// Reads and decode a sequence of bytes from the current stream and advances the position
        /// within the stream by the number of bytes read.
        /// </summary>
        /// <returns></returns>
        public override int Read(byte[] buffer, int offset, int count)
        {
            int bytesRead = 0;
            if (m_currentPosition < 32)
            {
                int tbloff = (int)m_dirfile.compressedSize & 0x3FF;
                while (m_currentPosition < 32 && bytesRead < count)
                {
                    int c = m_underlying.ReadByte();
                    if (c == -1)
                        break;

                    // decode byte
                    byte b = (byte)c;
                    b ^= PakConstants.table2[tbloff + m_currentPosition];

                    buffer[offset + bytesRead] = b;

                    m_currentPosition++;
                    bytesRead++;
                }
                return bytesRead;
            }

            bytesRead = m_underlying.Read(buffer, offset, count);
            m_currentPosition += bytesRead;
            return bytesRead;
        }

        public override long Seek(long offset, SeekOrigin origin) => throw new NotImplementedException();
        public override void SetLength(long value) => throw new NotImplementedException();
        public override void Write(byte[] buffer, int offset, int count) => throw new NotImplementedException();
    }
}
