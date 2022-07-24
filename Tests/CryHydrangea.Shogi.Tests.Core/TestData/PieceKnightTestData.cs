using Xunit;
using static CryHydrangea.Shogi.Piece;

namespace CryHydrangea.Shogi.Tests.Core.TestData;

public sealed class PieceKnightTestData : TheoryData<Piece>
{
    public PieceKnightTestData()
    {
        Add(BlackKnight);
        Add(WhiteKnight);
    }
}
