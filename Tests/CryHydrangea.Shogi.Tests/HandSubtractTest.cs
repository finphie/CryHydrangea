using CryHydrangea.Shogi.Tests.Core.TestData;
using FluentAssertions;
using Xunit;
using static CryHydrangea.Shogi.RawPieceType;

namespace CryHydrangea.Shogi.Tests;

public sealed class HandSubtractTest
{
    static readonly RawPieceType[] RawPieceTypeTestData = Enum.GetValues<RawPieceType>()
        .Where(static x => x is not NoPiece and not King)
        .ToArray();

    [Theory]
    [ClassData(typeof(HandPawnTestData))]
    public void 歩(uint count)
        => Test(Pawn, count, 18);

    [Theory]
    [ClassData(typeof(Hand2TestData))]
    public void 角飛(RawPieceType rawPieceType, uint count)
        => Test(rawPieceType, count, 2);

    [Theory]
    [ClassData(typeof(Hand4TestData))]
    public void 香桂銀金(RawPieceType rawPieceType, uint count)
        => Test(rawPieceType, count, 4);

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

        hand.Subtract(Pawn, 8);
        hand.Subtract(Bishop, 1);
        hand.Subtract(Rook, 2);
        hand.Subtract(Lance, 1);
        hand.Subtract(Knight, 2);
        hand.Subtract(Silver, 3);
        hand.Subtract(Gold, 4);

        foreach (var rawPieceType in RawPieceTypeTestData)
        {
            hand.GetCount(rawPieceType).Should().Be(0);
        }
    }

    static void Test(RawPieceType rawPieceType, uint count, uint maxCount)
    {
        var hand = Hand.Zero;

        hand.Add(rawPieceType, maxCount);
        hand.Subtract(rawPieceType, count);
        hand.GetCount(rawPieceType).Should().Be(maxCount - count);

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
