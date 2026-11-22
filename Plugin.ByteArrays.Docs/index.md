# 🗂️ Plugin.ByteArrays Documentation

Welcome to the **Plugin.ByteArrays** documentation! This library provides a comprehensive set of utilities for working with byte arrays in .NET applications, designed for performance, safety, and ease of use.

---

## 🚀 Quick Start

### Installation

```bash
# Install from NuGet
dotnet add package Plugin.ByteArrays
```

### Basic Usage

```csharp
using Plugin.ByteArrays;

// Build byte arrays fluently
using var builder = new ByteArrayBuilder();
byte[] data = builder
    .Append((byte)0x01)       // 1 byte
    .AppendUtf8String("Hello")
    .Append(42)               // int: 4 bytes
    .ToByteArray();

// Read primitives from byte arrays
var position = 0;
byte flag = data.ToByte(ref position);
string text = data.ToUtf8String(ref position, 5);
int number = data.ToInt32(ref position);

// Safe array operations
byte[] slice = data.SafeSlice(1, 3);
byte[] trimmed = data.TrimEndNonDestructive();
```

### Modern High-Performance Usage (NEW! ✨)

```csharp
using Plugin.ByteArrays;

// Zero-allocation operations with ReadOnlySpan<byte>
ReadOnlySpan<byte> span = stackalloc byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
var position = 0;

// Read values without heap allocations
bool flag = span.ToBoolean(ref position);
int number = span.ToInt32(ref position);
float value = span.ToSingle(ref position);

// Pattern matching
ReadOnlySpan<byte> pattern = new byte[] { 3, 4, 5 };
bool contains = span.IndexOf(pattern) >= 0;

// Analysis utilities
double entropy = span.CalculateEntropy();
bool allZeros = span.IsAllZeros();

// Async-compatible with ReadOnlyMemory<byte>
async Task ProcessDataAsync(ReadOnlyMemory<byte> memory)
{
    await Task.Delay(100);
    var value = memory.Span.ToInt32(); // Convert to span for operations
}
```

---

## 📚 Core Features

### 🔧 ByteArrayBuilder

Build byte arrays fluently from various data types:

- Primitives (int, float, bool, etc.)
- Strings (UTF-8, ASCII, Hex, Base64)
- Date/Time types (DateTime, TimeSpan, DateTimeOffset)
- Network types (IP addresses, endpoints)
- Enums and custom objects
- Efficient memory management with IDisposable

### 🔍 Reading Operations

Extract data from byte arrays safely:

- **Primitives**: `ToBoolean`, `ToByte`, `ToInt32`, `ToDouble`, etc.
- **Strings**: `ToUtf8String`, `ToAsciiString`, `ToUtf16String`, `ToHexString`
- **Date & Time**: `ToDateTime`, `ToTimeSpan`, `ToDateTimeFromUnixTimestamp`
- **Network Types**: `ToIPAddress`, `ToIPEndPoint`, big-endian conversions
- **Complex Types**: `ToEnum<T>`, `ToVersion`, `ToGuid`
- **Safe Variants**: `OrDefault` methods that never throw exceptions

### ⚙️ Array Manipulation

Powerful array operations:

- **Slicing**: `SafeSlice` for bounds-safe array segments
- **Concatenation**: `Concatenate` multiple arrays efficiently
- **Trimming**: `TrimEnd` and `TrimEndNonDestructive`
- **Transformation**: `Reverse`, `Xor` operations
- **Analysis**: `CalculateEntropy`, `GetByteFrequency` (`AnalyzeDistribution` on spans)

### 🔎 Pattern Matching

Search and compare byte arrays:

- **Pattern Search**: `StartsWith`, `EndsWith`, `IndexOf`
- **Equality**: `IsIdenticalTo` with optimized comparisons
- **Format Conversion**: Hex and Base64 utilities

### 🌐 Network & Protocol Support

Comprehensive networking capabilities:

- **IP Addresses**: IPv4 and IPv6 conversion and validation
- **Endpoints**: IPEndPoint serialization with network byte order
- **Big-Endian**: Network protocol numeric conversions
- **TLV Parsing**: Type-Length-Value protocol structures

### ⏱️ Async Operations

Asynchronous processing with cancellation:

- **File and stream I/O**: `WriteToFileAsync`, `ReadFromFileAsync`, `WriteToStreamAsync`, `ReadFromStreamAsync`
- **Chunked processing**: `ProcessInParallelAsync`, `TransformAsync`
- **Hashing**: `ComputeHashAsync`, `VerifyIntegrityAsync`

### 🗃️ Compression

Multiple compression algorithms:

- **GZip**: Standard compression with good balance
- **Deflate**: Raw deflate algorithm
- **Brotli**: Modern compression with best ratios

### 🔍 Utilities & Analysis

Advanced analysis and formatting:

- **Binary Representation**: Convert to binary strings
- **Statistical Analysis**: Entropy and distribution calculation
- **Performance Measurement**: `MeasurePerformance` and `CalculateThroughput`

---

## 📖 Documentation Sections

### 📋 API Reference

#### Core Extensions

| Class | Description |
|-------|-------------|
| [ByteArrayExtensions](ByteArrayExtensions.md) | Core utilities, pattern matching, and array comparison |
| [ByteArrayExtensions.PrimitiveTypeConversion](ByteArrayExtensions.PrimitiveTypeConversion.md) | Boolean, byte, char, and basic type conversions |
| [ByteArrayExtensions.IntegerConversion](ByteArrayExtensions.IntegerConversion.md) | Integer type conversions (Int16, Int32, Int64, UInt variants) |
| [ByteArrayExtensions.FloatingPointConversion](ByteArrayExtensions.FloatingPointConversion.md) | Float, double, and Half precision conversions |
| [ByteArrayExtensions.StringConversion](ByteArrayExtensions.StringConversion.md) | UTF-8, ASCII, hex, and Base64 string operations |
| [ByteArrayExtensions.ComplexTypeConversion](ByteArrayExtensions.ComplexTypeConversion.md) | Enum, Version, and complex type conversions |
| [ByteArrayExtensions.ArrayManipulation](ByteArrayExtensions.ArrayManipulation.md) | Slicing, concatenation, trimming, and XOR operations |
| [ByteArrayExtensions.DateTimeConversion](ByteArrayExtensions.DateTimeConversion.md) | DateTime, TimeSpan, DateTimeOffset, and Unix timestamps |
| [ByteArrayExtensions.NetworkConversion](ByteArrayExtensions.NetworkConversion.md) | IP addresses, endpoints, and big-endian conversions |
| [ByteArrayExtensions.GuidConversion](ByteArrayExtensions.GuidConversion.md) | GUID conversion utilities |

#### Specialized Classes

| Class | Description |
|-------|-------------|
| [ByteArrayBuilder](ByteArrayBuilder.md) | Fluent builder for constructing byte arrays from various types |
| [ByteArrayAsyncExtensions](ByteArrayAsyncExtensions.md) | Asynchronous operations for file I/O and parallel processing |
| [ByteArrayCompressionExtensions](ByteArrayCompressionExtensions.md) | Compression and decompression utilities (GZip, Deflate, Brotli) |
| [ByteArrayProtocolExtensions](ByteArrayProtocolExtensions.md) | Protocol parsing including TLV structures, framing, and checksums |
| [ByteArrayUtilities](ByteArrayUtilities.md) | Analysis, formatting, and performance measurement tools |
| [ObjectToByteArrayExtensions](ObjectToByteArrayExtensions.md) | Type-safe object-to-byte-array conversions and JSON serialization |

#### Modern Memory Types (NEW! ✨)

| Class | Description |
|-------|-------------|
| [ReadOnlySpanExtensions](ReadOnlySpanExtensions.md) | Zero-allocation, high-performance operations for ReadOnlySpan\<byte\> |
| [ReadOnlyMemoryExtensions](ReadOnlyMemoryExtensions.md) | Memory-safe operations for ReadOnlyMemory\<byte\> with async support |
| [ReadOnlySpanUtilities](ReadOnlySpanUtilities.md) | Analysis, entropy calculation, and transformation utilities for spans |

**ReadOnlySpan\<byte\> Partial Classes:**

| Class | Description |
|-------|-------------|
| ReadOnlySpanExtensions.PrimitiveTypeConversion | Boolean, byte, char, and sbyte conversions |
| ReadOnlySpanExtensions.IntegerConversion | All integer type conversions (Int16/32/64, UInt16/32/64) |
| ReadOnlySpanExtensions.FloatingPointConversion | Float, double, Half, and decimal conversions |
| ReadOnlySpanExtensions.StringConversion | UTF-8, ASCII, hex, and Base64 string operations |
| ReadOnlySpanExtensions.DateTimeConversion | DateTime, TimeSpan, and DateTimeOffset conversions |
| ReadOnlySpanExtensions.GuidConversion | GUID conversion utilities |
| ReadOnlySpanExtensions.ComplexTypeConversion | Enum and Version object conversions |
| ReadOnlySpanExtensions.NetworkConversion | IPv4/IPv6 addresses and network byte order |

---

## 🎯 Design Principles

- **🛡️ Safety First**: Explicit bounds checking with clear exception messages
- **⚡ Performance**: Zero-allocation friendly with `ReadOnlySpan<byte>` usage
- **🔄 Fail-Safe**: `OrDefault` methods never advance read cursors on failure
- **🎯 Type Safety**: Strict enum conversion with validation
- **🌐 Cross-Platform**: Optimized for .NET 9 and modern C# features

---

## 🚀 Advanced Examples

### Working with DateTime and Time Types

```csharp
// DateTime operations
var now = DateTime.Now;
using var builder = new ByteArrayBuilder();
builder.Append(now.ToBinary());
byte[] data = builder.ToByteArray();

// Read back with position tracking
var pos = 0;
DateTime restored = data.ToDateTime(ref pos);

// Unix timestamp support
int unixTime = 1672531200; // 2023-01-01 00:00:00 UTC
byte[] timeData = BitConverter.GetBytes(unixTime);
pos = 0;
DateTime fromUnix = timeData.ToDateTimeFromUnixTimestamp(ref pos);

// TimeSpan and DateTimeOffset
var span = TimeSpan.FromHours(2.5);
var offset = new DateTimeOffset(now, TimeSpan.FromHours(-8));
```

### Network Protocol Processing

```csharp
// IP address handling
var ipv4 = IPAddress.Parse("192.168.1.1");
var ipv6 = IPAddress.Parse("2001:db8::1");

byte[] ipData = ipv4.GetAddressBytes();
pos = 0;
IPAddress restored = ipData.ToIPAddress(ref pos);

// Network endpoints with big-endian ports
var endpoint = new IPEndPoint(ipv4, 8080);
byte[] endpointData = ipv4.GetAddressBytes()
    .Concat(new byte[] { 0x1F, 0x90 })              // port 8080, big-endian
    .ToArray();
pos = 0;
var restoredEndpoint = endpointData.ToIPEndPoint(ref pos);

// Big-endian network data
byte[] networkPacket = { 0x12, 0x34, 0x56, 0x78 };
pos = 0;
int sequenceNumber = networkPacket.ToInt32BigEndian(ref pos); // 0x12345678

// TLV protocol parsing
byte[] tlvData = { 0x01, 0x05, 0x00, 0x48, 0x65, 0x6C, 0x6C, 0x6F }; // Type, Length (little-endian), Value
pos = 0;
var tlv = tlvData.ParseTlvRecord(ref pos);
string value = Encoding.UTF8.GetString(tlv.Value.ToArray()); // "Hello"
```

### Async Operations with Cancellation

```csharp
// File operations
byte[] data = "Important data".Utf8StringToByteArray();
await data.WriteToFileAsync("output.bin");

byte[] fileData = await ByteArrayAsyncExtensions.ReadFromFileAsync("input.bin");

// Chunked parallel processing with timeout: the array is split into chunks
using var cts = new CancellationTokenSource(TimeSpan.FromMinutes(5));
byte[] largeData = new byte[1024 * 1024];

byte[][] results = await largeData.ProcessInParallelAsync(
    async chunk => {
        await Task.Yield(); // your async work per chunk
        return chunk.CompressGZip();
    },
    chunkSize: 1024,
    maxConcurrency: Environment.ProcessorCount,
    cancellationToken: cts.Token
);

// Hashing
byte[] hash = await data.ComputeHashAsync("SHA256");
bool intact = await data.VerifyIntegrityAsync(hash, "SHA256");
```

### Compression and Analysis

```csharp
// Multi-algorithm compression comparison
byte[] originalData = File.ReadAllBytes("document.pdf");

byte[] gzipData = originalData.CompressGZip();
byte[] deflateData = originalData.CompressDeflate();
byte[] brotliData = originalData.CompressBrotli();

Console.WriteLine($"Original: {originalData.Length:N0} bytes");
Console.WriteLine($"GZip: {gzipData.Length:N0} bytes ({ByteArrayCompressionExtensions.CalculateCompressionRatio(originalData, gzipData):P1})");
Console.WriteLine($"Brotli: {brotliData.Length:N0} bytes ({ByteArrayCompressionExtensions.CalculateCompressionRatio(originalData, brotliData):P1})");

// Statistical analysis
double entropy = originalData.CalculateEntropy();
var frequency = originalData.GetByteFrequency();
var mostFrequent = frequency.MaxBy(kv => kv.Value);

Console.WriteLine($"Data entropy: {entropy:F3}");
Console.WriteLine($"Most frequent byte: 0x{mostFrequent.Key:X2} ({mostFrequent.Value} occurrences)");

// Performance measurement
var (result, totalTime, averageTime) = originalData.MeasurePerformance(d => d.CompressGZip(), iterations: 10);
Console.WriteLine($"Average compression time: {averageTime.TotalMilliseconds:F2}ms");
```

### Working with Complex Data

```csharp
// Serialize a complex structure
using var builder = new ByteArrayBuilder();
var data = builder
    .Append((ushort)0x1234)           // Header
    .AppendUtf8String("UserData")     // Section name
    .Append(DateTime.Now)             // Timestamp
    .Append(MyEnum.Active)            // Status
    .Append(Guid.NewGuid())           // Unique ID
    .AppendHexString("DEADBEEF")      // Binary data
    .ToByteArray();

// Read it back safely
var pos = 0;
var header = data.ToUInt16(ref pos);
var section = data.ToUtf8String(ref pos, 8);
var timestamp = data.ToDateTime(ref pos);
var status = data.ToEnum<MyEnum>(ref pos);
var id = data.ToGuid(ref pos);
var binaryData = data.SafeSlice(pos, 4);

// TLV record creation and parsing
byte[] tlvBytes = ByteArrayProtocolExtensions.CreateTlvRecord(0x01, "Hello World".Utf8StringToByteArray());
pos = 0;
var parsedTlv = tlvBytes.ParseTlvRecord(ref pos);
```

---

## 🔧 Development & Testing

- **Framework**: .NET 9.0
- **Testing**: xUnit + FluentAssertions with comprehensive coverage
- **Build**: `dotnet build -c Release`
- **Test**: `dotnet test -c Release`

---

## 📄 License

This library is licensed under the **MIT License** - see the [LICENSE.md](https://github.com/laerdal/Plugin.ByteArrays/blob/main/LICENSE.md) file for details.

---

## 🤝 Contributing

Contributions are welcome! Please feel free to submit issues, feature requests, or pull requests on [GitHub](https://github.com/laerdal/Plugin.ByteArrays).

---

*Built with ❤️ for modern .NET applications requiring efficient, safe byte array operations.*
