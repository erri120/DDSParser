using System;
using System.IO;
using JetBrains.Annotations;

namespace DDSParser
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/windows/win32/direct3ddds/dx-graphics-dds-pguide
    /// </summary>
    [PublicAPI]
    public partial class DDSImage
    {
        /// <summary>
        /// Describes a DDS file header.
        /// </summary>
        public DDSHeader Header { get; private set; }

        /// <summary>
        /// Optional DXT10 Header if <see cref="DDSPixelFormat.CharacterCode"/> equals <see cref="DDSPixelFormatCharacterCode.DX10"/>.
        /// </summary>
        public DDSHeaderDXT10? HeaderDXT10 { get; private set; }

        /// <summary>
        /// Loads the DDS file from a path.
        /// </summary>
        /// <param name="path">The file to load.</param>
        /// <exception cref="FileNotFoundException">The file specified in <paramref name="path"/> does not exist.</exception>
        public DDSImage(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("File does not exist!", path);

            using var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read,
                BufferSizeForHeader, FileOptions.SequentialScan);

            var buffer = new byte[Math.Min(fs.Length, BufferSizeForHeader)];
            fs.Read(buffer);

            ParseHeader(buffer);
        }

        /// <summary>
        /// Loads the DDS file from a <see cref="FileInfo"/>.
        /// </summary>
        /// <param name="file">The FileInfo of the file to load.</param>
        /// <exception cref="FileNotFoundException">The file specified in <paramref name="file"/> does not exist.</exception>
        public DDSImage(FileInfo file)
        {
            if (!file.Exists)
                throw new FileNotFoundException("File does not exist!", file.FullName);

            using var fs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read, FileShare.Read,
                BufferSizeForHeader, FileOptions.SequentialScan);

            var buffer = new byte[Math.Min(fs.Length, BufferSizeForHeader)];
            fs.Read(buffer);

            ParseHeader(buffer);
        }

        /// <summary>
        /// Loads the DDS file from a <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The Stream with the contents of the DDS file.</param>
        /// <exception cref="NotSupportedException">The Stream does not support reading or seeking.</exception>
        public DDSImage(Stream stream)
        {
            if (!stream.CanRead)
                throw new NotSupportedException("The provided Stream does not support reading!");
            if (!stream.CanSeek)
                throw new NotSupportedException("The provided Stream does not support seeking!");

            var buffer = new byte[Math.Min(stream.Length, BufferSizeForHeader)];
            stream.Read(buffer);

            ParseHeader(buffer);
        }

        /// <summary>
        /// Loads the DDS file from a raw byte array.
        /// </summary>
        /// <param name="data">Data of the DDS file.</param>
        public DDSImage(byte[] data)
        {
            //using var ms = new MemoryStream(data, 0, Math.Min(BufferSizeForHeader, data.Length), false);
            ParseHeader(data);
        }

        private void ParseHeader(byte[] buffer)
        {
            var reader = new BinaryBufferReader(buffer);
            //using var br = new BinaryReader(stream, Encoding.UTF8, true);

            var magic = reader.ReadUInt32();
            if (magic != Magic)
                throw new InvalidDataException($"Invalid magic number for DDS Stream: 0x{magic:X} instead of 0x{Magic:X}");

            Header = ParseDDSHeader(reader);

            if (Header.PixelFormat.CharacterCode == DDSPixelFormatCharacterCode.DX10)
                HeaderDXT10 = ParseDXT10Header(reader);
        }

        private static DDSHeader ParseDDSHeader(BinaryBufferReader reader)
        {
            var dwSize = reader.ReadUInt32();
            if (dwSize != DDSHeader.Size)
                throw new DDSStructSizeMismatchException(DDSHeader.Size, dwSize, nameof(DDSHeader));

            var header = new DDSHeader();

            var dwFlags = (DDSHeaderFlags)reader.ReadUInt32();
            header.Flags = dwFlags;

            header.Height = reader.ReadUInt32();
            header.Width = reader.ReadUInt32();
            header.PitchOrLinearSize = reader.ReadUInt32();
            header.Depth = reader.ReadUInt32();
            header.MipMapCount = reader.ReadUInt32();

            // dwReserved1[11]
            reader.SkipBytes(sizeof(uint) * 11);

            header.PixelFormat = ParseDDSPixelFormat(reader);

            header.Caps = (DDSCaps)reader.ReadUInt32();
            header.Caps2 = (DDSCaps2)reader.ReadUInt32();

            // dwCaps3
            reader.SkipBytes(sizeof(uint));
            // dwCaps4
            reader.SkipBytes(sizeof(uint));
            // dwReserved2
            reader.SkipBytes(sizeof(uint));

            return header;
        }

        private static DDSPixelFormat ParseDDSPixelFormat(BinaryBufferReader reader)
        {
            var dwSize = reader.ReadUInt32();
            if (dwSize != DDSPixelFormat.Size)
                throw new DDSStructSizeMismatchException(DDSPixelFormat.Size, dwSize, nameof(DDSPixelFormat));

            var pixelFormat = new DDSPixelFormat();

            var dwFlags = (DDSPixelFormatFlags)reader.ReadUInt32();
            pixelFormat.Flags = dwFlags;
            pixelFormat.CharacterCode = (DDSPixelFormatCharacterCode)reader.ReadUInt32();
            pixelFormat.RGBBitCount = reader.ReadUInt32();
            pixelFormat.RBitMask = reader.ReadUInt32();
            pixelFormat.GBitMask = reader.ReadUInt32();
            pixelFormat.BBitMask = reader.ReadUInt32();
            pixelFormat.ABitMask = reader.ReadUInt32();

            return pixelFormat;
        }

        private static DDSHeaderDXT10 ParseDXT10Header(BinaryBufferReader reader)
        {
            var header = new DDSHeaderDXT10
            {
                Format = (DXGIFormat)reader.ReadUInt32(),
                ResourceDimension = (DDSResourceDimension)reader.ReadUInt32(),
                MiscFlag = (DDSResourceMiscFlag)reader.ReadUInt32(),
                ArraySize = reader.ReadUInt32(),
                AlphaMode = (DDSAlphaMode)reader.ReadUInt32()
            };

            return header;
        }
    }
}
