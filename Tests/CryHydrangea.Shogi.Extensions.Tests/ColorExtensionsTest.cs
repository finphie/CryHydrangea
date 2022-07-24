using FluentAssertions;
using Xunit;
using static CryHydrangea.Shogi.Color;

namespace CryHydrangea.Shogi.Extensions.Tests;

public sealed class ColorExtensionsTest
{
    [Theory]
    [InlineData(Black, White)]
    [InlineData(White, Black)]
    public void ToOpponent_手番_相手の手番を返す(Color color, Color expected)
        => color.ToOpponent().Should().Be(expected);

    [Theory]
    [InlineData(Black, '☗')]
    [InlineData(White, '☖')]
    public void ToHumanReadableChar_手番_文字列を返す(Color color, char expected)
        => color.ToHumanReadableChar().Should().Be(expected);
}
