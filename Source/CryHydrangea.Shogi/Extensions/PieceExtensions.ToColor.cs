using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using static CryHydrangea.Shogi.Piece;

namespace CryHydrangea.Shogi.Extensions;

/// <content>
/// <see cref="Piece"/>型から<see cref="Color"/>型に変換する拡張メソッドです。
/// </content>
partial class PieceExtensions
{
    /// <summary>
    /// 手番を取得します。
    /// <see cref="NoPiece"/>は指定できません。
    /// </summary>
    /// <param name="piece"><see cref="NoPiece"/>を除く駒</param>
    /// <returns>
    /// 指定された駒から手番を返します。
    /// <see cref="NoPiece"/>の場合、結果は未定義です。
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Color DangerousToColor(this Piece piece)
    {
        Debug.Assert(piece != NoPiece, $"{nameof(NoPiece)}は指定できません。");
        return piece.ToColorInternal();
    }

    /// <summary>
    /// 手番を取得します。
    /// </summary>
    /// <param name="piece">駒</param>
    /// <param name="color">手番</param>
    /// <returns>
    /// 指定された駒が<see cref="NoPiece"/>以外の場合は<see langword="true"/>を返します。
    /// <see cref="NoPiece"/>の場合は<see langword="false"/>を返します。
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryToColor(this Piece piece, out Color color)
    {
        if (piece == NoPiece)
        {
            Unsafe.SkipInit(out color);
            return false;
        }

        color = piece.ToColorInternal();
        return true;
    }

    /// <summary>
    /// 手番を取得します。
    /// </summary>
    /// <param name="piece">駒</param>
    /// <returns>
    /// 指定された駒から手番を返します。
    /// <see cref="NoPiece"/>の場合、<see cref="Color.Black"/>を返します。
    /// </returns>
    [SuppressMessage("Style", "IDE0022:メソッドに式本体を使用する", Justification = "可読性のため")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static Color ToColorInternal(this Piece piece)
    {
        // 先手の駒番号の終わりは14かつ後手の駒番号の始まりは17になっているため、
        // bit4に先後の情報が格納されているはず。
        // 手番（Color）は0または1であり、駒（Piece）の最大値は30（0b_1_1110）なのでbit5以降は0。
        // 【例】
        // 先手の歩(01): 0000 0001
        // 後手の歩(17): 0001 0001
        return (Color)((int)piece >> 4);
    }
}
