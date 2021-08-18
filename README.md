# DDSParser

Library for parsing `.dds` (DirectDraw Surface) files as defined in the [Programming Guide for DDS](https://docs.microsoft.com/en-us/windows/win32/direct3ddds/dx-graphics-dds-pguide) by Microsoft. This library is not for image manipulation, conversion on any other operations on the data contained in DDS files. It only parses the header(s) and provides access to all information inside the DDS file.

## Usage

The constructors of `DDSParser.DDSImage` provide overloads for multiple different scenarios:

```c#
using DDSParser;

// using a path
var ddsImage = new DDSImage("path/to/file.dds");

// using System.IO.FileInfo
var ddsImage = new DDSImage(new System.IO.FileInfo("path/to/file.dds"));

// using a Stream (has to be readable and seekable)
using Stream stream = //...
var ddsImage = new DDSImage(stream);

// using a byte array
byte[] buffer = //...
var ddsImage = new DDSImage(buffer);
```

## Benchmarks

See [DDSParser.Benchmark](DDSParser.Benchmark) for the code. My setup:

``` ini
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1165 (21H1/May2021Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT
```

The following libraries are used during the benchmark:

- [hguy/dds-reader](https://github.com/hguy/dds-reader)
- [rds1983/DdsKtxSharp](https://github.com/rds1983/DdsKtxSharp)

### From File

|                          Method |        Mean |     Error |    StdDev |  Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|-------------------------------- |------------:|----------:|----------:|-------:|--------:|---------:|---------:|---------:|----------:|
| &#39;erri120/DDSParser (from file)&#39; |    33.30 μs |  0.300 μs |  0.281 μs |   1.00 |    0.00 |   0.2441 |   0.1221 |        - |      1 KB |
|   &#39;hguy/dds-reader (from file)&#39; | 3,624.60 μs | 17.038 μs | 14.227 μs | 108.76 |    1.12 | 347.6563 | 335.9375 | 332.0313 |  3,137 KB |


### From Byte Array

|                                  Method |            Mean |         Error |        StdDev |     Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 |   Allocated |
|---------------------------------------- |----------------:|--------------:|--------------:|----------:|--------:|---------:|---------:|---------:|------------:|
|   &#39;erri120/DDSParser (from byte array)&#39; |        51.57 ns |      0.541 ns |      0.506 ns |      1.00 |    0.00 |   0.0325 |        - |        - |       136 B |
|     &#39;hguy/dds-reader (from byte array)&#39; | 3,266,217.24 ns | 18,058.809 ns | 16,892.221 ns | 63,339.10 |  862.17 | 328.1250 | 328.1250 | 328.1250 | 3,146,425 B |
| &#39;rds1983/DdsKtxSharp (from byte array)&#39; |       117.79 ns |      0.969 ns |      0.907 ns |      2.28 |    0.03 |   0.0172 |        - |        - |        72 B |
