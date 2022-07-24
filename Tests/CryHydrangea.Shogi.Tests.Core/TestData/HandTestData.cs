using Xunit;

namespace CryHydrangea.Shogi.Tests.Core.TestData;

public abstract class HandTestData : TheoryData<RawPieceType, int>
{
    protected HandTestData(int count, params RawPieceType[] rawPieceTypes)
    {
        foreach (var rawPieceType in rawPieceTypes)
        {
            for (var i = 1; i <= count; i++)
            {
                Add(rawPieceType, i);
            }
        }
    }
}
