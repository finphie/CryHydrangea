using Xunit;
using static CryHydrangea.Shogi.Piece;

namespace CryHydrangea.Shogi.Tests.Core.TestData;

public sealed class PieceProLanceTestData : TheoryData<Piece>
{
    public PieceProLanceTestData()
    {
        Add(BlackProLance);
        Add(WhiteProLance);
    }
}
