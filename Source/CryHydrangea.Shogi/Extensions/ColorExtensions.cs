using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using static CryHydrangea.Shogi.Color;

namespace CryHydrangea.Shogi.Extensions;

/// <summary>
/// <see cref="Color"/>列挙型関連の拡張メソッド集です。
/// </summary>
public static partial class ColorExtensions
{
    /// <summary>
    /// 手番を変更します。
    /// </summary>
    /// <param name="color">現在の手番</param>
    /// <returns>
    /// 現在の手番が<see cref="Black"/>なら<see cref="White"/>を返します。
    /// <see cref="White"/>なら<see cref="Black"/>を返します。
    /// </returns>
    [SuppressMessage("Style", "IDE0022:メソッドに式本体を使用する", Justification = "可読性のため")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color ToOpponent(this Color color)
    {
        // Color型は0または1なので、現在の手番の否定で相手の手番に変換できる。
        return ~color;
    }
}
