using CryHydrangea.Shogi.Tests.Core.TestData;
using FluentAssertions;
using Xunit;

namespace CryHydrangea.Shogi.Extensions.Tests;

public sealed class PieceTypeExtensionsCanDropTest
{
    [Theory]
    [ClassData(typeof(PieceTypeRawPieceWithoutGoldKingTestData))]
    [InlineData(PieceType.Gold)]
    public void 手駒にできる駒_trueを返す(PieceType pieceType)
        => pieceType.CanDrop().Should().BeTrue();

    [Theory]
    [InlineData(PieceType.NoPiece)]
    [InlineData(PieceType.King)]
    [ClassData(typeof(PieceTypeProPieceTestData))]
    public void 手駒にできない駒_falseを返す(PieceType pieceType)
        => pieceType.CanDrop().Should().BeFalse();
}
