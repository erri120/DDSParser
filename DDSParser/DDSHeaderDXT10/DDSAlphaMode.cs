using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace DDSParser
{
    /// <summary>
    /// Contains additional metadata (formerly was reserved).
    /// The lower 3 bits indicate the alpha mode of the associated resource. The upper 29 bits are reserved and are typically 0.
    /// </summary>
    [PublicAPI]
    [Flags]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum DDSAlphaMode : uint
    {
        /// <summary>
        /// Alpha channel content is unknown. This is the value for legacy files, which typically is assumed to be 'straight' alpha.
        /// </summary>
        DDS_ALPHA_MODE_UNKNOWN = 0x0,

        /// <summary>
        /// Any alpha channel content is presumed to use straight alpha.
        /// </summary>
        DDS_ALPHA_MODE_STRAIGHT = 0x1,

        /// <summary>
        /// Any alpha channel content is using premultiplied alpha.
        /// The only legacy file formats that indicate this information are 'DX2' and 'DX4'.
        /// </summary>
        DDS_ALPHA_MODE_PREMULTIPLIED = 0x2,

        /// <summary>
        /// Any alpha channel content is all set to fully opaque.
        /// </summary>
        DDS_ALPHA_MODE_OPAQUE = 0x3,

        /// <summary>
        /// Any alpha channel content is being used as a 4th channel and is not intended to represent transparency (straight or premultiplied).
        /// </summary>
        DDS_ALPHA_MODE_CUSTOM = 0x4
    }
}
