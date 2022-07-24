using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using static CryHydrangea.Shogi.Piece;

namespace CryHydrangea.Shogi.Extensions;

/// <content>
/// <see cref="Piece"/>型から<see cref="RawPieceType"/>型に変換する拡張メソッドです。
/// </content>
partial class PieceExtensions
{
    /// <summary>
    /// 生駒の種類を取得します。
    /// <see cref="BlackKing"/>や<see cref="WhiteKing"/>は指定できません。
    /// </summary>
    /// <param name="piece"><see cref="BlackKing"/>や<see cref="WhiteKing"/>を除く駒</param>
    /// <returns>
    /// 指定された駒から<see cref="RawPieceType"/>を返します。
    /// <see cref="BlackKing"/>や<see cref="WhiteKing"/>の場合、結果は未定義です。
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static RawPieceType DangerousToRawPieceType(this Piece piece)
    {
        Debug.Assert(piece.ToPieceType() != PieceType.King, "王は指定できません。");
        return piece.ToRawPieceTypeInternal();
    }

    /// <summary>
    /// 生駒の種類を取得します。
    /// </summary>
    /// <param name="piece">駒</param>
    /// <returns>
    /// 指定された駒から<see cref="RawPieceType"/>を返します。
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static RawPieceType ToRawPieceType(this Piece piece)
    {
        return piece.ToPieceType() == PieceType.King
            ? RawPieceType.King
            : piece.ToRawPieceTypeInternal();
    }

    /// <summary>
    /// 生駒の種類を取得します。
    /// </summary>
    /// <param name="piece">駒</param>
    /// <returns>
    /// 指定された駒から<see cref="RawPieceType"/>を返します。
    /// <see cref="BlackKing"/>や<see cref="WhiteKing"/>の場合、<see cref="RawPieceType.NoPiece"/>を返します。
    /// </returns>
    [SuppressMessage("Style", "IDE0022:メソッドに式本体を使用する", Justification = "可読性のため")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static RawPieceType ToRawPieceTypeInternal(this Piece piece)
    {
        // 下位3ビットに生駒の種類に関する情報が格納されているはず。
        // ただし、王の場合はNoPieceになるので注意。
        // 【例】
        // 先手の歩(01): 0000 0001
        // 先手のと(09): 0000 1001
        // 後手の歩(17): 0001 0001
        // 後手のと(25): 0001 1001
        // 先手の飛(06): 0000 0110
        // 先手の龍(14): 0000 1110
        return (RawPieceType)((int)piece & 0b111);
    }
}
