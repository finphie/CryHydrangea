using FluentAssertions;
using Xunit;
using static CryHydrangea.Shogi.Rank;

namespace CryHydrangea.Shogi.Extensions.Tests;

public sealed class RankExtensionsTest
{
    [Theory]
    [InlineData(Rank1, '一')]
    [InlineData(Rank2, '二')]
    [InlineData(Rank3, '三')]
    [InlineData(Rank4, '四')]
    [InlineData(Rank5, '五')]
    [InlineData(Rank6, '六')]
    [InlineData(Rank7, '七')]
    [InlineData(Rank8, '八')]
    [InlineData(Rank9, '九')]
    public void ToHumanReadableChar_段_文字列を返す(Rank rank, char expected)
        => rank.ToHumanReadableChar().Should().Be(expected);
}
