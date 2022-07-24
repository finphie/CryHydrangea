using CryHydrangea.Shogi.Tests.Core.TestData;
using FluentAssertions;
using Xunit;
using static CryHydrangea.Shogi.PieceType;

namespace CryHydrangea.Shogi.Extensions.Tests;

public sealed class PieceTypeExtensionsPromotionTest
{
    public static TheoryData<PieceType, PieceType> TestData => new()
    {
        { Pawn, ProPawn },
        { Lance, ProLance },
        { Knight, ProKnight },
        { Silver, ProSilver },
        { Bishop, Pegasus },
        { Rook, Dragon }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void DangerousPromotion_成れる駒_成駒を返す(PieceType pieceType, PieceType expected)
        => pieceType.DangerousPromotion().Should().Be(expected);

    [Theory]
    [MemberData(nameof(TestData))]
    public void TryPromotion_成れる駒_成駒を返す(PieceType pieceType, PieceType expected)
    {
        pieceType.TryPromotion(out var promotedPiece).Should().BeTrue();
        promotedPiece.Should().Be(expected);
    }

    [Theory]
    [InlineData(NoPiece)]
    [InlineData(Gold)]
    [InlineData(King)]
    [ClassData(typeof(PieceTypeProPieceTestData))]
    public void TryPromotion_成れない駒_falseを返す(PieceType pieceType)
        => pieceType.TryPromotion(out _).Should().BeFalse();
}
