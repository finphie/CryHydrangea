using Xunit;
using static CryHydrangea.Shogi.Piece;

namespace CryHydrangea.Shogi.Tests.Core.TestData;

public sealed class PiecePawnTestData : TheoryData<Piece>
{
    public PiecePawnTestData()
    {
        Add(BlackPawn);
        Add(WhitePawn);
    }
}
