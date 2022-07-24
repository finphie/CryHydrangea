using static CryHydrangea.Shogi.RawPieceType;

namespace CryHydrangea.Shogi.Tests.Core.TestData;

public sealed class Hand4TestData : HandTestData
{
    public Hand4TestData()
        : base(4, Lance, Knight, Silver, Gold)
    {
    }
}
