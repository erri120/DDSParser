using BenchmarkDotNet.Running;
using DDSParser.Benchmark;

BenchmarkRunner.Run<FromFileBenchmarks>();
BenchmarkRunner.Run<FromByteArrayBenchmarks>();
