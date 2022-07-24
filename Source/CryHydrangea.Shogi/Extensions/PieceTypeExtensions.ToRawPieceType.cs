using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using static CryHydrangea.Shogi.PieceType;

namespace CryHydrangea.Shogi.Extensions;

/// <content>
/// <see cref="PieceType"/>型から<see cref="RawPieceType"/>型に変換する拡張メソッドです。
/// </content>
partial class PieceTypeExtensions
{
    /// <summary>
    /// 生駒の種類を取得します。
    /// <see cref="King"/>は指定できません。
    /// </summary>
    /// <param name="pieceType"><see cref="King"/>を除く駒</param>
    /// <returns>
    /// 指定された駒から<see cref="RawPieceType"/>を返します。
    /// <see cref="King"/>の場合、結果は未定義です。
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static RawPieceType DangerousToRawPieceType(this PieceType pieceType)
    {
        Debug.Assert(pieceType != King, "王は指定できません。");
        return pieceType.ToRawPieceTypeInternal();
    }

    /// <summary>
    /// 生駒の種類を取得します。
    /// </summary>
    /// <param name="pieceType">駒</param>
    /// <returns>
    /// 指定された駒から<see cref="RawPieceType"/>を返します。
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static RawPieceType ToRawPieceType(this PieceType pieceType)
    {
        return pieceType == King
            ? RawPieceType.King
            : pieceType.ToRawPieceTypeInternal();
    }

    /// <summary>
    /// 生駒の種類を取得します。
    /// </summary>
    /// <param name="pieceType">駒</param>
    /// <returns>
    /// 指定された駒から<see cref="RawPieceType"/>を返します。
    /// <see cref="King"/>の場合、<see cref="RawPieceType.NoPiece"/>を返します。
    /// </returns>
    [SuppressMessage("Style", "IDE0022:メソッドに式本体を使用する", Justification = "可読性のため")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static RawPieceType ToRawPieceTypeInternal(this PieceType pieceType)
    {
        // 下位3ビットに生駒の種類に関する情報が格納されているはず。
        // ただし、「王」の場合はNoPieceになるので注意。
        // 【例】
        // 歩(01): 0001
        // と(09): 1001
        // 飛(06): 0110
        // 龍(14): 1110
        return (RawPieceType)((int)pieceType & 0b111);
    }
}
