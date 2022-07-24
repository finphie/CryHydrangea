using CryHydrangea.Shogi.Tests.Core.TestData;
using FluentAssertions;
using Xunit;

namespace CryHydrangea.Shogi.Extensions.Tests;

public sealed class PieceTypeExtensionsCanPromoteTest
{
    [Theory]
    [ClassData(typeof(PieceTypeRawPieceWithoutGoldKingTestData))]
    public void 成れる駒_trueを返す(PieceType pieceType)
        => pieceType.CanPromote().Should().BeTrue();

    [Theory]
    [InlineData(PieceType.NoPiece)]
    [InlineData(PieceType.Gold)]
    [InlineData(PieceType.King)]
    [ClassData(typeof(PieceTypeProPieceTestData))]
    public void 成れない駒_falseを返す(PieceType pieceType)
        => pieceType.CanPromote().Should().BeFalse();
}
