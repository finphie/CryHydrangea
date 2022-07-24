using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static CryHydrangea.Shogi.File;
using static CryHydrangea.Shogi.Rank;

namespace CryHydrangea.Shogi.Extensions;

/// <summary>
/// <see cref="Square"/>関連の拡張メソッド集です。
/// </summary>
public static partial class SquareExtensions
{
    /// <summary>
    /// マスから筋に変換するためのテーブルです。
    /// </summary>
    /// <remarks>
    /// <![CDATA[ReadOnlySpan<byte>]]>にしてJITコンパイラに最適化させる。
    /// </remarks>
    /// <value>
    /// <see cref="Square"/>に対応する<see cref="File"/>を取得するためのテーブルです。
    /// </value>
    static ReadOnlySpan<byte> SquareToFile => new[]
    {
        (byte)File1, (byte)File1, (byte)File1, (byte)File1, (byte)File1, (byte)File1, (byte)File1, (byte)File1, (byte)File1,
        (byte)File2, (byte)File2, (byte)File2, (byte)File2, (byte)File2, (byte)File2, (byte)File2, (byte)File2, (byte)File2,
        (byte)File3, (byte)File3, (byte)File3, (byte)File3, (byte)File3, (byte)File3, (byte)File3, (byte)File3, (byte)File3,
        (byte)File4, (byte)File4, (byte)File4, (byte)File4, (byte)File4, (byte)File4, (byte)File4, (byte)File4, (byte)File4,
        (byte)File5, (byte)File5, (byte)File5, (byte)File5, (byte)File5, (byte)File5, (byte)File5, (byte)File5, (byte)File5,
        (byte)File6, (byte)File6, (byte)File6, (byte)File6, (byte)File6, (byte)File6, (byte)File6, (byte)File6, (byte)File6,
        (byte)File7, (byte)File7, (byte)File7, (byte)File7, (byte)File7, (byte)File7, (byte)File7, (byte)File7, (byte)File7,
        (byte)File8, (byte)File8, (byte)File8, (byte)File8, (byte)File8, (byte)File8, (byte)File8, (byte)File8, (byte)File8,
        (byte)File9, (byte)File9, (byte)File9, (byte)File9, (byte)File9, (byte)File9, (byte)File9, (byte)File9, (byte)File9
    };

    /// <summary>
    /// マスから段に変換するためのテーブルです。
    /// </summary>
    /// <remarks>
    /// <![CDATA[ReadOnlySpan<byte>]]>にしてJITコンパイラに最適化させる。
    /// </remarks>
    /// <value>
    /// <see cref="Square"/>に対応する<see cref="Rank"/>を取得するためのテーブルです。
    /// </value>
    static ReadOnlySpan<byte> SquareToRank => new[]
    {
        (byte)Rank1, (byte)Rank2, (byte)Rank3, (byte)Rank4, (byte)Rank5, (byte)Rank6, (byte)Rank7, (byte)Rank8, (byte)Rank9,
        (byte)Rank1, (byte)Rank2, (byte)Rank3, (byte)Rank4, (byte)Rank5, (byte)Rank6, (byte)Rank7, (byte)Rank8, (byte)Rank9,
        (byte)Rank1, (byte)Rank2, (byte)Rank3, (byte)Rank4, (byte)Rank5, (byte)Rank6, (byte)Rank7, (byte)Rank8, (byte)Rank9,
        (byte)Rank1, (byte)Rank2, (byte)Rank3, (byte)Rank4, (byte)Rank5, (byte)Rank6, (byte)Rank7, (byte)Rank8, (byte)Rank9,
        (byte)Rank1, (byte)Rank2, (byte)Rank3, (byte)Rank4, (byte)Rank5, (byte)Rank6, (byte)Rank7, (byte)Rank8, (byte)Rank9,
        (byte)Rank1, (byte)Rank2, (byte)Rank3, (byte)Rank4, (byte)Rank5, (byte)Rank6, (byte)Rank7, (byte)Rank8, (byte)Rank9,
        (byte)Rank1, (byte)Rank2, (byte)Rank3, (byte)Rank4, (byte)Rank5, (byte)Rank6, (byte)Rank7, (byte)Rank8, (byte)Rank9,
        (byte)Rank1, (byte)Rank2, (byte)Rank3, (byte)Rank4, (byte)Rank5, (byte)Rank6, (byte)Rank7, (byte)Rank8, (byte)Rank9,
        (byte)Rank1, (byte)Rank2, (byte)Rank3, (byte)Rank4, (byte)Rank5, (byte)Rank6, (byte)Rank7, (byte)Rank8, (byte)Rank9
    };

    /// <summary>
    /// 筋を取得します。
    /// </summary>
    /// <param name="square">マス目</param>
    /// <returns><paramref name="square"/>に対応する筋を返します。</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static File ToFile(this Square square)
        => (File)Unsafe.Add(ref MemoryMarshal.GetReference(SquareToFile), (nint)(uint)square);

    /// <summary>
    /// 段を取得します。
    /// </summary>
    /// <param name="square">マス目</param>
    /// <returns><paramref name="square"/>に対応する段を返します。</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Rank ToRank(this Square square)
        => (Rank)Unsafe.Add(ref MemoryMarshal.GetReference(SquareToRank), (nint)(uint)square);

    public static void WriteUsiString(this Square square, Span<byte> destination)
    {

    }
}
