using Xunit;
using static CryHydrangea.Shogi.Piece;

namespace CryHydrangea.Shogi.Tests.Core.TestData;

public sealed class PieceSilverTestData : TheoryData<Piece>
{
    public PieceSilverTestData()
    {
        Add(BlackSilver);
        Add(WhiteSilver);
    }
}
