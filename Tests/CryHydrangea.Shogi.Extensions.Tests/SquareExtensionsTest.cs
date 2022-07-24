using FluentAssertions;
using Xunit;

namespace CryHydrangea.Shogi.Extensions.Tests;

public sealed class SquareExtensionsTest
{
    static readonly Square[] SquareTestData = Enum.GetValues<Square>();

    [Fact]
    public void ToFileTest()
    {
        foreach (var square in SquareTestData)
        {
            square.ToFile().Should().Be((File)((int)square / 9));
        }
    }

    [Fact]
    public void ToRankTest()
    {
        foreach (var square in SquareTestData)
        {
            square.ToRank().Should().Be((Rank)((int)square % 9));
        }
    }
}
