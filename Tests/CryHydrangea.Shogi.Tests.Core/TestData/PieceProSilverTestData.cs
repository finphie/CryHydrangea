using Xunit;
using static CryHydrangea.Shogi.Piece;

namespace CryHydrangea.Shogi.Tests.Core.TestData;

public sealed class PieceProSilverTestData : TheoryData<Piece>
{
    public PieceProSilverTestData()
    {
        Add(BlackProSilver);
        Add(WhiteProSilver);
    }
}
