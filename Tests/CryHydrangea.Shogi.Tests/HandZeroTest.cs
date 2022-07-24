using FluentAssertions;
using Xunit;
using static CryHydrangea.Shogi.RawPieceType;

namespace CryHydrangea.Shogi.Tests;

public sealed class HandZeroTest
{
    [Theory]
    [InlineData(Pawn)]
    [InlineData(Lance)]
    [InlineData(Knight)]
    [InlineData(Silver)]
    [InlineData(Bishop)]
    [InlineData(Rook)]
    [InlineData(Gold)]
    public void Test(RawPieceType rawPieceType)
    {
        var hand = Hand.Zero;
        hand.GetCount(rawPieceType).Should().Be(0);
    }
}
