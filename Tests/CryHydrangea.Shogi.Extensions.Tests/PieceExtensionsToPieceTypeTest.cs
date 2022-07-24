using CryHydrangea.Shogi.Tests.Core.TestData;
using FluentAssertions;
using Xunit;

namespace CryHydrangea.Shogi.Extensions.Tests;

public sealed class PieceExtensionsToPieceTypeTest
{
    [Fact]
    public void NoPiece_NoPieceを返す()
    {
        var expected = PieceType.NoPiece;
        Piece.NoPiece.ToPieceType().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PiecePawnTestData))]
    public void 歩_歩を返す(Piece piece)
    {
        var expected = PieceType.Pawn;
        piece.ToPieceType().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PieceLanceTestData))]
    public void 香_香を返す(Piece piece)
    {
        var expected = PieceType.Lance;
        piece.ToPieceType().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PieceKnightTestData))]
    public void 桂_桂を返す(Piece piece)
    {
        var expected = PieceType.Knight;
        piece.ToPieceType().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PieceSilverTestData))]
    public void 銀_銀を返す(Piece piece)
    {
        var expected = PieceType.Silver;
        piece.ToPieceType().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PieceBishopTestData))]
    public void 角_角を返す(Piece piece)
    {
        var expected = PieceType.Bishop;
        piece.ToPieceType().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PieceRookTestData))]
    public void 飛_飛を返す(Piece piece)
    {
        var expected = PieceType.Rook;
        piece.ToPieceType().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PieceGoldTestData))]
    public void 金_金を返す(Piece piece)
    {
        var expected = PieceType.Gold;
        piece.ToPieceType().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PieceKingTestData))]
    public void 王_王を返す(Piece piece)
    {
        var expected = PieceType.King;
        piece.ToPieceType().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PieceProPawnTestData))]
    public void と_とを返す(Piece piece)
    {
        var expected = PieceType.ProPawn;
        piece.ToPieceType().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PieceProLanceTestData))]
    public void 成香_成香を返す(Piece piece)
    {
        var expected = PieceType.ProLance;
        piece.ToPieceType().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PieceProKnightTestData))]
    public void 成桂_成桂を返す(Piece piece)
    {
        var expected = PieceType.ProKnight;
        piece.ToPieceType().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PieceProSilverTestData))]
    public void 成銀_成銀を返す(Piece piece)
    {
        var expected = PieceType.ProSilver;
        piece.ToPieceType().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PiecePegasusTestData))]
    public void 馬_馬を返す(Piece piece)
    {
        var expected = PieceType.Pegasus;
        piece.ToPieceType().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PieceDragonTestData))]
    public void 龍_龍を返す(Piece piece)
    {
        var expected = PieceType.Dragon;
        piece.ToPieceType().Should().Be(expected);
    }
}
