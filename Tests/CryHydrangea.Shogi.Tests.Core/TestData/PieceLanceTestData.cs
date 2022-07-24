using Xunit;
using static CryHydrangea.Shogi.Piece;

namespace CryHydrangea.Shogi.Tests.Core.TestData;

public sealed class PieceLanceTestData : TheoryData<Piece>
{
    public PieceLanceTestData()
    {
        Add(BlackLance);
        Add(WhiteLance);
    }
}
