using Xunit;
using static CryHydrangea.Shogi.Piece;

namespace CryHydrangea.Shogi.Tests.Core.TestData;

public sealed class PieceGoldTestData : TheoryData<Piece>
{
    public PieceGoldTestData()
    {
        Add(BlackGold);
        Add(WhiteGold);
    }
}
