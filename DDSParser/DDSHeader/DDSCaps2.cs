using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace DDSParser
{
    /// <summary>
    /// Additional detail about the surfaces stored.
    /// </summary>
    [Flags]
    [PublicAPI]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    [SuppressMessage("ReSharper", "CommentTypo")]
    public enum DDSCaps2 : uint
    {
        /// <summary>
        /// None.
        /// </summary>
        NONE = 0x0,

        /// <summary>
        /// Required for a cube map.
        /// </summary>
        DDSCAPS2_CUBEMAP = 0x200,

        /// <summary>
        /// Required when these surfaces are stored in a cube map.
        /// </summary>
        DDSCAPS2_CUBEMAP_POSITIVEX = 0x400,

        /// <summary>
        /// Required when these surfaces are stored in a cube map.
        /// </summary>
        DDSCAPS2_CUBEMAP_NEGATIVEX = 0x800,

        /// <summary>
        /// Required when these surfaces are stored in a cube map.
        /// </summary>
        DDSCAPS2_CUBEMAP_POSITIVEY = 0x1000,

        /// <summary>
        /// Required when these surfaces are stored in a cube map.
        /// </summary>
        DDSCAPS2_CUBEMAP_NEGATIVEY = 0x2000,

        /// <summary>
        /// Required when these surfaces are stored in a cube map.
        /// </summary>
        DDSCAPS2_CUBEMAP_POSITIVEZ = 0x4000,

        /// <summary>
        /// Required when these surfaces are stored in a cube map.
        /// </summary>
        DDSCAPS2_CUBEMAP_NEGATIVEZ = 0x8000,

        /// <summary>
        /// Required for a volume texture.
        /// </summary>
        DDSCAPS2_VOLUME = 0x200000
    }
}
