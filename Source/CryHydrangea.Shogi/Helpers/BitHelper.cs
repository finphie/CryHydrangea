using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CryHydrangea.Shogi.Helpers;

/// <summary>
/// ビット関連のヘルパークラスです。
/// </summary>
static class BitHelper
{
    /// <summary>
    /// 指定された位置にビットが設定されているか確認します。
    /// </summary>
    /// <param name="value">値</param>
    /// <param name="n">0～31までのビット位置</param>
    /// <returns>
    /// ビット位置<paramref name="n"/>にビットが設定されている場合は<see langword="true"/>を返します。
    /// 設定されていない場合は <see langword="false"/>を返します。
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool HasFlag(uint value, int n)
    {
        Debug.Assert((uint)n < (8 * sizeof(uint)) - 1, "ビット位置が範囲外です。");

        // n番目のビットを読み取り、byte型へダウンキャストする。
        var flag = (byte)((value >> n) & 1);

        // 0と比較を行わずにbyte型からbool型へ変換することで、
        // JITコンパイラが最適化を行うことができるようになる。
        return Unsafe.As<byte, bool>(ref flag);
    }
}
