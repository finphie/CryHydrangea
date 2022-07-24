using CryHydrangea.Shogi.Tests.Core.TestData;
using FluentAssertions;
using Xunit;
using static CryHydrangea.Shogi.RawPieceType;

namespace CryHydrangea.Shogi.Tests;

public sealed class HandIsEqualOrSuperiorTest
{
    [Theory]
    [ClassData(typeof(HandPawnTestData))]
    public void 歩_trueを返す(uint count)
        => TrueTest(Pawn, count);

    [Theory]
    [ClassData(typeof(Hand2TestData))]
    public void 角飛_trueを返す(RawPieceType rawPieceType, uint count)
        => TrueTest(rawPieceType, count);

    [Theory]
    [ClassData(typeof(Hand4TestData))]
    public void 香桂銀金_trueを返す(RawPieceType rawPieceType, uint count)
        => TrueTest(rawPieceType, count);

    [Fact]
    public void 混合_trueを返す()
    {
        var (handA, handB) = CreateHand();

        handA.IsEqualOrSuperior(handB).Should().BeTrue();
        handA.IsEqualOrSuperior(handA).Should().BeTrue();
        handB.IsEqualOrSuperior(handB).Should().BeTrue();
    }

    [Theory]
    [ClassData(typeof(HandPawnTestData))]
    public void 歩_falseを返す(uint count)
        => FalseTest(Pawn, count);

    [Theory]
    [ClassData(typeof(Hand2TestData))]
    public void 角飛_falseを返す(RawPieceType rawPieceType, uint count)
        => FalseTest(rawPieceType, count);

    [Theory]
    [ClassData(typeof(Hand4TestData))]
    public void 香桂銀金_falseを返す(RawPieceType rawPieceType, uint count)
        => FalseTest(rawPieceType, count);

    [Fact]
    public void 混合_falseを返す()
    {
        var (handB, handA) = CreateHand();
        handA.IsEqualOrSuperior(handB).Should().BeFalse();
    }

    static void TrueTest(RawPieceType rawPieceType, uint count)
    {
        var handA = Hand.Zero;
        var handB = Hand.Zero;

        handA.Add(rawPieceType, count);

        for (var i = 0; i < count; i++)
        {
            handA.IsEqualOrSuperior(handB).Should().BeTrue();
            handB.Add(rawPieceType);
        }

        handA.IsEqualOrSuperior(handB).Should().BeTrue();
    }

    static void FalseTest(RawPieceType rawPieceType, uint count)
    {
        var handA = Hand.Zero;
        var handB = Hand.Zero;

        handB.Add(rawPieceType, count);

        for (var i = 0; i < count; i++)
        {
            handA.IsEqualOrSuperior(handB).Should().BeFalse();
            handB.Subtract(rawPieceType);
        }

        handA.IsEqualOrSuperior(handB).Should().BeTrue();
    }

    static (Hand A, Hand B) CreateHand()
    {
        var handA = Hand.Zero;
        var handB = Hand.Zero;

        handA.Add(Pawn, 8);
        handA.Add(Bishop, 2);
        handA.Add(Rook, 2);
        handA.Add(Lance, 4);
        handA.Add(Knight, 4);
        handA.Add(Silver, 4);
        handA.Add(Gold, 4);

        handB.Add(Pawn, 7);
        handB.Add(Bishop, 1);
        handB.Add(Rook, 1);
        handB.Add(Lance, 3);
        handB.Add(Knight, 3);
        handB.Add(Silver, 3);
        handB.Add(Gold, 3);

        return (handA, handB);
    }
}
