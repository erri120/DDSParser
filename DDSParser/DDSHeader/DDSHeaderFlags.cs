using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace DDSParser
{
    /// <summary>
    /// Flags to indicate which members contain valid data.
    /// </summary>
    [Flags]
    [PublicAPI]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    [SuppressMessage("ReSharper", "CommentTypo")]
    public enum DDSHeaderFlags : uint
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0x0,

        /// <summary>
        /// Required in every .dds file.
        /// </summary>
        DDSD_CAPS = 0x1,

        /// <summary>
        /// Required in every .dds file.
        /// </summary>
        DDSD_HEIGHT = 0x2,

        /// <summary>
        /// Required in every .dds file.
        /// </summary>
        DDSD_WIDTH = 0x4,

        /// <summary>
        /// Required when pitch is provided for an uncompressed texture.
        /// </summary>
        DDSD_PITCH = 0x8,

        /// <summary>
        /// Required in every .dds file.
        /// </summary>
        DDSD_PIXELFORMAT = 0x1000,

        /// <summary>
        /// Required in a mipmapped texture.
        /// </summary>
        DDSD_MIPMAPCOUNT = 0x20000,

        /// <summary>
        /// Required when pitch is provided for a compressed texture.
        /// </summary>
        DDSD_LINEARSIZE = 0x80000,

        /// <summary>
        /// Required in a depth texture.
        /// </summary>
        DDSD_DEPTH = 0x800000
    }
}
