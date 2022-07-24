using Xunit;
using static CryHydrangea.Shogi.Piece;

namespace CryHydrangea.Shogi.Tests.Core.TestData;

public sealed class PieceRawPieceTestData : TheoryData<Piece>
{
    public PieceRawPieceTestData()
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
    }
}
