using FluentAssertions;
using Xunit;

namespace CryHydrangea.Shogi.Extensions.Tests;

public sealed class RawPieceTypeExtensionsToPieceTest
{
    public static TheoryData<RawPieceType, Piece> TestData => new()
    {
        { RawPieceType.Pawn, Piece.BlackPawn },
        { RawPieceType.Lance, Piece.BlackLance },
        { RawPieceType.Knight, Piece.BlackKnight },
        { RawPieceType.Silver, Piece.BlackSilver },
        { RawPieceType.Bishop, Piece.BlackBishop },
        { RawPieceType.Rook, Piece.BlackRook },
        { RawPieceType.Gold, Piece.BlackGold },
        { RawPieceType.King, Piece.BlackKing }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void DangerousToPiece_生駒の種類_先手の駒を返す(RawPieceType rawPieceType, Piece expected)
    {
        var color = Color.Black;
        rawPieceType.DangerousToPiece(color).Should().Be(expected);
    }

    [Fact]
    public void ToPiece_NoPiece_NoPieceを返す()
    {
        var expected = Piece.NoPiece;
        var pieceType = RawPieceType.NoPiece;

        pieceType.ToPiece(Color.Black).Should().Be(expected);
        pieceType.ToPiece(Color.White).Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void ToPiece_生駒の種類_先手の駒を返す(RawPieceType rawPieceType, Piece expected)
    {
        var color = Color.Black;
        rawPieceType.ToPiece(color).Should().Be(expected);
    }
}
