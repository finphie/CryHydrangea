using FluentAssertions;
using Xunit;
using static CryHydrangea.Shogi.RawPieceType;

namespace CryHydrangea.Shogi.Extensions.Tests;

public sealed class RawPieceTypeExtensionsTest
{
    [Theory]
    [InlineData(NoPiece, 'N')]
    [InlineData(Pawn, '歩')]
    [InlineData(Lance, '香')]
    [InlineData(Knight, '桂')]
    [InlineData(Silver, '銀')]
    [InlineData(Bishop, '角')]
    [InlineData(Rook, '飛')]
    [InlineData(Gold, '金')]
    [InlineData(King, '王')]
    public void ToHumanReadableChar_駒の種類_文字列を返す(RawPieceType rawPieceType, char expected)
        => rawPieceType.ToHumanReadableChar().Should().Be(expected);
}
