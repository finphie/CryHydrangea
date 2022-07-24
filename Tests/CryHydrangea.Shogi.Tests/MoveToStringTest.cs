using CryHydrangea.Shogi.Extensions;
using FluentAssertions;
using Xunit;

namespace CryHydrangea.Shogi.Tests;

public sealed class MoveToStringTest
{
    [Theory]
    [InlineData(Square.Square11, Square.Square12, Piece.BlackPawn)]
    [InlineData(Square.Square11, Square.Square12, Piece.WhitePawn)]
    public void 移動する指し手_移動元移動先駒を返す(Square from, Square to, Piece piece)
    {
        var move = Move.MakeMove(from, to, piece);

        var expected = move.Color.ToHumanReadableChar().ToString();
        expected += from.ToHumanReadableString();
        expected += to.ToHumanReadableString();
        expected += piece.ToPieceType().ToHumanReadableChar();

        move.ToString().Should().Be(expected);
    }

    [Theory]
    [InlineData(Square.Square11, Square.Square12, Piece.BlackPawn)]
    [InlineData(Square.Square11, Square.Square12, Piece.WhitePawn)]
    public void 移動して成る指し手_移動元移動先駒成を返す(Square from, Square to, Piece piece)
    {
        var move = Move.MakePromotionMove(from, to, piece);

        var expected = move.Color.ToHumanReadableChar().ToString();
        expected += from.ToHumanReadableString();
        expected += to.ToHumanReadableString();
        expected += piece.ToPieceType().ToHumanReadableChar();
        expected += '成';

        move.ToString().Should().Be(expected);
    }

    [Theory]
    [InlineData(RawPieceType.Pawn, Square.Square12, Color.Black)]
    [InlineData(RawPieceType.Pawn, Square.Square12, Color.White)]
    public void 駒打ち_打つマス駒打を返す(RawPieceType rawPieceType, Square to, Color color)
    {
        var move = Move.MakeDropMove(rawPieceType, to, color);

        var expected = color.ToHumanReadableChar().ToString();
        expected += to.ToHumanReadableString();
        expected += rawPieceType.ToHumanReadableChar();
        expected += '打';

        move.ToString().Should().Be(expected);
    }

    [Fact]
    public void None_Noneを返す()
        => Move.None.ToString().Should().Be(nameof(Move.None));

    [Fact]
    public void Null_Nullを返す()
        => Move.Null.ToString().Should().Be(nameof(Move.Null));

    [Fact]
    public void Resign_Resignを返す()
        => Move.Resign.ToString().Should().Be(nameof(Move.Resign));
}
