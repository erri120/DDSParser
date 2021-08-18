using JetBrains.Annotations;

namespace DDSParser
{
    [PublicAPI]
    public struct DDSPixelFormat
    {
        /// <summary>
        /// Structure size; set to 32 (bytes).
        /// </summary>
        public const uint Size = 32;

        /// <summary>
        /// Values which indicate what type of data is in the surface.
        /// </summary>
        public DDSPixelFormatFlags Flags;

        /// <summary>
        /// Four-character codes for specifying compressed or custom formats.
        /// </summary>
        public DDSPixelFormatCharacterCode CharacterCode;

        /// <summary>
        /// Number of bits in an RGB (possibly including alpha) format.
        /// Valid when <see cref="Flags"/> includes <see cref="DDSPixelFormatFlags.DDPF_RGB"/>,
        /// <see cref="DDSPixelFormatFlags.DDPF_LUMINANCE"/>, or <see cref="DDSPixelFormatFlags.DDPF_YUV"/>.
        /// </summary>
        public uint RGBBitCount;

        /// <summary>
        /// Red (or luminance or Y) mask for reading color data. For instance, given the <c>A8R8G8B8</c> format,
        /// the red mask would be <c>0x00ff0000</c>.
        /// </summary>
        public uint RBitMask;

        /// <summary>
        /// Green (or U) mask for reading color data. For instance, given the <c>A8R8G8B8</c> format,
        /// the green mask would be <c>0x0000ff00</c>.
        /// </summary>
        public uint GBitMask;

        /// <summary>
        /// Blue (or V) mask for reading color data. For instance, given the <c>A8R8G8B8</c> format,
        /// the blue mask would be <c>0x000000ff</c>.
        /// </summary>
        public uint BBitMask;

        /// <summary>
        /// Alpha mask for reading alpha data. <see cref="Flags"/> must include <see cref="DDSPixelFormatFlags.DDPF_ALPHAPIXELS"/>
        /// or <see cref="DDSPixelFormatFlags.DDPF_ALPHA"/>. For instance, given the <c>A8R8G8B8</c> format,
        /// the alpha mask would be <c>0xff000000</c>.
        /// </summary>
        public uint ABitMask;
    }
}
