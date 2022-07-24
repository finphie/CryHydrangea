using Xunit;
using static CryHydrangea.Shogi.Piece;

namespace CryHydrangea.Shogi.Tests.Core.TestData;

public sealed class PieceKingTestData : TheoryData<Piece>
{
    public PieceKingTestData()
    {
        Add(BlackKing);
        Add(WhiteKing);
    }
}
