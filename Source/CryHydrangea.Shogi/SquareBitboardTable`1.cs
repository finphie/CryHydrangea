using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CryHydrangea.Shogi;

/// <summary>
/// <see cref="Square"/>に対応するビットを1にしたビットボードのテーブルです。
/// <see cref="Bitboard"/>構造体で使用する専用の構造体であり、
/// 配列のようにアクセスできます。
/// </summary>
/// <remarks>
/// 配列を使用すると<see cref="MemoryMarshal.GetArrayDataReference"/>を使用しても回避できない、余分なcmp命令が生成される。<br/>
/// そのため、専用の構造体を作成して最適化する。<br/>
/// （参考情報）<br/>
/// <see href="https://github.com/dotnet/runtime/issues/63541"/><br/>
/// <see href="https://github.com/dotnet/runtime/issues/64532"/>
/// </remarks>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
readonly partial struct SquareBitboardTable
{
    [Obsolete("Do not use default constructor.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable
    public SquareBitboardTable() => throw new NotSupportedException();
#pragma warning restore

    /// <summary>
    /// 指定されたマスに対応する、<see cref="Bitboard"/>構造体を返します。
    /// </summary>
    /// <param name="square">マス</param>
    /// <returns><paramref name="square"/>に対応するビットを1にした、<see cref="Bitboard"/>構造体のインスタンスを返します。</returns>
    public Bitboard this[Square square]
        => Unsafe.Add(ref Unsafe.AsRef(Value0), (nint)(uint)square);
}
