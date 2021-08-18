using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace DDSParser
{
    /// <summary>
    /// Identifies the type of resource.
    /// </summary>
    [PublicAPI]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum DDSResourceDimension : uint
    {
#pragma warning disable 1591
        DDS_DIMENSION_UNKNOWN = 0,
        DDS_DIMENSION_BUFFER = 1,
        DDS_DIMENSION_TEXTURE1D = 2,
        DDS_DIMENSION_TEXTURE2D = 3,
        DDS_DIMENSION_TEXTURE3D = 4
#pragma warning restore 1591
    }
}
