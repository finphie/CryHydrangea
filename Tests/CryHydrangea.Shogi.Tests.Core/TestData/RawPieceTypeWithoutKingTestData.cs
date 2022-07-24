using Xunit;
using static CryHydrangea.Shogi.RawPieceType;

namespace CryHydrangea.Shogi.Tests.Core.TestData;

public sealed class RawPieceTypeWithoutKingTestData : TheoryData<RawPieceType>
{
    public RawPieceTypeWithoutKingTestData()
    {
        Add(Pawn);
        Add(Lance);
        Add(Knight);
        Add(Silver);
        Add(Bishop);
        Add(Rook);
        Add(Gold);
    }
}
