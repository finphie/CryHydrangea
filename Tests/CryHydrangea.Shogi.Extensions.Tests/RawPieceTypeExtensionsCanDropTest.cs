using CryHydrangea.Shogi.Tests.Core.TestData;
using FluentAssertions;
using Xunit;
using static CryHydrangea.Shogi.RawPieceType;

namespace CryHydrangea.Shogi.Extensions.Tests;

public sealed class RawPieceTypeExtensionsCanDropTest
{
    [Theory]
    [ClassData(typeof(RawPieceTypeWithoutKingTestData))]
    public void 手駒にできる駒_trueを返す(RawPieceType rawPieceType)
        => rawPieceType.CanDrop().Should().BeTrue();

    [Theory]
    [InlineData(NoPiece)]
    [InlineData(King)]
    public void 手駒にできない駒_falseを返す(RawPieceType rawPieceType)
        => rawPieceType.CanDrop().Should().BeFalse();
}
