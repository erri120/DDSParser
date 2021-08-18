using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace DDSParser
{
    /// <summary>
    /// Identifies other, less common options for resources.
    /// </summary>
    [PublicAPI]
    [Flags]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    public enum DDSResourceMiscFlag : uint
    {
        DDS_RESOURCE_MISC_TEXTURECUBE = 0x4,
    }
}
