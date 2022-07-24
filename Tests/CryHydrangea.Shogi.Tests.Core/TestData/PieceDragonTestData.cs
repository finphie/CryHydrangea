using Xunit;
using static CryHydrangea.Shogi.Piece;

namespace CryHydrangea.Shogi.Tests.Core.TestData;

public sealed class PieceDragonTestData : TheoryData<Piece>
{
    public PieceDragonTestData()
    {
        Add(BlackDragon);
        Add(WhiteDragon);
    }
}
