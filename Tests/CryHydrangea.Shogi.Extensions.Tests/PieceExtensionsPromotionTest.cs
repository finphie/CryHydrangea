using CryHydrangea.Shogi.Tests.Core.TestData;
using FluentAssertions;
using Xunit;
using static CryHydrangea.Shogi.Piece;

namespace CryHydrangea.Shogi.Extensions.Tests;

public sealed class PieceExtensionsPromotionTest
{
    public static TheoryData<Piece, Piece> TestData => new()
    {
        { BlackPawn, BlackProPawn },
        { BlackLance, BlackProLance },
        { BlackKnight, BlackProKnight },
        { BlackSilver, BlackProSilver },
        { BlackBishop, BlackPegasus },
        { BlackRook, BlackDragon },
        { WhitePawn, WhiteProPawn },
        { WhiteLance, WhiteProLance },
        { WhiteKnight, WhiteProKnight },
        { WhiteSilver, WhiteProSilver },
        { WhiteBishop, WhitePegasus },
        { WhiteRook, WhiteDragon }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void DangerousPromotion_成れる駒_成駒を返す(Piece piece, Piece expected)
        => piece.DangerousPromotion().Should().Be(expected);

    [Theory]
    [MemberData(nameof(TestData))]
    public void TryPromotion_成れる駒_成駒を返す(Piece piece, Piece expected)
    {
        piece.TryPromotion(out var promotedPiece).Should().BeTrue();
        promotedPiece.Should().Be(expected);
    }

    [Theory]
    [InlineData(NoPiece)]
    [ClassData(typeof(PieceGoldTestData))]
    [ClassData(typeof(PieceKingTestData))]
    [ClassData(typeof(PieceProPieceTestData))]
    public void TryPromotion_成れない駒_falseを返す(Piece piece)
        => piece.TryPromotion(out _).Should().BeFalse();
}
