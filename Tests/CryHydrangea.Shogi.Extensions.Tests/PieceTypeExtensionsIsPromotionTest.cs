using CryHydrangea.Shogi.Tests.Core.TestData;
using FluentAssertions;
using Xunit;

namespace CryHydrangea.Shogi.Extensions.Tests;
public sealed class PieceTypeExtensionsIsPromotionTest
{
    [Fact]
    public void DangerousIsPromotion_NoPiece_falseを返す()
        => PieceType.NoPiece.DangerousIsPromotion().Should().BeFalse();

    [Theory]
    [ClassData(typeof(PieceTypeProPieceTestData))]
    public void DangerousIsPromotion_成駒_trueを返す(PieceType piece)
        => piece.DangerousIsPromotion().Should().BeTrue();

    [Theory]
    [ClassData(typeof(PieceTypeRawPieceWithoutGoldKingTestData))]
    [InlineData(PieceType.Gold)]
    public void DangerousIsPromotion_王を除く生駒_falseを返す(PieceType piece)
        => piece.DangerousIsPromotion().Should().BeFalse();

    [Fact]
    public void IsPromotion_NoPiece_falseを返す()
        => PieceType.NoPiece.IsPromotion().Should().BeFalse();

    [Theory]
    [ClassData(typeof(PieceTypeProPieceTestData))]
    public void IsPromotion_成駒_trueを返す(PieceType piece)
        => piece.IsPromotion().Should().BeTrue();

    [Theory]
    [ClassData(typeof(PieceTypeRawPieceTestData))]
    public void IsPromotion_生駒_falseを返す(PieceType piece)
        => piece.IsPromotion().Should().BeFalse();
}
