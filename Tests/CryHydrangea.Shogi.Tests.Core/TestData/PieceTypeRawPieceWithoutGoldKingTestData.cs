using Xunit;
using static CryHydrangea.Shogi.PieceType;

namespace CryHydrangea.Shogi.Tests.Core.TestData;

public sealed class PieceTypeRawPieceWithoutGoldKingTestData : TheoryData<PieceType>
{
    public PieceTypeRawPieceWithoutGoldKingTestData()
    {
        Add(Pawn);
        Add(Lance);
        Add(Knight);
        Add(Silver);
        Add(Bishop);
        Add(Rook);
    }
}
