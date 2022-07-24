using FluentAssertions;
using Xunit;

namespace CryHydrangea.Shogi.Extensions.Tests;

public sealed class SquareExtensionsHumanReadableStringTest
{
    static readonly Square[] SquareTestData = Enum.GetValues<Square>();

    [Fact]
    public void DangerousWriteHumanReadableString_マス目_文字列を返す()
    {
        Span<char> buffer = stackalloc char[2];

        foreach (var square in SquareTestData)
        {
            var expected = GetExpectedValue(square);

            square.DangerousWriteHumanReadableString(buffer);
            buffer.ToString().Should().Be(expected);
            buffer.Clear();
        }
    }

    [Fact]
    public void TryWriteHumanReadableString_マス目_文字列を返す()
    {
        Span<char> buffer = stackalloc char[2];

        foreach (var square in SquareTestData)
        {
            var expected = GetExpectedValue(square);

            square.TryWriteHumanReadableString(buffer).Should().BeTrue();
            buffer.ToString().Should().Be(expected);
            buffer.Clear();
        }
    }

    [Fact]
    public void ToHumanReadableString_マス目_文字列を返す()
    {
        foreach (var square in SquareTestData)
        {
            var expected = GetExpectedValue(square);

            square.ToHumanReadableString().Should().Be(expected);
        }
    }

    [Fact]
    public void TryWriteHumanReadableString_不足サイズのバッファー_falseを返す()
    {
        Span<char> buffer = stackalloc char[1];

        foreach (var square in SquareTestData)
        {
            var expected = GetExpectedValue(square);

            square.TryWriteHumanReadableString(buffer).Should().BeFalse();
        }
    }

    static string GetExpectedValue(Square square)
    {
        var file = square.ToFile().ToHumanReadableChar();
        var rank = square.ToRank().ToHumanReadableChar();

        return $"{file}{rank}";
    }
}
