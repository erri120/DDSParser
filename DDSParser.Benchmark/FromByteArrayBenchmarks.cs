using System;
using System.IO;
using BenchmarkDotNet.Attributes;

namespace DDSParser.Benchmark
{
    [MemoryDiagnoser]
    public class FromByteArrayBenchmarks
    {
        private readonly byte[] _data;

        public FromByteArrayBenchmarks()
        {
            const string file = "files/DXT1.dds";
            if (!File.Exists(file))
                throw new NotImplementedException();

            _data = File.ReadAllBytes(file);
        }

        [Benchmark(Baseline = true, Description = "erri120/DDSParser (from byte array)")]
        public DDSImage UsingOwnMethodFromByteArray()
        {
            return new DDSImage(_data);
        }

        [Benchmark(Description = "hguy/dds-reader (from byte array)")]
        public DDSReader.DDSImage UsingDDSReaderFromByteArray()
        {
            return new DDSReader.DDSImage(_data);
        }

        [Benchmark(Description = "rds1983/DdsKtxSharp (from byte array)")]
        public DdsKtxSharp.DdsKtxParser UsingDdsKtxSharpFromByteArray()
        {
            return DdsKtxSharp.DdsKtxParser.FromMemory(_data);
        }
    }
}
