using CryHydrangea.Shogi.Tests.Core.TestData;
using FluentAssertions;
using Xunit;
using static CryHydrangea.Shogi.RawPieceType;

namespace CryHydrangea.Shogi.Tests;

public sealed class HandAddTest
{
    static readonly RawPieceType[] RawPieceTypeTestData = Enum.GetValues<RawPieceType>()
        .Where(static x => x is not NoPiece and not King)
        .ToArray();

    [Theory]
    [ClassData(typeof(HandPawnTestData))]
    public void 歩(uint count)
        => Test(Pawn, count);

    [Theory]
    [ClassData(typeof(Hand2TestData))]
    public void 角飛(RawPieceType rawPieceType, uint count)
        => Test(rawPieceType, count);

    [Theory]
    [ClassData(typeof(Hand4TestData))]
    public void 香桂銀金(RawPieceType rawPieceType, uint count)
        => Test(rawPieceType, count);

    [Fact]
    public void 混合()
    {
        var hand = Hand.Zero;

        hand.Add(Pawn, 8);
        hand.Add(Bishop, 1);
        hand.Add(Rook, 2);
        hand.Add(Lance, 1);
        hand.Add(Knight, 2);
        hand.Add(Silver, 3);
        hand.Add(Gold, 4);

        hand.GetCount(Pawn).Should().Be(8);
        hand.GetCount(Bishop).Should().Be(1);
        hand.GetCount(Rook).Should().Be(2);
        hand.GetCount(Lance).Should().Be(1);
        hand.GetCount(Knight).Should().Be(2);
        hand.GetCount(Silver).Should().Be(3);
        hand.GetCount(Gold).Should().Be(4);
    }

    static void Test(RawPieceType rawPieceType, uint count)
    {
        var hand = Hand.Zero;

        hand.Add(rawPieceType, count);
        hand.GetCount(rawPieceType).Should().Be(count);

        ZeroTest(hand, rawPieceType);
    }

    static void ZeroTest(in Hand hand, RawPieceType ignoreRawPieceType)
    {
        foreach (var rawPieceType in RawPieceTypeTestData)
        {
            if (rawPieceType == ignoreRawPieceType)
            {
                continue;
            }

            hand.GetCount(rawPieceType).Should().Be(0);
        }
    }
}
