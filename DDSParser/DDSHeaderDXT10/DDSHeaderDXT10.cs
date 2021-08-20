using JetBrains.Annotations;

namespace DDSParser
{
    /// <summary>
    /// Optional DXT10 Header if <see cref="DDSPixelFormat.CharacterCode"/> equals <see cref="DDSPixelFormatCharacterCode.DX10"/>.
    /// </summary>
    [PublicAPI]
    public struct DDSHeaderDXT10
    {
        internal const uint Size = 5 * sizeof(uint);

        /// <summary>
        /// The surface pixel format.
        /// </summary>
        public DXGIFormat Format;

        /// <summary>
        /// Identifies the type of resource.
        /// </summary>
        public DDSResourceDimension ResourceDimension;

        /// <summary>
        /// Identifies other, less common options for resources.
        /// </summary>
        public DDSResourceMiscFlag MiscFlag;

        /// <summary>
        /// The number of elements in the array.
        /// </summary>
        public uint ArraySize;

        /// <summary>
        /// Contains additional metadata (formerly was reserved).
        /// The lower 3 bits indicate the alpha mode of the associated resource. The upper 29 bits are reserved and are typically 0.
        /// </summary>
        public DDSAlphaMode AlphaMode;
    }
}
