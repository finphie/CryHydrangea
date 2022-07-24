using FluentAssertions;
using Xunit;

namespace CryHydrangea.Shogi.Extensions.Tests;

public sealed class RawPieceTypeExtensionsToPieceTypeTest
{
    [Fact]
    public void NoPiece_NoPieceを返す()
    {
        var expected = PieceType.NoPiece;
        RawPieceType.NoPiece.ToPieceType().Should().Be(expected);
    }

    [Theory]
    [InlineData(RawPieceType.Pawn, PieceType.Pawn)]
    [InlineData(RawPieceType.Lance, PieceType.Lance)]
    [InlineData(RawPieceType.Knight, PieceType.Knight)]
    [InlineData(RawPieceType.Silver, PieceType.Silver)]
    [InlineData(RawPieceType.Bishop, PieceType.Bishop)]
    [InlineData(RawPieceType.Rook, PieceType.Rook)]
    [InlineData(RawPieceType.Gold, PieceType.Gold)]
    [InlineData(RawPieceType.King, PieceType.King)]
    public void 生駒_駒の種類を返す(RawPieceType rawPieceType, PieceType expected)
        => rawPieceType.ToPieceType().Should().Be(expected);
}
