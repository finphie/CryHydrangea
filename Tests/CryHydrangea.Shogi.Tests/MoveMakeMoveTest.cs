using CryHydrangea.Shogi.Extensions;
using CryHydrangea.Shogi.Tests.Core.TestData;
using FluentAssertions;
using Xunit;

namespace CryHydrangea.Shogi.Tests;

public sealed class MoveMakeMoveTest
{
    static readonly Square[] SquareTestData = Enum.GetValues<Square>();

    [Theory]
    [ClassData(typeof(PieceTestData))]
    public void MakeMove(Piece piece)
    {
        foreach (var from in SquareTestData)
        {
            foreach (var to in SquareTestData)
            {
                var move = Move.MakeMove(from, to, piece);

                move.From.Should().Be(from);
                move.To.Should().Be(to);
                move.IsPromotion.Should().BeFalse();
                move.IsDrop.Should().BeFalse();
                move.Piece.Should().Be(piece);
                move.PieceAfterMove.Should().Be(piece);
                move.Color.Should().Be(piece.DangerousToColor());
            }
        }
    }

    [Theory]
    [ClassData(typeof(PieceRawPieceWithoutGoldKingTestData))]
    public void MakePromoteMove(Piece piece)
    {
        foreach (var from in SquareTestData)
        {
            foreach (var to in SquareTestData)
            {
                var move = Move.MakePromotionMove(from, to, piece);

                move.From.Should().Be(from);
                move.To.Should().Be(to);
                move.IsPromotion.Should().BeTrue();
                move.IsDrop.Should().BeFalse();
                move.Piece.Should().Be(piece);
                move.PieceAfterMove.Should().Be(piece.DangerousPromotion());
                move.Color.Should().Be(piece.DangerousToColor());
            }
        }
    }

    [Theory]
    [ClassData(typeof(RawPieceTypeWithoutKingTestData))]
    public void MakeDropMove(RawPieceType rawPieceType)
    {
        foreach (var to in SquareTestData)
        {
            Test(rawPieceType, to, Color.Black);
            Test(rawPieceType, to, Color.White);
        }

        static void Test(RawPieceType rawPieceType, Square to, Color color)
        {
            var move = Move.MakeDropMove(rawPieceType, to, color);
            var piece = rawPieceType.DangerousToPiece(color);

            move.To.Should().Be(to);
            move.IsPromotion.Should().BeFalse();
            move.IsDrop.Should().BeTrue();
            move.DroppedPiece.Should().Be(rawPieceType);
            move.Piece.Should().Be(piece);
            move.PieceAfterMove.Should().Be(piece);
            move.Color.Should().Be(color);
        }
    }
}
