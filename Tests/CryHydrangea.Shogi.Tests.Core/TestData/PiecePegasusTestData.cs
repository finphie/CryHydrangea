using Xunit;
using static CryHydrangea.Shogi.Piece;

namespace CryHydrangea.Shogi.Tests.Core.TestData;

public sealed class PiecePegasusTestData : TheoryData<Piece>
{
    public PiecePegasusTestData()
    {
        Add(BlackPegasus);
        Add(WhitePegasus);
    }
}
