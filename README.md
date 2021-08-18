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
| &#39;erri120/DDSParser (from file)&#39; |    34.14 μs |  0.255 μs |  0.213 μs |   1.00 |    0.00 |   0.2441 |   0.1221 |        - |      1 KB |
|   &#39;hguy/dds-reader (from file)&#39; | 3,681.00 μs | 18.370 μs | 15.340 μs | 107.83 |    0.74 | 347.6563 | 335.9375 | 332.0313 |  3,138 KB |

### From Byte Array

|                                  Method |            Mean |         Error |        StdDev |     Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 |   Allocated |
|---------------------------------------- |----------------:|--------------:|--------------:|----------:|--------:|---------:|---------:|---------:|------------:|
|   &#39;erri120/DDSParser (from byte array)&#39; |        46.26 ns |      0.579 ns |      0.542 ns |      1.00 |    0.00 |   0.0325 |        - |        - |       136 B |
|     &#39;hguy/dds-reader (from byte array)&#39; | 3,253,907.95 ns | 12,487.940 ns | 11,070.233 ns | 70,275.00 |  765.56 | 328.1250 | 328.1250 | 328.1250 | 3,146,440 B |
| &#39;rds1983/DdsKtxSharp (from byte array)&#39; |       120.09 ns |      0.489 ns |      0.434 ns |      2.59 |    0.03 |   0.0172 |        - |        - |        72 B |
