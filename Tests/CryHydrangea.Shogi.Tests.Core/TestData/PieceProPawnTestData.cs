using Xunit;
using static CryHydrangea.Shogi.Piece;

namespace CryHydrangea.Shogi.Tests.Core.TestData;

public sealed class PieceProPawnTestData : TheoryData<Piece>
{
    public PieceProPawnTestData()
    {
        Add(BlackProPawn);
        Add(WhiteProPawn);
    }
}
