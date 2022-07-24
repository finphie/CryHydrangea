using FluentAssertions;
using Xunit;

namespace CryHydrangea.Shogi.Extensions.Tests;

public sealed class PieceTypeExtensionsToPieceTest
{
    public static TheoryData<PieceType, Piece> BlackPieceTestData => new()
    {
        { PieceType.Pawn, Piece.BlackPawn },
        { PieceType.Lance, Piece.BlackLance },
        { PieceType.Knight, Piece.BlackKnight },
        { PieceType.Silver, Piece.BlackSilver },
        { PieceType.Bishop, Piece.BlackBishop },
        { PieceType.Rook, Piece.BlackRook },
        { PieceType.Gold, Piece.BlackGold },
        { PieceType.King, Piece.BlackKing },
        { PieceType.ProPawn, Piece.BlackProPawn },
        { PieceType.ProLance, Piece.BlackProLance },
        { PieceType.ProKnight, Piece.BlackProKnight },
        { PieceType.ProSilver, Piece.BlackProSilver },
        { PieceType.Pegasus, Piece.BlackPegasus },
        { PieceType.Dragon, Piece.BlackDragon }
    };

    public static TheoryData<PieceType, Piece> WhitePieceTestData => new()
    {
        { PieceType.Pawn, Piece.WhitePawn },
        { PieceType.Lance, Piece.WhiteLance },
        { PieceType.Knight, Piece.WhiteKnight },
        { PieceType.Silver, Piece.WhiteSilver },
        { PieceType.Bishop, Piece.WhiteBishop },
        { PieceType.Rook, Piece.WhiteRook },
        { PieceType.Gold, Piece.WhiteGold },
        { PieceType.King, Piece.WhiteKing },
        { PieceType.ProPawn, Piece.WhiteProPawn },
        { PieceType.ProLance, Piece.WhiteProLance },
        { PieceType.ProKnight, Piece.WhiteProKnight },
        { PieceType.ProSilver, Piece.WhiteProSilver },
        { PieceType.Pegasus, Piece.WhitePegasus },
        { PieceType.Dragon, Piece.WhiteDragon }
    };

    [Theory]
    [MemberData(nameof(BlackPieceTestData))]
    public void DangerousToPiece_先手_先手の駒を返す(PieceType pieceType, Piece expected)
    {
        var color = Color.Black;
        pieceType.DangerousToPiece(color).Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(WhitePieceTestData))]
    public void DangerousToPiece_後手_後手の駒を返す(PieceType pieceType, Piece expected)
    {
        var color = Color.White;
        pieceType.DangerousToPiece(color).Should().Be(expected);
    }

    [Fact]
    public void ToPiece_NoPiece_NoPieceを返す()
    {
        var expected = Piece.NoPiece;
        var pieceType = PieceType.NoPiece;

        pieceType.ToPiece(Color.Black).Should().Be(expected);
        pieceType.ToPiece(Color.White).Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(BlackPieceTestData))]
    public void ToPiece_先手_先手の駒を返す(PieceType pieceType, Piece expected)
    {
        var color = Color.Black;
        pieceType.ToPiece(color).Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(WhitePieceTestData))]
    public void ToPiece_後手_後手の駒を返す(PieceType pieceType, Piece expected)
    {
        var color = Color.White;
        pieceType.ToPiece(color).Should().Be(expected);
    }
}
