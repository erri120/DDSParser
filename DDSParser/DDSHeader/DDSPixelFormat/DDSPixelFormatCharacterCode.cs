using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace DDSParser
{
    /// <summary>
    /// Four-character codes for specifying compressed or custom formats.
    /// </summary>
    [PublicAPI]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "CommentTypo")]
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    public enum DDSPixelFormatCharacterCode : uint
    {
        /// <summary>
        /// Texture is not compressed.
        /// </summary>
        None = 0x0,

        /// <summary>
        /// DXGI_FORMAT_BC1_UNORM<br/>
        /// D3DFMT_DXT1
        /// </summary>
        DXT1 = 0x31545844,

        /// <summary>
        /// D3DFMT_DXT2
        /// </summary>
        DXT2 = 0x32545844,

        /// <summary>
        /// DXGI_FORMAT_BC2_UNORM<br/>
        /// D3DFMT_DXT3
        /// </summary>
        DXT3 = 0x33545844,

        /// <summary>
        /// D3DFMT_DXT4
        /// </summary>
        DXT4 = 0x34545844,

        /// <summary>
        /// DXGI_FORMAT_BC3_UNORM<br/>
        /// D3DFMT_DXT5
        /// </summary>
        DXT5 = 0x35545844,

        /// <summary>
        /// Any DXGI format.
        /// </summary>
        DX10 = 0x30315844,

        /// <summary>
        /// DXGI_FORMAT_BC4_UNORM
        /// </summary>
        BC4U = 0x55344342,

        /// <summary>
        /// DXGI_FORMAT_BC4_SNORM
        /// </summary>
        BC4S = 0x53344342,

        /// <summary>
        /// DXGI_FORMAT_BC5_UNORM
        /// </summary>
        BC5U = 0x55354342,

        /// <summary>
        /// DXGI_FORMAT_BC5_SNORM
        /// </summary>
        BC5S = 0x53354342,

        /// <summary>
        /// ATI2
        /// </summary>
        ATI2 = 0x32495441,

        /// <summary>
        /// DXGI_FORMAT_R8G8_B8G8_UNORM<br/>
        /// D3DFMT_R8G8_B8G8
        /// </summary>
        RGBG = 0x47424752,

        /// <summary>
        /// DXGI_FORMAT_G8R8_G8B8_UNORM<br/>
        /// D3DFMT_G8R8_G8B8
        /// </summary>
        GRGB = 0x42475247,

        /// <summary>
        /// D3DFMT_YUY2
        /// </summary>
        YUY2 = 0x32595559,

        /// <summary>
        /// D3DFMT_UYVY
        /// </summary>
        UYUY = 0x59555955,

        /// <summary>
        /// DXGI_FORMAT_R16G16B16A16_UNORM<br/>
        /// D3DFMT_A16B16G16R16
        /// </summary>
        DXGI_FORMAT_R16G16B16A16_UNORM = 36,

        /// <summary>
        /// DXGI_FORMAT_R16G16B16A16_SNORM<br/>
        /// D3DFMT_Q16W16V16U16
        /// </summary>
        DXGI_FORMAT_R16G16B16A16_SNORM = 110,

        /// <summary>
        /// DXGI_FORMAT_R16_FLOAT<br/>
        /// D3DFMT_R16F
        /// </summary>
        DXGI_FORMAT_R16_FLOAT = 111,

        /// <summary>
        /// DXGI_FORMAT_R16G16_FLOAT<br/>
        /// D3DFMT_G16R16F
        /// </summary>
        DXGI_FORMAT_R16G16_FLOAT = 112,

        /// <summary>
        /// DXGI_FORMAT_R16G16B16A16_FLOAT<br/>
        /// D3DFMT_A16B16G16R16F
        /// </summary>
        DXGI_FORMAT_R16G16B16A16_FLOAT = 113,

        /// <summary>
        /// DXGI_FORMAT_R32_FLOAT<br/>
        /// D3DFMT_R32F
        /// </summary>
        DXGI_FORMAT_R32_FLOAT = 114,

        /// <summary>
        /// DXGI_FORMAT_R32G32_FLOAT<br/>
        /// D3DFMT_G32R32F
        /// </summary>
        DXGI_FORMAT_R32G32_FLOAT = 115,

        /// <summary>
        /// DXGI_FORMAT_R32G32B32A32_FLOAT<br/>
        /// D3DFMT_A32B32G32R32F
        /// </summary>
        DXGI_FORMAT_R32G32B32A32_FLOAT = 116,

        /// <summary>
        /// D3DFMT_CxV8U8
        /// </summary>
        D3DFMT_CxV8U8 = 117
    }
}
