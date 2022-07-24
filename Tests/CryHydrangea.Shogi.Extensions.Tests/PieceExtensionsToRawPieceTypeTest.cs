using CryHydrangea.Shogi.Tests.Core.TestData;
using FluentAssertions;
using Xunit;

namespace CryHydrangea.Shogi.Extensions.Tests;

public sealed class PieceExtensionsToRawPieceTypeTest
{
    [Fact]
    public void DangerousToRawPieceType_NoPiece_NoPieceを返す()
    {
        var expected = RawPieceType.NoPiece;
        Piece.NoPiece.DangerousToRawPieceType().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PiecePawnTestData))]
    [ClassData(typeof(PieceProPawnTestData))]
    public void DangerousToRawPieceType_歩と_歩を返す(Piece piece)
    {
        var expected = RawPieceType.Pawn;
        piece.DangerousToRawPieceType().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PieceLanceTestData))]
    [ClassData(typeof(PieceProLanceTestData))]
    public void DangerousToRawPieceType_香成香_香を返す(Piece piece)
    {
        var expected = RawPieceType.Lance;
        piece.DangerousToRawPieceType().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PieceKnightTestData))]
    [ClassData(typeof(PieceProKnightTestData))]
    public void DangerousToRawPieceType_桂成桂_桂を返す(Piece piece)
    {
        var expected = RawPieceType.Knight;
        piece.DangerousToRawPieceType().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PieceSilverTestData))]
    [ClassData(typeof(PieceProSilverTestData))]
    public void DangerousToRawPieceType_銀成銀_銀を返す(Piece piece)
    {
        var expected = RawPieceType.Silver;
        piece.DangerousToRawPieceType().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PieceBishopTestData))]
    [ClassData(typeof(PiecePegasusTestData))]
    public void DangerousToRawPieceType_角馬_角を返す(Piece piece)
    {
        var expected = RawPieceType.Bishop;
        piece.DangerousToRawPieceType().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PieceRookTestData))]
    [ClassData(typeof(PieceDragonTestData))]
    public void DangerousToRawPieceType_飛龍_飛を返す(Piece piece)
    {
        var expected = RawPieceType.Rook;
        piece.DangerousToRawPieceType().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PieceGoldTestData))]
    public void DangerousToRawPieceType_金_金を返す(Piece piece)
    {
        var expected = RawPieceType.Gold;
        piece.DangerousToRawPieceType().Should().Be(expected);
    }

    [Fact]
    public void ToRawPieceType_NoPiece_NoPieceを返す()
    {
        var expected = RawPieceType.NoPiece;
        Piece.NoPiece.ToRawPieceType().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PiecePawnTestData))]
    [ClassData(typeof(PieceProPawnTestData))]
    public void ToRawPieceType_歩と_歩を返す(Piece piece)
    {
        var expected = RawPieceType.Pawn;
        piece.ToRawPieceType().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PieceLanceTestData))]
    [ClassData(typeof(PieceProLanceTestData))]
    public void ToRawPieceType_香成香_香を返す(Piece piece)
    {
        var expected = RawPieceType.Lance;
        piece.ToRawPieceType().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PieceKnightTestData))]
    [ClassData(typeof(PieceProKnightTestData))]
    public void ToRawPieceType_桂成桂_桂を返す(Piece piece)
    {
        var expected = RawPieceType.Knight;
        piece.ToRawPieceType().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PieceSilverTestData))]
    [ClassData(typeof(PieceProSilverTestData))]
    public void ToRawPieceType_銀成銀_銀を返す(Piece piece)
    {
        var expected = RawPieceType.Silver;
        piece.ToRawPieceType().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PieceBishopTestData))]
    [ClassData(typeof(PiecePegasusTestData))]
    public void ToRawPieceType_角馬_角を返す(Piece piece)
    {
        var expected = RawPieceType.Bishop;
        piece.ToRawPieceType().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PieceRookTestData))]
    [ClassData(typeof(PieceDragonTestData))]
    public void ToRawPieceType_飛龍_飛を返す(Piece piece)
    {
        var expected = RawPieceType.Rook;
        piece.ToRawPieceType().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PieceGoldTestData))]
    public void ToRawPieceType_金_金を返す(Piece piece)
    {
        var expected = RawPieceType.Gold;
        piece.ToRawPieceType().Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(PieceKingTestData))]
    public void ToRawPieceType_王_王を返す(Piece piece)
    {
        var expected = RawPieceType.King;
        piece.ToRawPieceType().Should().Be(expected);
    }
}
