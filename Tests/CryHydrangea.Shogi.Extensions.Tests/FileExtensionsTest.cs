using FluentAssertions;
using Xunit;
using static CryHydrangea.Shogi.File;

namespace CryHydrangea.Shogi.Extensions.Tests;
public sealed class FileExtensionsTest
{
    [Theory]
    [InlineData(File1, '１')]
    [InlineData(File2, '２')]
    [InlineData(File3, '３')]
    [InlineData(File4, '４')]
    [InlineData(File5, '５')]
    [InlineData(File6, '６')]
    [InlineData(File7, '７')]
    [InlineData(File8, '８')]
    [InlineData(File9, '９')]
    public void ToHumanReadableChar_筋_文字列を返す(File file, char expected)
        => file.ToHumanReadableChar().Should().Be(expected);
}
