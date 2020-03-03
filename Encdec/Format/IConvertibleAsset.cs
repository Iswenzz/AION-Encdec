namespace Iswenzz.AION.Encdec.Format
{
    /// <summary>
    /// Represent a convertible asset.
    /// </summary>
    public interface IConvertibleAsset
    {
        /// <summary>
        /// Encode an asset.
        /// </summary>
        void Encode();

        /// <summary>
        /// Decode an asset.
        /// </summary>
        void Decode();
    }
}
