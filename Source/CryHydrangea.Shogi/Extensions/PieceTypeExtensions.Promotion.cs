using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using static CryHydrangea.Shogi.PieceType;

namespace CryHydrangea.Shogi.Extensions;

/// <content>
/// 指定された駒の成駒を取得する拡張メソッドです。
/// </content>
partial class PieceTypeExtensions
{
    /// <summary>
    /// 指定された駒の成駒を取得します。
    /// <see cref="NoPiece"/>や「金」、「王」、成駒は指定できません。
    /// </summary>
    /// <param name="pieceType">
    /// <see cref="NoPiece"/>や<see cref="Gold"/>、<see cref="King"/>を除くの駒の種類
    /// </param>
    /// <returns>
    /// 指定された駒が成れる場合はその駒の成駒を返します。
    /// <see cref="NoPiece"/>や<see cref="Gold"/>、<see cref="King"/>の場合、結果は未定義です。
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PieceType DangerousPromotion(this PieceType pieceType)
    {
        Debug.Assert(pieceType.CanPromote(), $"{nameof(NoPiece)}や金、王、成駒は指定できません。");
        return pieceType.PromotionInternal();
    }

    /// <summary>
    /// 指定された駒の成駒を取得します。
    /// </summary>
    /// <param name="pieceType">駒の種類</param>
    /// <param name="proPieceType"><paramref name="pieceType"/>の成った駒</param>
    /// <returns>
    /// 指定された駒が成れる場合は<see langword="true"/>を返します。
    /// 成れない場合は<see langword="false"/>を返します。
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryPromotion(this PieceType pieceType, out PieceType proPieceType)
    {
        if (pieceType.CanPromote())
        {
            proPieceType = pieceType.PromotionInternal();
            return true;
        }

        Unsafe.SkipInit(out proPieceType);
        return false;
    }

    /// <summary>
    /// 指定された駒の成駒を取得します。
    /// </summary>
    /// <param name="pieceType">駒の種類</param>
    /// <returns>
    /// 指定された駒が成れる場合は、その駒の成駒を返します。
    /// 成駒の場合は、その駒自身を返します。
    /// <see cref="NoPiece"/>や「金」、「王」の場合、結果は未定義です。
    /// </returns>
    [SuppressMessage("Style", "IDE0022:メソッドに式本体を使用する", Justification = "可読性のため")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static PieceType PromotionInternal(this PieceType pieceType)
    {
        // bit3は成駒または王かどうかのフラグになっている。
        // 【例】
        // 歩(01): 0001
        // と(09): 1001
        // 飛(06): 0110
        // 龍(14): 1110
        // 王(08): 1000
        return (PieceType)((int)pieceType | 0b1000);
    }
}
