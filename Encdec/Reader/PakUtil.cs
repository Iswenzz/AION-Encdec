using System.IO;
using System.Text;

namespace Iswenzz.AION.Encdec.Reader
{
    /// <summary>
    /// PAK Utility functions.
    /// </summary>
    public static class PakUtil
    {
        /// <summary>
        /// Normalize the specified path.
        /// </summary>
        /// <param name="originalFilename">File path</param>
        /// <returns></returns>
        public static string NormalizeFilename(string originalFilename) =>
            originalFilename.ToLower().Replace('\\', '/');

        /// <summary>
        /// Get file name from <see cref="BinaryReader"/>.
        /// </summary>
        /// <param name="br">File binaries</param>
        /// <param name="length">File name length</param>
        /// <returns></returns>
        public static string ReadFilename(BinaryReader br, int length) =>
            NormalizeFilename(Encoding.UTF8.GetString(br.ReadBytes(length)));
    }
}
