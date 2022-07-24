using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using CryHydrangea.Shogi.Helpers;
using static CryHydrangea.Shogi.PieceType;

namespace CryHydrangea.Shogi.Extensions;

/// <content>
/// 指定された駒が成駒かどうかを判断する拡張メソッドです。
/// </content>
partial class PieceTypeExtensions
{
    /// <summary>
    /// 指定された駒が成駒かどうかを判断します。
    /// <see cref="King"/>は指定できません。
    /// </summary>
    /// <param name="pieceType"><see cref="King"/>を除く駒の種類</param>
    /// <returns>
    /// 指定された駒が成駒の場合は<see langword="true"/>を返します。
    /// 生駒の場合は<see langword="false"/>を返します。
    /// <see cref="King"/>の場合、結果は未定義です。
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool DangerousIsPromotion(this PieceType pieceType)
    {
        Debug.Assert(pieceType != King, "王は指定できません。");
        return pieceType.IsPromotionOrKingInternal();
    }

    /// <summary>
    /// 指定された駒が成駒かどうかを判断します。
    /// </summary>
    /// <param name="pieceType">駒の種類</param>
    /// <returns>
    /// 指定された駒が成駒の場合は<see langword="true"/>を返します。
    /// 生駒の場合は<see langword="false"/>を返します。
    /// </returns>
    [SuppressMessage("Style", "IDE0075:条件式を簡略化する", Justification = "最適化のため")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsPromotion(this PieceType pieceType)
    {
        // インライン化された際の最適化のため、三項演算子でtrue/falseを返す。
        // https://github.com/dotnet/runtime/issues/4207
        return (pieceType.IsPromotionOrKingInternal() && pieceType != King)
            ? true
            : false;
    }

    /// <summary>
    /// 指定された駒が成駒または王かどうかを判断します。
    /// </summary>
    /// <param name="pieceType">駒の種類</param>
    /// <returns>
    /// 指定された駒が成駒または王の場合は<see langword="true"/>を返します。
    /// それ以外の場合は<see langword="false"/>を返します。
    /// </returns>
    [SuppressMessage("Style", "IDE0022:メソッドに式本体を使用する", Justification = "可読性のため")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static bool IsPromotionOrKingInternal(this PieceType pieceType)
    {
        // bit3は成駒または王かどうかのフラグになっている。
        // 【例】
        // 先手の歩(01): 0001
        // 先手のと(09): 1001
        // 先手の王(08): 1000
        return BitHelper.HasFlag((uint)pieceType, 3);
    }
}
