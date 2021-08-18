using JetBrains.Annotations;

namespace DDSParser
{
    /// <summary>
    /// Describes a DDS file header.
    /// </summary>
    [PublicAPI]
    public struct DDSHeader
    {
        /// <summary>
        /// Size of structure. This member must be set to 124.
        /// </summary>
        public const uint Size = 124;

        /// <summary>
        /// Flags to indicate which members contain valid data.
        /// </summary>
        public DDSHeaderFlags Flags;

        /// <summary>
        /// Surface height (in pixels).
        /// </summary>
        public uint Height;

        /// <summary>
        /// Surface width (in pixels).
        /// </summary>
        public uint Width;

        /// <summary>
        /// The pitch or number of bytes per scan line in an uncompressed texture;
        /// the total number of bytes in the top level texture for a compressed texture.
        /// </summary>
        public uint PitchOrLinearSize;

        /// <summary>
        /// Depth of a volume texture (in pixels), otherwise unused.
        /// </summary>
        public uint Depth;

        /// <summary>
        /// Number of mipmap levels, otherwise unused.
        /// </summary>
        public uint MipMapCount;

        /// <summary>
        /// The pixel format.
        /// </summary>
        public DDSPixelFormat PixelFormat;

        /// <summary>
        /// Specifies the complexity of the surfaces stored.
        /// </summary>
        public DDSCaps Caps;

        /// <summary>
        /// Additional detail about the surfaces stored.
        /// </summary>
        public DDSCaps2 Caps2;
    }
}
