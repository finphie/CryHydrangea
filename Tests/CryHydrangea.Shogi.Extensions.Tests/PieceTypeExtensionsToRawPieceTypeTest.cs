using FluentAssertions;
using Xunit;
using static CryHydrangea.Shogi.PieceType;

namespace CryHydrangea.Shogi.Extensions.Tests;

public sealed class PieceTypeExtensionsToRawPieceTypeTest
{
    [Fact]
    public void DangerousToRawPieceType_NoPiece_NoPieceを返す()
    {
        var expected = RawPieceType.NoPiece;
        NoPiece.DangerousToRawPieceType().Should().Be(expected);
    }

    [Theory]
    [InlineData(Pawn)]
    [InlineData(ProPawn)]
    public void DangerousToRawPieceType_歩と_歩を返す(PieceType pieceType)
    {
        var expected = RawPieceType.Pawn;
        pieceType.DangerousToRawPieceType().Should().Be(expected);
    }

    [Theory]
    [InlineData(Lance)]
    [InlineData(ProLance)]
    public void DangerousToRawPieceType_香成香_香を返す(PieceType pieceType)
    {
        var expected = RawPieceType.Lance;
        pieceType.DangerousToRawPieceType().Should().Be(expected);
    }

    [Theory]
    [InlineData(Knight)]
    [InlineData(ProKnight)]
    public void DangerousToRawPieceType_桂成桂_桂を返す(PieceType pieceType)
    {
        var expected = RawPieceType.Knight;
        pieceType.DangerousToRawPieceType().Should().Be(expected);
    }

    [Theory]
    [InlineData(Silver)]
    [InlineData(ProSilver)]
    public void DangerousToRawPieceType_銀成銀_銀を返す(PieceType pieceType)
    {
        var expected = RawPieceType.Silver;
        pieceType.DangerousToRawPieceType().Should().Be(expected);
    }

    [Theory]
    [InlineData(Bishop)]
    [InlineData(Pegasus)]
    public void DangerousToRawPieceType_角馬_角を返す(PieceType pieceType)
    {
        var expected = RawPieceType.Bishop;
        pieceType.DangerousToRawPieceType().Should().Be(expected);
    }

    [Theory]
    [InlineData(Rook)]
    [InlineData(Dragon)]
    public void DangerousToRawPieceType_飛龍_飛を返す(PieceType pieceType)
    {
        var expected = RawPieceType.Rook;
        pieceType.DangerousToRawPieceType().Should().Be(expected);
    }

    [Fact]
    public void DangerousToRawPieceType_金_金を返す()
    {
        var expected = RawPieceType.Gold;
        Gold.DangerousToRawPieceType().Should().Be(expected);
    }

    [Fact]
    public void ToRawPieceType_NoPiece_NoPieceを返す()
    {
        var expected = RawPieceType.NoPiece;
        NoPiece.ToRawPieceType().Should().Be(expected);
    }

    [Theory]
    [InlineData(Pawn)]
    [InlineData(ProPawn)]
    public void ToRawPieceType_歩と_歩を返す(PieceType pieceType)
    {
        var expected = RawPieceType.Pawn;
        pieceType.ToRawPieceType().Should().Be(expected);
    }

    [Theory]
    [InlineData(Lance)]
    [InlineData(ProLance)]
    public void ToRawPieceType_香成香_香を返す(PieceType pieceType)
    {
        var expected = RawPieceType.Lance;
        pieceType.ToRawPieceType().Should().Be(expected);
    }

    [Theory]
    [InlineData(Knight)]
    [InlineData(ProKnight)]
    public void ToRawPieceType_桂成桂_桂を返す(PieceType pieceType)
    {
        var expected = RawPieceType.Knight;
        pieceType.ToRawPieceType().Should().Be(expected);
    }

    [Theory]
    [InlineData(Silver)]
    [InlineData(ProSilver)]
    public void ToRawPieceType_銀成銀_銀を返す(PieceType pieceType)
    {
        var expected = RawPieceType.Silver;
        pieceType.ToRawPieceType().Should().Be(expected);
    }

    [Theory]
    [InlineData(Bishop)]
    [InlineData(Pegasus)]
    public void ToRawPieceType_角馬_角を返す(PieceType pieceType)
    {
        var expected = RawPieceType.Bishop;
        pieceType.ToRawPieceType().Should().Be(expected);
    }

    [Theory]
    [InlineData(Rook)]
    [InlineData(Dragon)]
    public void ToRawPieceType_飛龍_飛を返す(PieceType pieceType)
    {
        var expected = RawPieceType.Rook;
        pieceType.ToRawPieceType().Should().Be(expected);
    }

    [Fact]
    public void ToRawPieceType_金_金を返す()
    {
        var expected = RawPieceType.Gold;
        Gold.ToRawPieceType().Should().Be(expected);
    }

    [Fact]
    public void ToRawPieceType_王_王を返す()
    {
        var expected = RawPieceType.King;
        King.ToRawPieceType().Should().Be(expected);
    }
}
