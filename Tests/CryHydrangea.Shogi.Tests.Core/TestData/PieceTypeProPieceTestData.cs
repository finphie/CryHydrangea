using Xunit;
using static CryHydrangea.Shogi.PieceType;

namespace CryHydrangea.Shogi.Tests.Core.TestData;

public sealed class PieceTypeProPieceTestData : TheoryData<PieceType>
{
    public PieceTypeProPieceTestData()
    {
        Add(ProPawn);
        Add(ProLance);
        Add(ProKnight);
        Add(ProSilver);
        Add(Pegasus);
        Add(Dragon);
    }
}
