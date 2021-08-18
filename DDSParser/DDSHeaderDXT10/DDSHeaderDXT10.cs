using JetBrains.Annotations;

namespace DDSParser
{
    [PublicAPI]
    public struct DDSHeaderDXT10
    {
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
