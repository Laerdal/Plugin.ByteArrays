# 🗂️ Plugin.ByteArrays

<div style="max-width: 256px; margin-left: auto; margin-right: auto;">

[![Icon](icon.png)](https://github.com/laerdal/Plugin.ByteArrays)

</div>

[![CI](https://img.shields.io/github/actions/workflow/status/laerdal/Plugin.ByteArrays/ci.yml?logo=github)](https://github.com/laerdal/Plugin.ByteArrays/actions/workflows/ci.yml)
[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![NuGet](https://img.shields.io/nuget/v/Plugin.ByteArrays?logo=nuget&color=004880)](https://www.nuget.org/packages/Plugin.ByteArrays)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Plugin.ByteArrays?logo=nuget&color=004880)](https://www.nuget.org/packages/Plugin.ByteArrays)
[![GitHub Release](https://img.shields.io/github/v/release/laerdal/Plugin.ByteArrays?logo=github)](https://github.com/laerdal/Plugin.ByteArrays/releases)
[![License](https://img.shields.io/github/license/laerdal/Plugin.ByteArrays?color=blue)](LICENSE.md)
[![GitHub Pages](https://img.shields.io/badge/docs-GitHub%20Pages-blue?logo=github)](https://laerdal.github.io/Plugin.ByteArrays/)

A comprehensive set of utilities for working with byte arrays in .NET applications. These helpers are designed for performance, safety, and ease of use across all supported platforms.

---

## 📦 Features

- **ByteArrayBuilder**: Fluently build byte arrays from various types and encodings
- **ByteArrayExtensions**: Extension methods for reading primitives, strings, and complex types from byte arrays
- **DateTime & Time Operations**: Convert DateTime, TimeSpan, DateTimeOffset, and Unix timestamps
- **Network & Protocol Support**: IP addresses, endpoints, big-endian conversions, TLV parsing, framing, and checksums
- **Async Operations**: File and stream I/O, chunked parallel processing, and hashing with cancellation support
- **Compression**: GZip, Deflate, and Brotli compression/decompression
- **GUID Operations**: Convert between GUIDs and byte arrays with multiple format options
- **Utilities & Analysis**: Binary string representation, entropy calculation, and performance measurement
- **Array Manipulation**: Safe operations like slicing, concatenation, trimming, reversing, and XOR
- **Pattern Matching**: Search and compare byte arrays with StartsWith, EndsWith, IndexOf, and equality checks
- **Format Conversion**: Convert to/from hex strings, Base64, ASCII, and UTF-8 encodings
- **Object Serialization**: Convert objects and primitives to byte arrays with type safety
- **Safe Operations**: OrDefault methods that never throw exceptions and bounds-checked operations

---

## 🛠️ Supported Conversion Types

The following table shows all types that can be converted from byte arrays, with support across `byte[]`, `ReadOnlySpan<byte>`, and `ReadOnlyMemory<byte>`:

| **Type** | **Size (bytes)** | **byte[]** | **ReadOnlySpan\<byte\>** | **ReadOnlyMemory\<byte\>** | **Notes** |
|----------|------------------|------------|--------------------------|----------------------------|-----------|
| `bool` | 1 | ✅ | ✅ | ➡️ | True[1] or False[0] |
| `byte` | 1 | ✅ | ✅ | ➡️ | Unsigned 8-bit (0-255) |
| `sbyte` | 1 | ✅ | ✅ | ➡️ | Signed 8-bit (-128 to 127) |
| `char` | 2 | ✅ | ✅ | ➡️ | Unicode character |
| `short` | 2 | ✅ | ✅ | ➡️ | Signed 16-bit (-32,768 to 32,767) |
| `ushort` | 2 | ✅ | ✅ | ➡️ | Unsigned 16-bit (0 to 65,535) |
| `int` | 4 | ✅ | ✅ | ➡️ | Signed 32-bit |
| `uint` | 4 | ✅ | ✅ | ➡️ | Unsigned 32-bit |
| `long` | 8 | ✅ | ✅ | ➡️ | Signed 64-bit |
| `ulong` | 8 | ✅ | ✅ | ➡️ | Unsigned 64-bit |
| `float` | 4 | ✅ | ✅ | ➡️ | Single-precision |
| `double` | 8 | ✅ | ✅ | ➡️ | Double-precision |
| `Half` | 2 | ✅ | ✅ | ➡️ | Half-precision |
| `decimal` | 16 | ✅ | ✅ | ➡️ | High-precision decimal |
| `DateTime` | 8 | ✅ | ✅ | ➡️ | Binary representation |
| `TimeSpan` | 8 | ✅ | ✅ | ➡️ | Ticks representation |
| `DateTimeOffset` | 16/10 | ✅ | ✅ | ➡️ | DateTime + offset |
| `Guid` | 16 | ✅ | ✅ | ➡️ | UUID/GUID |
| `string` (UTF-8) | Variable | ✅ | ✅ | ➡️ | UTF-8 encoded |
| `string` (ASCII) | Variable | ✅ | ✅ | ➡️ | ASCII encoded |
| `string` (UTF-16) | Variable | ✅ | ✅ | ➡️ | UTF-16 encoded (`ToUtf16String`) |
| `string` (UTF-32) | Variable | ✅ | ❌ | ➡️ | UTF-32 encoded (`ToUtf32String`) |
| `string` (Hex) | Variable | ✅ | ✅ | ➡️ | Hexadecimal representation |
| `string` (Base64) | Variable | ✅ | ✅ | ➡️ | Base64 encoded |
| `IPAddress` (IPv4) | 4 | ✅ | ✅ | ➡️ | IPv4 address |
| `IPAddress` (IPv6) | 16 | ✅ | ✅ | ➡️ | IPv6 address |
| `IPEndPoint` (IPv4) | 6 | ✅ | ✅ | ➡️ | IPv4 address + port |
| `IPEndPoint` (IPv6) | 18 | ✅ | ✅ | ➡️ | IPv6 address + port |
| `short` (Big-endian) | 2 | ✅ | ✅ | ➡️ | Network byte order |
| `ushort` (Big-endian) | 2 | ✅ | ✅ | ➡️ | Network byte order |
| `int` (Big-endian) | 4 | ✅ | ✅ | ➡️ | Network byte order |
| `uint` (Big-endian) | 4 | ✅ | ✅ | ➡️ | Network byte order |
| `long` (Big-endian) | 8 | ✅ | ✅ | ➡️ | Network byte order |
| `ulong` (Big-endian) | 8 | ✅ | ✅ | ➡️ | Network byte order |
| `Enum<T>` | 4 | ✅ | ✅ | ➡️ | Any enum type |
| `Version` | 16 | ✅ | ✅ | ➡️ | .NET Version object |
| `DateTime` (Unix) | 4 | ✅ | ✅ | ➡️ | Seconds since epoch |

### Legend

- ✅ **Fully Supported** - All conversion methods available
- ❌ **Not Available** - Type conversion not implemented
- ➡️ **Via Span** - `ReadOnlyMemory<byte>` uses `.Span` property to access `ReadOnlySpan<byte>` methods

The `ReadOnlySpan<byte>` network methods have different names from their `byte[]` counterparts:

| Conversion | `byte[]` | `ReadOnlySpan<byte>` |
|------------|----------|----------------------|
| IP address | `ToIPAddress(ref position, isIPv6)` | `ToIPv4Address`, `ToIPv6Address` |
| IP endpoint | `ToIPEndPoint(ref position, isIPv6)` | `ToIPv4EndPoint`, `ToIPv6EndPoint` |
| Big-endian integers | `ToInt16BigEndian`, `ToUInt32BigEndian`, … | `ToInt16NetworkOrder`, `ToUInt32NetworkOrder`, … |

### Method Variants Available

- **Standard**: `ToType(ref position)` and `ToType(position)` - Throws on error
- **Safe**: `ToTypeOrDefault(ref position, defaultValue)` and `ToTypeOrDefault(position, defaultValue)` - Returns default on error

### Special Features

- **Position Tracking**: `ref int position` parameter automatically advances
- **Bounds Checking**: All methods validate array/span boundaries
- **Endianness Support**: Network byte order conversions for multi-byte integers
- **String Length Handling**: Automatic and manual length specification for strings
- **Unix Timestamps**: Convert POSIX timestamps to DateTime

---

## 🛠️ Usage Examples

### ByteArrayBuilder

```csharp
using Plugin.ByteArrays;

using var builder = new ByteArrayBuilder();
builder.Append((byte)0x01)                // 1 byte
       .AppendUtf8String("Hello")
       .Append(new byte[] { 0x02, 0x03 })
       .Append(42)                        // int: 4 bytes, little-endian
       .AppendHexString("DEADBEEF");

byte[] result = builder.ToByteArray();
```

`Append<T>` writes the value at its own size, so `Append(0x01)` is an `int` and adds 4 bytes. Cast to `byte` for a single byte.

### Reading Primitives from Byte Arrays

```csharp
using Plugin.ByteArrays;

byte[] data = { 0x01, 0x2A, 0x00, 0x00, 0x00, 0x48, 0x65, 0x6C, 0x6C, 0x6F };
var position = 0;

bool flag = data.ToBoolean(ref position);         // reads 1 byte: true
int value = data.ToInt32(ref position);           // reads 4 bytes: 42, position is now 5
string text = data.ToUtf8String(ref position, 5); // reads 5 bytes: "Hello"

// Safe variants that don't throw
var safeValue = data.ToInt16OrDefault(ref position, defaultValue: -1);
```

### Array Manipulation

```csharp
using Plugin.ByteArrays;

byte[] data = { 0x10, 0x20, 0x30, 0x40, 0x00, 0x00 };

// Safe slicing
byte[] slice = data.SafeSlice(1, 3);  // [0x20, 0x30, 0x40]

// Concatenation
byte[] a = { 0x01, 0x02 };
byte[] b = { 0x03, 0x04 };
byte[] combined = ByteArrayExtensions.Concatenate(a, b);  // [0x01, 0x02, 0x03, 0x04]

// Trimming trailing zeros
byte[] trimmed = data.TrimEndNonDestructive();  // [0x10, 0x20, 0x30, 0x40]

// Reverse and XOR operations
byte[] reversed = data.Reverse();
byte[] xorResult = a.Xor(new byte[] { 0xFF, 0xFF });
```

### Pattern Matching and Search

```csharp
using Plugin.ByteArrays;

byte[] data = { 0x48, 0x65, 0x6C, 0x6C, 0x6F };
byte[] pattern = { 0x65, 0x6C };

bool starts = data.StartsWith(new byte[] { 0x48, 0x65 });  // true
bool ends = data.EndsWith(new byte[] { 0x6C, 0x6F });      // true
int index = data.IndexOf(pattern);                         // 1

// Array comparison
byte[] other = { 0x48, 0x65, 0x6C, 0x6C, 0x6F };
bool identical = data.IsIdenticalTo(other);                // true
```

### String and Format Conversions

```csharp
using Plugin.ByteArrays;

// String to byte array
byte[] utf8Bytes = "Hello World".Utf8StringToByteArray();
byte[] asciiBytes = "Hello".AsciiStringToByteArray();
byte[] hexBytes = "48656C6C6F".HexStringToByteArray();     // "Hello" in hex
byte[] base64Bytes = "SGVsbG8=".Base64StringToByteArray(); // "Hello" in base64

// Byte array to string
string hex = data.ToHexString("-", "0x");  // "0x48-0x65-0x6C-0x6C-0x6F"
string base64 = data.ToBase64String();
string utf8 = data.ToUtf8String(ref position, numberOfBytesToRead: 5);
```

### DateTime and Time Operations

```csharp
using Plugin.ByteArrays;

// DateTime conversions
var now = DateTime.Now;
byte[] dateTimeBytes = BitConverter.GetBytes(now.ToBinary());
var position = 0;
DateTime restored = dateTimeBytes.ToDateTime(ref position);

// Unix timestamp support
int unixTimestamp = 1672531200; // 2023-01-01 00:00:00 UTC
byte[] timestampBytes = BitConverter.GetBytes(unixTimestamp);
position = 0;
DateTime fromUnix = timestampBytes.ToDateTimeFromUnixTimestamp(ref position); // 2023-01-01 00:00:00, DateTimeKind.Unspecified (UTC wall time)

// TimeSpan operations
var timeSpan = new TimeSpan(1, 2, 3, 4, 5);
byte[] spanBytes = BitConverter.GetBytes(timeSpan.Ticks);
position = 0;
TimeSpan restoredSpan = spanBytes.ToTimeSpan(ref position);

// DateTimeOffset with timezone
var offset = new DateTimeOffset(2023, 6, 15, 14, 30, 0, TimeSpan.FromHours(-8));
// Complex serialization combining DateTime and TimeSpan
```

### Network and Protocol Operations

```csharp
using Plugin.ByteArrays;
using System.Net;
using System.Text;

// IP Address conversions
var ipv4 = IPAddress.Parse("192.168.1.1");
byte[] ipBytes = ipv4.GetAddressBytes();
position = 0;
IPAddress restored = ipBytes.ToIPAddress(ref position);

// IPv6 support
var ipv6 = IPAddress.Parse("2001:db8::1");
byte[] ipv6Bytes = ipv6.GetAddressBytes();
position = 0;
IPAddress restoredV6 = ipv6Bytes.ToIPAddress(ref position, isIPv6: true);

// Network endpoints: address bytes followed by the port in network byte order (big-endian)
var endpointBytes = ipv4.GetAddressBytes()
    .Concat(BitConverter.GetBytes((ushort)8080).Reverse())
    .ToArray();
position = 0;
var restoredEndpoint = endpointBytes.ToIPEndPoint(ref position);

// Big-endian numeric conversions for network protocols
byte[] networkData = { 0x12, 0x34, 0x56, 0x78 };
position = 0;
int networkInt = networkData.ToInt32BigEndian(ref position); // 0x12345678

// TLV (Type-Length-Value) protocol parsing
byte[] tlvData = { 0x01, 0x05, 0x00, 0x48, 0x65, 0x6C, 0x6C, 0x6F }; // Type=1, Length=5 (little-endian), Value="Hello"
position = 0;
var tlvRecord = tlvData.ParseTlvRecord(ref position);
Console.WriteLine($"Type: {tlvRecord.Type}, Value: {Encoding.UTF8.GetString(tlvRecord.Value.ToArray())}");

// Several records in a row, or build one
foreach (var record in tlvData.ParseAllTlvRecords()) { /* ... */ }
byte[] encoded = ByteArrayProtocolExtensions.CreateTlvRecord(0x01, "Hello".Utf8StringToByteArray());
```

### Async Operations

```csharp
using Plugin.ByteArrays;

// Async file operations
byte[] data = { 0x01, 0x02, 0x03, 0x04 };
await data.WriteToFileAsync("output.bin");
byte[] fileData = await ByteArrayAsyncExtensions.ReadFromFileAsync("input.bin");

// Chunked parallel processing with cancellation: the array is split into chunks,
// the processor runs once per chunk, and results come back in chunk order
using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
byte[] payload = new byte[64 * 1024];

byte[][] results = await payload.ProcessInParallelAsync(
    chunk => SomeAsyncOperation(chunk, cts.Token),
    chunkSize: 4096,
    maxConcurrency: 4,
    cancellationToken: cts.Token
);

// Hashing ("SHA256", "SHA1" or "MD5")
byte[] hash = await data.ComputeHashAsync("SHA256");
bool intact = await data.VerifyIntegrityAsync(hash, "SHA256");
```

### Compression

```csharp
using Plugin.ByteArrays;

byte[] originalData = "This is some data to compress".Utf8StringToByteArray();

// GZip compression
byte[] gzipCompressed = originalData.CompressGZip();
byte[] gzipDecompressed = gzipCompressed.DecompressGZip();

// Deflate compression
byte[] deflateCompressed = originalData.CompressDeflate();
byte[] deflateDecompressed = deflateCompressed.DecompressDeflate();

// Brotli compression (best compression ratio)
byte[] brotliCompressed = originalData.CompressBrotli();
byte[] brotliDecompressed = brotliCompressed.DecompressBrotli();

// Compare compression ratios
Console.WriteLine($"Original: {originalData.Length} bytes");
Console.WriteLine($"GZip: {gzipCompressed.Length} bytes ({(double)gzipCompressed.Length/originalData.Length:P1})");
Console.WriteLine($"Brotli: {brotliCompressed.Length} bytes ({(double)brotliCompressed.Length/originalData.Length:P1})");
```

### GUID Operations

```csharp
using Plugin.ByteArrays;

// GUID conversions
var guid = Guid.NewGuid();
byte[] guidBytes = guid.ToByteArray();
position = 0;
Guid restored = guidBytes.ToGuid(ref position);

// Safe GUID operations
Guid safeGuid = invalidData.ToGuidOrDefault(ref position, Guid.Empty);
```

### Utilities and Analysis

```csharp
using Plugin.ByteArrays;

byte[] data = { 0xAA, 0xBB, 0xCC, 0xDD };

// Binary and hex representation
string binary = data.ToBinaryString(); // "10101010 10111011 11001100 11011101"
string dump = data.ToHexDump();        // offsets, hex and ASCII columns

// Statistical analysis
// Entropy of the byte-value distribution; the order of the bytes is ignored:
// 0.0 = a single distinct value, 8.0 = all 256 values equally frequent
double entropy = data.CalculateEntropy();
Dictionary<byte, int> frequency = data.GetByteFrequency(); // byte value -> count
byte mostFrequent = frequency.MaxBy(kv => kv.Value).Key;
Console.WriteLine($"Entropy: {entropy:F3}, Most frequent byte: 0x{mostFrequent:X2}");

// ReadOnlySpan<byte> helpers
ReadOnlySpan<byte> span = data;
int occurrences = span.CountOccurrences(0xAA);
bool allZeros = span.IsAllZeros();

// Performance measurement
var (hex, totalTime, averageTime) = data.MeasurePerformance(d => d.ToHexString(), iterations: 1000);
Console.WriteLine($"Average: {averageTime.TotalMilliseconds:F4}ms");
// totalTime covers all 1000 iterations; CalculateThroughput divides data.Length by the duration it is given,
// so pass the time of a single run
double bytesPerSecond = data.CalculateThroughput(averageTime);
```

### Object Serialization

```csharp
using Plugin.ByteArrays;

// Convert any supported type to byte array
int number = 42;
byte[] numberBytes = number.ToByteArray();

DateTime now = DateTime.Now;
byte[] dateBytes = now.ToByteArray();

// Enums are supported
MyEnum enumValue = MyEnum.SomeValue;
byte[] enumBytes = enumValue.ToByteArray();
```

---

## 📋 API Overview

### Core Classes

- **`ByteArrayBuilder`** - Fluent builder for constructing byte arrays
- **`ByteArrayExtensions`** - Extension methods for reading and manipulating byte arrays
- **`ByteArrayAsyncExtensions`** - Asynchronous operations for file I/O and parallel processing
- **`ByteArrayCompressionExtensions`** - Compression and decompression utilities
- **`ByteArrayUtilities`** - Analysis, formatting, and performance measurement tools
- **`ByteArrayProtocolExtensions`** - Protocol parsing including TLV structures, framing, and checksums
- **`ObjectToByteArrayExtensions`** - Object-to-byte-array conversion helpers
- **`ReadOnlySpanExtensions`** / **`ReadOnlyMemoryExtensions`** - The same read operations for `ReadOnlySpan<byte>` and `ReadOnlyMemory<byte>`
- **`ReadOnlySpanUtilities`** - Analysis helpers for `ReadOnlySpan<byte>` (entropy, distribution, counting, XOR)

### Reading Operations

- **Primitives**: `ToBoolean`, `ToByte`, `ToSByte`, `ToChar`, `ToInt16/32/64`, `ToUInt16/32/64`
- **Floating Point**: `ToSingle`, `ToDouble`, `ToHalf`
- **Strings**: `ToUtf8String`, `ToAsciiString`, `ToUtf16String`, `ToHexString`, `ToBase64String`
- **Date & Time**: `ToDateTime`, `ToTimeSpan`, `ToDateTimeOffset`, `ToDateTimeFromUnixTimestamp`
- **Network Types**: `ToIPAddress`, `ToIPEndPoint`, big-endian numeric conversions
- **Complex Types**: `ToEnum<T>`, `ToVersion`, `ToGuid`
- **Protocol Structures**: `ParseTlvRecord`, `ParseAllTlvRecords`, `CreateTlvRecord`, framing (`AddSimpleFrame`, `AddLengthPrefixedFrame`) and checksums (`CalculateSimpleChecksum`, `CalculateXorChecksum`, `AppendChecksum`, `ValidateChecksum`)
- **Safe Variants**: All methods have `OrDefault` versions that return defaults instead of throwing

### Writing Operations

- **Fluent Building**: `Append<T>`, `AppendUtf8String`, `AppendAsciiString`, `AppendHexString`, `AppendBase64String`, `AppendBigEndian`, `AppendLittleEndian`, `AppendRepeated`, `AppendIf`
- **Direct Conversion**: `Utf8StringToByteArray`, `HexStringToByteArray`, `ToByteArray<T>`, `ToJsonByteArray`
- **Object Serialization**: Convert any supported type to byte arrays

### Async File Operations

- **File and stream I/O**: `WriteToFileAsync`, `ReadFromFileAsync`, `WriteToStreamAsync`, `ReadFromStreamAsync`, `CopyToStreamAsync`
- **Chunked processing**: `ProcessInParallelAsync`, `TransformAsync`
- **Hashing**: `ComputeHashAsync` (SHA256, SHA1, MD5), `VerifyIntegrityAsync`
- **Search**: `IndexOfAsync`, `SequenceEqualAsync`

### Compression Utilities

- **Algorithms**: `CompressGZip/DecompressGZip`, `CompressDeflate/DecompressDeflate`, `CompressBrotli/DecompressBrotli`
- **Utilities**: `CalculateCompressionRatio`, `IsLikelyCompressed`, `FindBestCompression`

### Array Operations

- **Manipulation**: `SafeSlice`, `Concatenate`, `TrimEnd`, `TrimEndNonDestructive`, `Reverse`, `Xor`
- **Pattern Matching**: `StartsWith`, `EndsWith`, `IndexOf`, `IsIdenticalTo`
- **Analysis**: `ToBinaryString`, `ToHexDump`, `CalculateEntropy`, `GetByteFrequency` (`AnalyzeDistribution` on spans)
- **Debugging and measurement**: `ToDebugString`, `ToHexDebugString`, `MeasurePerformance`, `CalculateThroughput`

---

## 🔧 Design Principles

- **Safety First**: Explicit bounds checking with clear exception messages
- **Zero-Allocation Friendly**: Efficient operations using `ReadOnlySpan<byte>` and `SequenceEqual`
- **Fail-Safe Defaults**: `OrDefault` methods never advance read cursors on failure
- **Type Safety**: Strict enum conversion with validation for undefined values
- **Cross-Platform**: Optimized for .NET 9 and modern C# features

---

## 🧪 Development

- **Testing**: xUnit + FluentAssertions with comprehensive coverage
- **Build**: `dotnet build`
- **Test**: `dotnet test`
- **Framework**: .NET 9.0

---

## 📄 License

MIT — see `LICENSE.md` for details.

---

*Designed for modern .NET applications requiring efficient, safe byte array operations.*
