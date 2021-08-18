using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace DDSParser
{
    /// <summary>
    /// Values which indicate what type of data is in the surface.
    /// </summary>
    [Flags]
    [PublicAPI]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    public enum DDSPixelFormatFlags : uint
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0x0,

        /// <summary>
        /// Texture contains alpha data; <see cref="DDSPixelFormat.ABitMask"/> contains valid data.
        /// </summary>
        DDPF_ALPHAPIXELS = 0x1,

        /// <summary>
        /// Used in some older DDS files for alpha channel only uncompressed data
        /// (<see cref="DDSPixelFormat.RGBBitCount"/> contains the alpha channel bitcount;
        /// <see cref="DDSPixelFormat.ABitMask"/> contains valid data)
        /// </summary>
        DDPF_ALPHA = 0x2,

        /// <summary>
        /// Texture contains compressed RGB data; <see cref="DDSPixelFormat.CharacterCode"/> contains valid data.
        /// </summary>
        DDPF_FOURCC = 0x4,

        /// <summary>
        /// Texture contains uncompressed RGB data; <see cref="DDSPixelFormat.RGBBitCount"/> and the RGB masks
        /// (<see cref="DDSPixelFormat.RBitMask"/>,
        /// <see cref="DDSPixelFormat.GBitMask"/>,
        /// <see cref="DDSPixelFormat.BBitMask"/>)
        /// contain valid data.
        /// </summary>
        DDPF_RGB = 0x40,

        /// <summary>
        /// Used in some older DDS files for YUV uncompressed data (<see cref="DDSPixelFormat.RGBBitCount"/>
        /// contains the YUV bit count;
        /// <see cref="DDSPixelFormat.RBitMask"/> contains the Y mask,
        /// <see cref="DDSPixelFormat.GBitMask"/> contains the U mask,
        /// <see cref="DDSPixelFormat.BBitMask"/> contains the V mask)
        /// </summary>
        DDPF_YUV = 0x200,

        /// <summary>
        /// Used in some older DDS files for single channel color uncompressed data
        /// (<see cref="DDSPixelFormat.RGBBitCount"/> contains the luminance channel bit count;
        /// <see cref="DDSPixelFormat.RBitMask"/> contains the channel mask).
        /// Can be combined with <see cref="DDPF_ALPHAPIXELS"/> for a two channel DDS file.
        /// </summary>
        DDPF_LUMINANCE = 0x20000,
    }
}
