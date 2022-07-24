using Xunit;
using static CryHydrangea.Shogi.Piece;

namespace CryHydrangea.Shogi.Tests.Core.TestData;

public sealed class PieceTestData : TheoryData<Piece>
{
    public PieceTestData()
    {
        Add(BlackPawn);
        Add(WhitePawn);

        Add(BlackLance);
        Add(WhiteLance);

        Add(BlackKnight);
        Add(WhiteKnight);

        Add(BlackSilver);
        Add(WhiteSilver);

        Add(BlackBishop);
        Add(WhiteBishop);

        Add(BlackRook);
        Add(WhiteRook);

        Add(BlackGold);
        Add(WhiteGold);

        Add(BlackKing);
        Add(WhiteKing);

        Add(BlackProPawn);
        Add(WhiteProPawn);

        Add(BlackProLance);
        Add(WhiteProLance);

        Add(BlackProKnight);
        Add(WhiteProKnight);

        Add(BlackProSilver);
        Add(WhiteProSilver);

        Add(BlackPegasus);
        Add(WhitePegasus);

        Add(BlackDragon);
        Add(WhiteDragon);
    }
}
