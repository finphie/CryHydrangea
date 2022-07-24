using Xunit;
using static CryHydrangea.Shogi.Piece;

namespace CryHydrangea.Shogi.Tests.Core.TestData;

public sealed class PieceWhitePieceTestData : TheoryData<Piece>
{
    public PieceWhitePieceTestData()
    {
        Add(WhitePawn);
        Add(WhiteLance);
        Add(WhiteKnight);
        Add(WhiteSilver);
        Add(WhiteBishop);
        Add(WhiteRook);
        Add(WhiteGold);
        Add(WhiteKing);
        Add(WhiteProPawn);
        Add(WhiteProLance);
        Add(WhiteProKnight);
        Add(WhiteProSilver);
        Add(WhitePegasus);
        Add(WhiteDragon);
    }
}
