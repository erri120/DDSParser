using System;
using System.Buffers.Binary;

namespace DDSParser
{
    internal class BinaryBufferReader
    {
        private readonly byte[] _data;
        private int _pos;

        public BinaryBufferReader(byte[] data)
        {
            _data = data;
            _pos = 0;
        }

        public uint ReadUInt32() => BinaryPrimitives.ReadUInt32LittleEndian(GetSpan(sizeof(uint)));

        public void SkipBytes(int count)
        {
            _pos += count;
        }

        private ReadOnlySpan<byte> GetSpan(int size)
        {
            var span = _data.AsSpan(_pos, _pos + size);
            _pos += size;

            return span;
        }
    }
}
