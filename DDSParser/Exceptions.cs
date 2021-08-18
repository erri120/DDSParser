using System;
using JetBrains.Annotations;

namespace DDSParser
{
    [PublicAPI]
    public class DDSStructSizeMismatchException : Exception
    {
        public DDSStructSizeMismatchException(uint expectedSize, uint actualSize, string structName)
            : base($"Size of struct {nameof(structName)} is not {expectedSize} but {actualSize}") { }
    }
}
