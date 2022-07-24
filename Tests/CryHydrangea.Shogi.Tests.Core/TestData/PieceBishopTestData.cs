using Xunit;
using static CryHydrangea.Shogi.Piece;

namespace CryHydrangea.Shogi.Tests.Core.TestData;

public sealed class PieceBishopTestData : TheoryData<Piece>
{
    public PieceBishopTestData()
    {
        Add(BlackBishop);
        Add(WhiteBishop);
    }
}
