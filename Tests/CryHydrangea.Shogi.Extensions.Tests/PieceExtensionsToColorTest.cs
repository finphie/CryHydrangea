using CryHydrangea.Shogi.Tests.Core.TestData;
using FluentAssertions;
using Xunit;

namespace CryHydrangea.Shogi.Extensions.Tests;

public sealed class PieceExtensionsToColorTest
{
    [Theory]
    [ClassData(typeof(PieceBlackPieceTestData))]
    public void DangerousToColor_先手の駒_先手番を返す(Piece piece)
    {
        var expected = Color.Black;
        piece.DangerousToColor().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PieceWhitePieceTestData))]
    public void DangerousToColor_後手の駒_後手番を返す(Piece piece)
    {
        var expected = Color.White;
        piece.DangerousToColor().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PieceBlackPieceTestData))]
    public void TryToColor_先手の駒_先手番を返す(Piece piece)
    {
        var expected = Color.Black;
        piece.TryToColor(out var color).Should().BeTrue();
        color.Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PieceWhitePieceTestData))]
    public void TryToColor_後手の駒_後手番を返す(Piece piece)
    {
        var expected = Color.White;
        piece.TryToColor(out var color).Should().BeTrue();
        color.Should().Be(expected);
    }

    [Fact]
    public void TryToColor_NoPiece_falseを返す()
        => Piece.NoPiece.TryToColor(out _).Should().BeFalse();
}
