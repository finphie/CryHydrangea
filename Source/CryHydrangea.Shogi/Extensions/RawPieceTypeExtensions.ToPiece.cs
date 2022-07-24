using System.Diagnostics;
using System.Runtime.CompilerServices;
using static CryHydrangea.Shogi.RawPieceType;

namespace CryHydrangea.Shogi.Extensions;

/// <content>
/// <see cref="RawPieceType"/>型から<see cref="Piece"/>型に変換する拡張メソッドです。
/// </content>
partial class RawPieceTypeExtensions
{
    /// <summary>
    /// 駒を取得します。
    /// </summary>
    /// <param name="rawPieceType"><see cref="NoPiece"/>を除く生駒の種類</param>
    /// <param name="color">手番</param>
    /// <returns>
    /// 指定された駒と手番から<see cref="Piece"/>を返します。
    /// <see cref="NoPiece"/>の場合、結果は未定義です。
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Piece DangerousToPiece(this RawPieceType rawPieceType, Color color)
    {
        Debug.Assert(rawPieceType != NoPiece, $"{nameof(NoPiece)}は指定できません。");
        return rawPieceType.ToPieceType().DangerousToPiece(color);
    }

    /// <summary>
    /// 駒を取得します。
    /// </summary>
    /// <param name="rawPieceType">生駒の種類</param>
    /// <param name="color">手番</param>
    /// <returns>
    /// 指定された駒と手番から<see cref="Piece"/>を返します。
    /// <see cref="NoPiece"/>の場合、<see cref="Piece.NoPiece"/>を返します。
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Piece ToPiece(this RawPieceType rawPieceType, Color color)
    {
        return rawPieceType == NoPiece
            ? Piece.NoPiece
            : rawPieceType.ToPieceType().DangerousToPiece(color);
    }
}
