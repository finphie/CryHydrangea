using Xunit;

namespace CryHydrangea.Shogi.Tests.Core.TestData;

public sealed class HandPawnTestData : TheoryData<int>
{
    public HandPawnTestData()
    {
        for (var i = 1; i <= 18; i++)
        {
            Add(i);
        }
    }
}
