using System;
using System.Buffers.Binary;
using System.IO;
using BinaryShenanigans.Reader;
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
        /// Position of the data after the header(s).
        /// </summary>
        public int DataPosition => (int)(DDSHeader.Size + (HeaderDXT10 == null ? 0 : DDSHeaderDXT10.Size));

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
            ParseHeader(new ReadOnlySpan<byte>(data, 0, Math.Min(data.Length, BufferSizeForHeader)));
        }

        /// <summary>
        /// Loads the DDS file from a ReadOnlySpan.
        /// </summary>
        /// <param name="data"></param>
        public DDSImage(ReadOnlySpan<byte> data)
        {
            ParseHeader(data);
        }

        private void ParseHeader(ReadOnlySpan<byte> data)
        {
            var reader = new SpanReader(0, data.Length);

            var magic = reader.ReadUInt32(data);
            if (magic != Magic)
                throw new InvalidDataException($"Invalid magic number for DDS Stream: 0x{magic:X} instead of 0x{Magic:X}");

            Header = ParseDDSHeader(reader, data);

            if (Header.PixelFormat.CharacterCode == DDSPixelFormatCharacterCode.DX10)
                HeaderDXT10 = ParseDXT10Header(reader, data);
        }

        private static DDSHeader ParseDDSHeader(SpanReader reader, ReadOnlySpan<byte> data)
        {
            var dwSize = reader.ReadUInt32(data);
            if (dwSize != DDSHeader.Size)
                throw new DDSStructSizeMismatchException(DDSHeader.Size, dwSize, nameof(DDSHeader));

            var header = new DDSHeader();

            var dwFlags = (DDSHeaderFlags)reader.ReadUInt32(data);
            header.Flags = dwFlags;

            header.Height = reader.ReadUInt32(data);
            header.Width = reader.ReadUInt32(data);
            header.PitchOrLinearSize = reader.ReadUInt32(data);
            header.Depth = reader.ReadUInt32(data);
            header.MipMapCount = reader.ReadUInt32(data);

            // dwReserved1[11]
            reader.SkipBytes(sizeof(uint) * 11);

            header.PixelFormat = ParseDDSPixelFormat(reader, data);

            header.Caps = (DDSCaps)reader.ReadUInt32(data);
            header.Caps2 = (DDSCaps2)reader.ReadUInt32(data);

            // dwCaps3
            reader.SkipBytes(sizeof(uint));
            // dwCaps4
            reader.SkipBytes(sizeof(uint));
            // dwReserved2
            reader.SkipBytes(sizeof(uint));

            return header;
        }

        private static DDSPixelFormat ParseDDSPixelFormat(SpanReader reader, ReadOnlySpan<byte> data)
        {
            var dwSize = reader.ReadUInt32(data);
            if (dwSize != DDSPixelFormat.Size)
                throw new DDSStructSizeMismatchException(DDSPixelFormat.Size, dwSize, nameof(DDSPixelFormat));

            var pixelFormat = new DDSPixelFormat();

            var dwFlags = (DDSPixelFormatFlags)reader.ReadUInt32(data);
            pixelFormat.Flags = dwFlags;
            pixelFormat.CharacterCode = (DDSPixelFormatCharacterCode)reader.ReadUInt32(data);
            pixelFormat.RGBBitCount = reader.ReadUInt32(data);
            pixelFormat.RBitMask = reader.ReadUInt32(data);
            pixelFormat.GBitMask = reader.ReadUInt32(data);
            pixelFormat.BBitMask = reader.ReadUInt32(data);
            pixelFormat.ABitMask = reader.ReadUInt32(data);

            return pixelFormat;
        }

        private static DDSHeaderDXT10 ParseDXT10Header(SpanReader reader, ReadOnlySpan<byte> data)
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var header = new DDSHeaderDXT10();
            header.Format = (DXGIFormat)reader.ReadUInt32(data);
            header.ResourceDimension = (DDSResourceDimension)reader.ReadUInt32(data);
            header.MiscFlag = (DDSResourceMiscFlag)reader.ReadUInt32(data);
            header.ArraySize = reader.ReadUInt32(data);
            header.AlphaMode = (DDSAlphaMode)reader.ReadUInt32(data);

            return header;
        }
    }
}
