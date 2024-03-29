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
| &#39;erri120/DDSParser (from file)&#39; |    33.85 μs |  0.534 μs |  0.446 μs |   1.00 |    0.00 |   0.2441 |   0.1221 |        - |      1 KB |
|   &#39;hguy/dds-reader (from file)&#39; | 3,838.88 μs | 46.158 μs | 38.544 μs | 113.44 |    2.34 | 410.1563 | 402.3438 | 394.5313 |  3,138 KB |

### From Byte Array

|                                  Method |            Mean |         Error |         StdDev |     Ratio |  RatioSD |    Gen 0 |    Gen 1 |    Gen 2 |   Allocated |
|---------------------------------------- |----------------:|--------------:|---------------:|----------:|---------:|---------:|---------:|---------:|------------:|
|   &#39;erri120/DDSParser (from byte array)&#39; |        48.72 ns |      1.041 ns |       2.573 ns |      1.00 |     0.00 |   0.0325 |        - |        - |       136 B |
|     &#39;hguy/dds-reader (from byte array)&#39; | 3,869,484.69 ns | 76,250.566 ns | 157,470.641 ns | 79,168.65 | 5,419.10 | 320.3125 | 320.3125 | 320.3125 | 3,146,440 B |
| &#39;rds1983/DdsKtxSharp (from byte array)&#39; |       113.09 ns |      0.919 ns |       1.021 ns |      2.39 |     0.09 |   0.0172 |        - |        - |        72 B |
