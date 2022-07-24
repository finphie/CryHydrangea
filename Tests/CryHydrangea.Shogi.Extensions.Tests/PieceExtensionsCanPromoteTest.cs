using CryHydrangea.Shogi.Tests.Core.TestData;
using FluentAssertions;
using Xunit;

namespace CryHydrangea.Shogi.Extensions.Tests;

public sealed class PieceExtensionsCanPromoteTest
{
    [Theory]
    [ClassData(typeof(PieceRawPieceWithoutGoldKingTestData))]
    public void 成れる駒_trueを返す(Piece piece)
        => piece.CanPromote().Should().BeTrue();

    [Theory]
    [InlineData(Piece.NoPiece)]
    [ClassData(typeof(PieceGoldTestData))]
    [ClassData(typeof(PieceKingTestData))]
    [ClassData(typeof(PieceProPieceTestData))]
    public void 成れない駒_falseを返す(Piece piece)
        => piece.CanPromote().Should().BeFalse();
}
