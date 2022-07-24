using Xunit;
using static CryHydrangea.Shogi.Piece;

namespace CryHydrangea.Shogi.Tests.Core.TestData;

public sealed class PieceBlackPieceTestData : TheoryData<Piece>
{
    public PieceBlackPieceTestData()
    {
        Add(BlackPawn);
        Add(BlackLance);
        Add(BlackKnight);
        Add(BlackSilver);
        Add(BlackBishop);
        Add(BlackRook);
        Add(BlackGold);
        Add(BlackKing);
        Add(BlackProPawn);
        Add(BlackProLance);
        Add(BlackProKnight);
        Add(BlackProSilver);
        Add(BlackPegasus);
        Add(BlackDragon);
    }
}
