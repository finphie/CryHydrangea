using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CryHydrangea.Shogi.Extensions;

/// <summary>
/// <see cref="File"/>関連の拡張メソッド集です。
/// </summary>
public static class FileExtensions
{
    // TODO: UTF-8: void DangerousWriteHumanReadableString(this File file, Span<byte> destination)
    // TODO: UTF-8: void TryWriteHumanReadableString(this File file, Span<byte> destination)
    // TODO: UTF-8: byte[] ToHumanReadableUtf8String(this File file)

    /// <summary>
    /// 指定された筋から人間に読みやすい形式に変換した文字を取得します。
    /// </summary>
    /// <param name="file">筋</param>
    /// <returns>指定された筋を、人間に読みやすい形式にした文字にして返します。</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ToHumanReadableChar(this File file)
    {
        ReadOnlySpan<char> table = "１２３４５６７８９";
        return Unsafe.Add(ref MemoryMarshal.GetReference(table), (nint)(uint)file);
    }
}
