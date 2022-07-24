using Xunit;
using static CryHydrangea.Shogi.PieceType;

namespace CryHydrangea.Shogi.Tests.Core.TestData;

public sealed class PieceTypeRawPieceTestData : TheoryData<PieceType>
{
    public PieceTypeRawPieceTestData()
    {
        Add(Pawn);
        Add(Lance);
        Add(Knight);
        Add(Silver);
        Add(Bishop);
        Add(Rook);
        Add(Gold);
        Add(King);
    }
}
