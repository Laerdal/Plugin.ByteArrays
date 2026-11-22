using FluentAssertions;
using Xunit;

namespace Plugin.ByteArrays.Tests;

public class ReadOnlySpanUtilitiesTests
{
    [Fact]
    public void CalculateEntropy_EmptySpan_ReturnsZero()
    {
        ReadOnlySpan<byte> span = ReadOnlySpan<byte>.Empty;
        span.CalculateEntropy().Should().Be(0.0);
    }

    [Fact]
    public void CalculateEntropy_AllSameBytes_ReturnsZero()
    {
        ReadOnlySpan<byte> span = new byte[] { 5, 5, 5, 5, 5 };
        span.CalculateEntropy().Should().Be(0.0);
    }

    [Fact]
    public void CalculateEntropy_MaxEntropy_ReturnsHighValue()
    {
        // Create a span with all 256 byte values (maximum diversity)
        var bytes = new byte[256];
        for (var i = 0; i < 256; i++)
        {
            bytes[i] = (byte)i;
        }
        ReadOnlySpan<byte> span = bytes;
        span.CalculateEntropy().Should().Be(8.0); // Maximum entropy for bytes
    }

    [Fact]
    public void AnalyzeDistribution_Works()
    {
        ReadOnlySpan<byte> span = new byte[] { 1, 2, 1, 3, 2, 1 };
        var distribution = span.AnalyzeDistribution();

        distribution.Should().HaveCount(3);
        distribution[1].Should().Be(3);
        distribution[2].Should().Be(2);
        distribution[3].Should().Be(1);
    }

    [Fact]
    public void AnalyzeDistribution_EmptySpan_ReturnsEmptyDictionary()
    {
        ReadOnlySpan<byte> span = ReadOnlySpan<byte>.Empty;
        var distribution = span.AnalyzeDistribution();
        distribution.Should().BeEmpty();
    }

    [Fact]
    public void CountOccurrences_Works()
    {
        ReadOnlySpan<byte> span = new byte[] { 1, 2, 3, 2, 4, 2, 5 };
        span.CountOccurrences(2).Should().Be(3);
        span.CountOccurrences(5).Should().Be(1);
        span.CountOccurrences(9).Should().Be(0);
    }

    [Fact]
    public void CountOccurrences_EmptySpan_ReturnsZero()
    {
        ReadOnlySpan<byte> span = ReadOnlySpan<byte>.Empty;
        span.CountOccurrences(1).Should().Be(0);
    }

    [Fact]
    public void FindAllIndices_Works()
    {
        ReadOnlySpan<byte> span = new byte[] { 1, 2, 3, 2, 4, 2, 5 };
        var indices = span.FindAllIndices(2);
        indices.Should().Equal(1, 3, 5);
    }

    [Fact]
    public void FindAllIndices_NotFound_ReturnsEmptyArray()
    {
        ReadOnlySpan<byte> span = new byte[] { 1, 2, 3, 4, 5 };
        var indices = span.FindAllIndices(9);
        indices.Should().BeEmpty();
    }

    [Fact]
    public void FindAllIndices_EmptySpan_ReturnsEmptyArray()
    {
        ReadOnlySpan<byte> span = ReadOnlySpan<byte>.Empty;
        var indices = span.FindAllIndices(1);
        indices.Should().BeEmpty();
    }

    [Fact]
    public void AllBytesEqual_AllSame_ReturnsTrue()
    {
        ReadOnlySpan<byte> span = new byte[] { 5, 5, 5, 5, 5 };
        span.AllBytesEqual().Should().BeTrue();
    }

    [Fact]
    public void AllBytesEqual_Different_ReturnsFalse()
    {
        ReadOnlySpan<byte> span = new byte[] { 5, 5, 6, 5, 5 };
        span.AllBytesEqual().Should().BeFalse();
    }

    [Fact]
    public void AllBytesEqual_EmptySpan_ReturnsTrue()
    {
        ReadOnlySpan<byte> span = ReadOnlySpan<byte>.Empty;
        span.AllBytesEqual().Should().BeTrue();
    }

    [Fact]
    public void AllBytesEqual_SingleByte_ReturnsTrue()
    {
        ReadOnlySpan<byte> span = new byte[] { 42 };
        span.AllBytesEqual().Should().BeTrue();
    }

    [Fact]
    public void IsAllZeros_AllZeros_ReturnsTrue()
    {
        ReadOnlySpan<byte> span = new byte[] { 0, 0, 0, 0 };
        span.IsAllZeros().Should().BeTrue();
    }

    [Fact]
    public void IsAllZeros_HasNonZero_ReturnsFalse()
    {
        ReadOnlySpan<byte> span = new byte[] { 0, 0, 1, 0 };
        span.IsAllZeros().Should().BeFalse();
    }

    [Fact]
    public void IsAllZeros_EmptySpan_ReturnsTrue()
    {
        ReadOnlySpan<byte> span = ReadOnlySpan<byte>.Empty;
        span.IsAllZeros().Should().BeTrue();
    }

    [Fact]
    public void Reverse_Works()
    {
        ReadOnlySpan<byte> span = new byte[] { 1, 2, 3, 4, 5 };
        var reversed = span.Reverse();
        reversed.Should().Equal(5, 4, 3, 2, 1);
    }

    [Fact]
    public void Reverse_EmptySpan_ReturnsEmptyArray()
    {
        ReadOnlySpan<byte> span = ReadOnlySpan<byte>.Empty;
        var reversed = span.Reverse();
        reversed.Should().BeEmpty();
    }

    [Fact]
    public void Xor_SameLength_Works()
    {
        ReadOnlySpan<byte> span1 = new byte[] { 0xFF, 0x00, 0xAA };
        ReadOnlySpan<byte> span2 = new byte[] { 0x0F, 0xFF, 0x55 };
        var result = span1.Xor(span2);
        result.Should().Equal(0xF0, 0xFF, 0xFF);
    }

    [Fact]
    public void Xor_DifferentLength_UsesMinimum()
    {
        ReadOnlySpan<byte> span1 = new byte[] { 0xFF, 0x00, 0xAA, 0xBB };
        ReadOnlySpan<byte> span2 = new byte[] { 0x0F, 0xFF };
        var result = span1.Xor(span2);
        result.Length.Should().Be(2);
        result.Should().Equal(0xF0, 0xFF);
    }

    [Fact]
    public void Xor_EmptySpan_ReturnsEmptyArray()
    {
        ReadOnlySpan<byte> span1 = new byte[] { 0xFF, 0x00 };
        ReadOnlySpan<byte> span2 = ReadOnlySpan<byte>.Empty;
        var result = span1.Xor(span2);
        result.Should().BeEmpty();
    }

    // Lengths around the SIMD vector widths (16/32/64 bytes) so both the vectorized body and the scalar tail run.
    public static TheoryData<int> VectorBoundaryLengths => new() { 0, 1, 15, 16, 17, 31, 32, 33, 63, 64, 65, 257 };

    [Theory]
    [MemberData(nameof(VectorBoundaryLengths))]
    public void CountOccurrences_VectorBoundaryLengths_MatchesExpectedCount(int length)
    {
        var bytes = new byte[length];
        var expected = 0;
        for (var i = 0; i < length; i++)
        {
            bytes[i] = (byte)(i % 3);
            if (bytes[i] == 1)
            {
                expected++;
            }
        }

        ((ReadOnlySpan<byte>)bytes).CountOccurrences(1).Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(VectorBoundaryLengths))]
    public void IsAllZeros_VectorBoundaryLengths_DetectsNonZeroAtAnyPosition(int length)
    {
        ((ReadOnlySpan<byte>)new byte[length]).IsAllZeros().Should().BeTrue();

        foreach (var position in new[] { 0, length / 2, length - 1 }.Where(p => p >= 0 && p < length).Distinct())
        {
            var bytes = new byte[length];
            bytes[position] = 1;
            ((ReadOnlySpan<byte>)bytes).IsAllZeros().Should().BeFalse($"a non-zero byte sits at index {position}");
        }
    }

    [Theory]
    [MemberData(nameof(VectorBoundaryLengths))]
    public void AllBytesEqual_VectorBoundaryLengths_DetectsDifferingByteAtAnyPosition(int length)
    {
        var uniform = new byte[length];
        Array.Fill(uniform, (byte)0xAB);
        ((ReadOnlySpan<byte>)uniform).AllBytesEqual().Should().BeTrue();

        foreach (var position in new[] { 0, length / 2, length - 1 }.Where(p => p >= 0 && p < length).Distinct())
        {
            var bytes = (byte[])uniform.Clone();
            bytes[position] = 0xCD;

            // A single byte can never differ from itself, so a one-element span stays "all equal".
            ((ReadOnlySpan<byte>)bytes).AllBytesEqual().Should().Be(length == 1, $"index {position} of {length} differs");
        }
    }
}
