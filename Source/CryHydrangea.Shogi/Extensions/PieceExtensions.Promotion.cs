using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using static CryHydrangea.Shogi.Piece;

namespace CryHydrangea.Shogi.Extensions;

/// <content>
/// 指定された駒の成駒を取得する拡張メソッドです。
/// </content>
partial class PieceExtensions
{
    /// <summary>
    /// 指定された駒の成駒を取得します。
    /// <see cref="NoPiece"/>や「金」、「王」、成駒は指定できません。
    /// </summary>
    /// <param name="piece">
    /// <see cref="NoPiece"/>や<see cref="BlackGold"/>、<see cref="BlackKing"/>、
    /// <see cref="WhiteGold"/>、<see cref="WhiteKing"/>を除く生駒
    /// </param>
    /// <returns>
    /// 指定された駒が成れる場合は、その駒の成駒を返します。
    /// <see cref="NoPiece"/>や「金」、「王」、成駒の場合、結果は未定義です。
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Piece DangerousPromotion(this Piece piece)
    {
        Debug.Assert(piece.CanPromote(), $"{nameof(NoPiece)}や金、王、成駒は指定できません。");
        return piece.PromotionInternal();
    }

    /// <summary>
    /// 指定された駒の成駒を取得します。
    /// </summary>
    /// <param name="piece">駒</param>
    /// <param name="proPiece"><paramref name="piece"/>の成った駒</param>
    /// <returns>
    /// 指定された駒が成れる場合は<see langword="true"/>を返します。
    /// 成れない場合は<see langword="false"/>を返します。
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryPromotion(this Piece piece, out Piece proPiece)
    {
        if (piece.CanPromote())
        {
            proPiece = piece.PromotionInternal();
            return true;
        }

        Unsafe.SkipInit(out proPiece);
        return false;
    }

    /// <summary>
    /// 指定された駒の成駒を取得します。
    /// </summary>
    /// <param name="piece">駒</param>
    /// <returns>
    /// 指定された駒が生駒の場合は、その駒の成駒を返します。
    /// 成駒の場合は、その駒自身を返します。
    /// <see cref="NoPiece"/>や「金」、「王」の場合、結果は未定義です。
    /// </returns>
    [SuppressMessage("Style", "IDE0022:メソッドに式本体を使用する", Justification = "可読性のため")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static Piece PromotionInternal(this Piece piece)
    {
        // bit3は成駒または王かどうかのフラグになっている。
        // 【例】
        // 先手の歩(01): 0000 0001
        // 先手のと(09): 0000 1001
        // 後手の飛(22): 0001 0110
        // 後手の龍(30): 0001 1110
        // 先手の王(08): 0000 1000
        // 後手の王(24): 0001 1000
        return (Piece)((int)piece | 0b1000);
    }
}
