using System;
using JetBrains.Annotations;

namespace DDSParser
{
    /// <summary>
    /// The exception that is thrown when the expected size is not present in the DDS file for a specific struct.
    /// </summary>
    [PublicAPI]
    public class DDSStructSizeMismatchException : Exception
    {
#pragma warning disable 1591
        public DDSStructSizeMismatchException(uint expectedSize, uint actualSize, string structName)
            : base($"Size of struct {nameof(structName)} is not {expectedSize} but {actualSize}") { }
#pragma warning restore 1591
    }
}
