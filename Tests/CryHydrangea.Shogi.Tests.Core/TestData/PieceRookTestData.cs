using Xunit;
using static CryHydrangea.Shogi.Piece;

namespace CryHydrangea.Shogi.Tests.Core.TestData;

public sealed class PieceRookTestData : TheoryData<Piece>
{
    public PieceRookTestData()
    {
        Add(BlackRook);
        Add(WhiteRook);
    }
}
