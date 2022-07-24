using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CryHydrangea.Shogi.Extensions;

/// <summary>
/// <see cref="Rank"/>関連の拡張メソッド集です。
/// </summary>
public static class RankExtensions
{
    /// <summary>
    /// 指定された段から人間に読みやすい形式に変換した文字を取得します。
    /// </summary>
    /// <param name="rank">段</param>
    /// <returns>指定された段を、人間に読みやすい形式にした文字にして返します。</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ToHumanReadableChar(this Rank rank)
    {
        ReadOnlySpan<char> table = "一二三四五六七八九";
        return Unsafe.Add(ref MemoryMarshal.GetReference(table), (nint)(uint)rank);
    }
}
