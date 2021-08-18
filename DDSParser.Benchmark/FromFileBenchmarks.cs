using System;
using System.IO;
using BenchmarkDotNet.Attributes;

namespace DDSParser.Benchmark
{
    [MemoryDiagnoser]
    public class FromFileBenchmarks
    {
        private readonly string _testFile;
        //private readonly byte[] _data;

        public FromFileBenchmarks()
        {
            _testFile = "files/DXT1.dds";
            if (!File.Exists(_testFile))
                throw new NotImplementedException();
        }

        [Benchmark(Baseline = true, Description = "erri120/DDSParser (from file)")]
        public DDSImage UsingOwnMethodFromFile()
        {
            return new DDSImage(_testFile);
        }

        [Benchmark(Description = "hguy/dds-reader (from file)")]
        public DDSReader.DDSImage UsingDDSReaderFromFile()
        {
            return new DDSReader.DDSImage(_testFile);
        }
    }
}
