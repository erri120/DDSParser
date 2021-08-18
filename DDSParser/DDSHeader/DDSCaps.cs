using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace DDSParser
{
    /// <summary>
    /// Specifies the complexity of the surfaces stored.
    /// </summary>
    [Flags]
    [PublicAPI]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    [SuppressMessage("ReSharper", "CommentTypo")]
    public enum DDSCaps : uint
    {
        /// <summary>
        /// None.
        /// </summary>
        NONE = 0x0,

        /// <summary>
        /// Optional; must be used on any file that contains more than one surface
        /// (a mipmap, a cubic environment map, or mipmapped volume texture).
        /// </summary>
        DDSCAPS_COMPLEX = 0x8,

        /// <summary>
        /// Optional; should be used for a mipmap.
        /// </summary>
        DDSCAPS_MIPMAP = 0x400000,

        /// <summary>
        /// Required.
        /// </summary>
        DDSCAPS_TEXTURE = 0x1000
    }
}
