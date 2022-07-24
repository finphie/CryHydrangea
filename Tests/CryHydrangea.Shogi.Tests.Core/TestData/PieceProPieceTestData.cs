using Xunit;
using static CryHydrangea.Shogi.Piece;

namespace CryHydrangea.Shogi.Tests.Core.TestData;

public sealed class PieceProPieceTestData : TheoryData<Piece>
{
    public PieceProPieceTestData()
    {
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
