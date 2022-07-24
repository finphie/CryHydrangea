using CryHydrangea.Shogi.Tests.Core.TestData;
using FluentAssertions;
using Xunit;

namespace CryHydrangea.Shogi.Tests;

public sealed class Move16MakeMoveTest
{
    static readonly Square[] SquareTestData = Enum.GetValues<Square>();

    [Fact]
    public void MakeMove()
    {
        foreach (var from in SquareTestData)
        {
            foreach (var to in SquareTestData)
            {
                var move = Move16.MakeMove(from, to);

                move.From.Should().Be(from);
                move.To.Should().Be(to);
                move.IsPromotion.Should().BeFalse();
                move.IsDrop.Should().BeFalse();
            }
        }
    }

    [Fact]
    public void MakePromoteMove()
    {
        foreach (var from in SquareTestData)
        {
            foreach (var to in SquareTestData)
            {
                var move = Move16.MakePromotionMove(from, to);

                move.From.Should().Be(from);
                move.To.Should().Be(to);
                move.IsPromotion.Should().BeTrue();
                move.IsDrop.Should().BeFalse();
            }
        }
    }

    [Theory]
    [ClassData(typeof(RawPieceTypeWithoutKingTestData))]
    public void MakeDropMove(RawPieceType rawPieceType)
    {
        foreach (var to in SquareTestData)
        {
            var move = Move16.MakeDropMove(rawPieceType, to);

            move.To.Should().Be(to);
            move.IsPromotion.Should().BeFalse();
            move.IsDrop.Should().BeTrue();
            move.DroppedPiece.Should().Be(rawPieceType);
        }
    }
}
