using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using CryHydrangea.Shogi.Helpers;
using static CryHydrangea.Shogi.Piece;

namespace CryHydrangea.Shogi.Extensions;

/// <content>
/// 指定された駒が成駒かどうかを判断する拡張メソッドです。
/// </content>
partial class PieceExtensions
{
    /// <summary>
    /// 指定された駒が成駒かどうかを判断します。
    /// <see cref="BlackKing"/>や<see cref="WhiteKing"/>は指定できません。
    /// </summary>
    /// <param name="piece"><see cref="BlackKing"/>や<see cref="WhiteKing"/>を除く駒</param>
    /// <returns>
    /// 指定された駒が成駒の場合は<see langword="true"/>を返します。
    /// 生駒の場合は<see langword="false"/>を返します。
    /// <see cref="BlackKing"/>や<see cref="WhiteKing"/>の場合、結果は未定義です。
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool DangerousIsPromotion(this Piece piece)
    {
        Debug.Assert(piece.ToPieceType() != PieceType.King, "王は指定できません。");
        return piece.IsPromotionOrKingInternal();
    }

    /// <summary>
    /// 指定された駒が成駒かどうかを判断します。
    /// </summary>
    /// <param name="piece">駒</param>
    /// <returns>
    /// 指定された駒が成駒の場合は<see langword="true"/>を返します。
    /// 生駒の場合は<see langword="false"/>を返します。
    /// </returns>
    [SuppressMessage("Style", "IDE0075:条件式を簡略化する", Justification = "最適化のため")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsPromotion(this Piece piece)
    {
        // インライン化された際の最適化のため、三項演算子でtrue/falseを返す。
        // https://github.com/dotnet/runtime/issues/4207
        return (piece.IsPromotionOrKingInternal() && piece.ToPieceType() != PieceType.King)
            ? true
            : false;
    }

    /// <summary>
    /// 指定された駒が成駒または王かどうかを判断します。
    /// </summary>
    /// <param name="piece">駒</param>
    /// <returns>
    /// 指定された駒が成駒または王の場合は<see langword="true"/>を返します。
    /// それ以外の場合は<see langword="false"/>を返します。
    /// </returns>
    [SuppressMessage("Style", "IDE0022:メソッドに式本体を使用する", Justification = "可読性のため")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static bool IsPromotionOrKingInternal(this Piece piece)
    {
        // bit3は成駒または王かどうかのフラグになっている。
        // 【例】
        // 先手の歩(01): 0000 0001
        // 先手のと(09): 0000 1001
        // 後手の飛(22): 0001 0110
        // 後手の龍(30): 0001 1110
        // 先手の王(08): 0000 1000
        // 後手の王(24): 0001 1000
        return BitHelper.HasFlag((uint)piece, 3);
    }
}
