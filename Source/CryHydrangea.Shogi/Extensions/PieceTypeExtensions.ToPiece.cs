using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using static CryHydrangea.Shogi.PieceType;

namespace CryHydrangea.Shogi.Extensions;

/// <content>
/// <see cref="PieceType"/>型から<see cref="Piece"/>型に変換する拡張メソッドです。
/// </content>
partial class PieceTypeExtensions
{
    /// <summary>
    /// 駒を取得します。
    /// </summary>
    /// <param name="pieceType"><see cref="NoPiece"/>を除く駒の種類</param>
    /// <param name="color">手番</param>
    /// <returns>
    /// 指定された駒と手番から<see cref="Piece"/>を返します。
    /// <see cref="NoPiece"/>の場合、結果は未定義です。
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Piece DangerousToPiece(this PieceType pieceType, Color color)
    {
        Debug.Assert(pieceType != NoPiece, $"{nameof(NoPiece)}は指定できません。");
        return pieceType.ToPieceInternal(color);
    }

    /// <summary>
    /// 駒を取得します。
    /// </summary>
    /// <param name="pieceType">駒の種類</param>
    /// <param name="color">手番</param>
    /// <returns>
    /// 指定された駒と手番から<see cref="Piece"/>を返します。
    /// <see cref="NoPiece"/>の場合、<see cref="Piece.NoPiece"/>を返します。
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Piece ToPiece(this PieceType pieceType, Color color)
    {
        return pieceType == NoPiece
            ? Piece.NoPiece
            : pieceType.ToPieceInternal(color);
    }

    /// <summary>
    /// 駒を取得します。
    /// </summary>
    /// <param name="pieceType">駒の種類</param>
    /// <param name="color">手番</param>
    /// <returns>
    /// 指定された駒と手番から<see cref="Piece"/>を返します。
    /// <see cref="NoPiece"/>の場合、<see cref="Color.Black"/>では<see cref="Piece.NoPiece"/>、
    /// <see cref="Color.White"/>では未定義の値を返します。
    /// </returns>
    [SuppressMessage("Style", "IDE0022:メソッドに式本体を使用する", Justification = "可読性のため")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static Piece ToPieceInternal(this PieceType pieceType, Color color)
    {
        // 後手の駒番号の始まりは17になっているため、
        // 先手の場合は0(= 0 << 4)を、後手の場合は16(= 1 << 4)を駒の種類に加算する。
        return (Piece)((int)pieceType + ((int)color << 4));
    }
}
