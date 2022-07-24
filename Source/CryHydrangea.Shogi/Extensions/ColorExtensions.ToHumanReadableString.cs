using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CryHydrangea.Shogi.Extensions;

/// <content>
/// 指定された手番から人間に読みやすい形式に変換した文字を取得する拡張メソッドです。
/// </content>
partial class ColorExtensions
{
    // TODO: UTF-8: void DangerousWriteHumanReadableString(this Color color, Span<byte> destination)
    // TODO: UTF-8: void TryWriteHumanReadableString(this Color color, Span<byte> destination)
    // TODO: UTF-8: byte[] ToHumanReadableUtf8String(this Color color)

    /// <summary>
    /// 指定された手番から人間に読みやすい形式に変換した文字を取得します。
    /// </summary>
    /// <param name="color">手番</param>
    /// <returns>指定された手番を、人間に読みやすい形式にした文字にして返します。</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ToHumanReadableChar(this Color color)
    {
        ReadOnlySpan<char> table = "☗☖";
        return Unsafe.Add(ref MemoryMarshal.GetReference(table), (nint)(uint)color);
    }
}
