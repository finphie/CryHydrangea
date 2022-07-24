using FluentAssertions;
using Xunit;
using static CryHydrangea.Shogi.PieceType;

namespace CryHydrangea.Shogi.Extensions.Tests;

public sealed class PieceTypeExtensionsTest
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
    [InlineData(ProPawn, 'と')]
    [InlineData(ProLance, '杏')]
    [InlineData(ProKnight, '圭')]
    [InlineData(ProSilver, '全')]
    [InlineData(Pegasus, '馬')]
    [InlineData(Dragon, '龍')]
    public void ToHumanReadableChar_駒の種類_文字列を返す(PieceType pieceType, char expected)
        => pieceType.ToHumanReadableChar().Should().Be(expected);
}
