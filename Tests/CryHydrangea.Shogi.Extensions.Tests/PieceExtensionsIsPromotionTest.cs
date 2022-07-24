using CryHydrangea.Shogi.Tests.Core.TestData;
using FluentAssertions;
using Xunit;

namespace CryHydrangea.Shogi.Extensions.Tests;

public sealed class PieceExtensionsIsPromotionTest
{
    [Fact]
    public void DangerousIsPromotion_NoPiece_falseを返す()
        => Piece.NoPiece.DangerousIsPromotion().Should().BeFalse();

    [Theory]
    [ClassData(typeof(PieceProPieceTestData))]
    public void DangerousIsPromotion_成駒_trueを返す(Piece piece)
        => piece.DangerousIsPromotion().Should().BeTrue();

    [Theory]
    [ClassData(typeof(PieceGoldTestData))]
    [ClassData(typeof(PieceRawPieceWithoutGoldKingTestData))]
    public void DangerousIsPromotion_王を除く生駒_falseを返す(Piece piece)
        => piece.DangerousIsPromotion().Should().BeFalse();

    [Fact]
    public void IsPromotion_NoPiece_falseを返す()
        => Piece.NoPiece.IsPromotion().Should().BeFalse();

    [Theory]
    [ClassData(typeof(PieceProPieceTestData))]
    public void IsPromotion_成駒_trueを返す(Piece piece)
        => piece.IsPromotion().Should().BeTrue();

    [Theory]
    [ClassData(typeof(PieceRawPieceTestData))]
    public void IsPromotion_生駒_falseを返す(Piece piece)
        => piece.IsPromotion().Should().BeFalse();
}
