using System.Text;

namespace CryHydrangea.Shogi.Usi;

public static class Usi
{
    static readonly Stream ConsoleStream = Console.OpenStandardOutput();

    public static void A()
        => Console.OutputEncoding = new UTF8Encoding(false);

    public static void OutputInfoString(ReadOnlySpan<byte> value)
    {
        // lock
        ConsoleStream.Write(value);
    }
}
