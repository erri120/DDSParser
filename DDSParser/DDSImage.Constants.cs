using System;

namespace DDSParser
{
    public partial class DDSImage
    {
        private const int BufferSizeForHeader = 256;

        /// <summary>
        /// File Magic of .dds files.
        /// </summary>
        public const uint Magic = 0x20534444;

        #region Codec GUIDs

        // ReSharper disable InconsistentNaming

        // <summary>
        // Container Format Guid.
        // </summary>
        //public static readonly Guid GUID_ContainerFormatDds = Guid.Parse("9967cb95-2e85-4ac8-8ca283d7ccd425c9");

        // <summary>
        // Decoder Guid.
        // </summary>
        //public static readonly Guid CLSID_WICDdsDecoder = Guid.Parse("9053699f-a341-429d-9e90ee437cf80c73");

        // <summary>
        // Encoder Guid.
        // </summary>
        //public static readonly Guid CLSID_WICDdsEncoder = Guid.Parse("a61dde94-66ce-4ac1-881b71680588895e");

        // ReSharper restore InconsistentNaming

        #endregion
    }
}
