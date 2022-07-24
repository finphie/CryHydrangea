using CryHydrangea.Shogi.Tests.Core.TestData;
using FluentAssertions;
using Xunit;

namespace CryHydrangea.Shogi.Extensions.Tests;

public sealed class PieceExtensionsCanDropTest
{
    [Theory]
    [ClassData(typeof(PieceRawPieceWithoutGoldKingTestData))]
    [ClassData(typeof(PieceGoldTestData))]
    public void 手駒にできる駒_trueを返す(Piece piece)
        => piece.CanDrop().Should().BeTrue();

    [Theory]
    [InlineData(Piece.NoPiece)]
    [ClassData(typeof(PieceKingTestData))]
    [ClassData(typeof(PieceProPieceTestData))]
    public void 手駒にできない駒_falseを返す(Piece piece)
        => piece.CanDrop().Should().BeFalse();
}
