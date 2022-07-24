using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using static CryHydrangea.Shogi.Piece;

namespace CryHydrangea.Shogi.Extensions;

/// <summary>
/// <see cref="Piece"/>列挙型関連の拡張メソッド集です。
/// </summary>
public static partial class PieceExtensions
{
    // TODO: UTF-8: void DangerousWriteHumanReadableString(this Piece piece, Span<byte> destination)
    // TODO: UTF-8: void TryWriteHumanReadableString(this Piece piece, Span<byte> destination)
    // TODO: UTF-8: byte[] ToHumanReadableUtf8String(this Piece piece)
    // TODO: UTF-16: void DangerousWriteHumanReadableString(this Piece piece, Span<char> destination)
    // TODO: UTF-16: void TryWriteHumanReadableString(this Piece piece, Span<char> destination)
    // TODO: UTF-16: string ToHumanReadableUtf8String(this Piece piece)

    /// <summary>
    /// 駒の種類を取得します。
    /// </summary>
    /// <param name="piece">駒</param>
    /// <returns>指定された駒から<see cref="PieceType"/>を返します。</returns>
    [SuppressMessage("Style", "IDE0022:メソッドに式本体を使用する", Justification = "可読性のため")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PieceType ToPieceType(this Piece piece)
    {
        // 先手の駒番号の終わりは14かつ後手の駒番号の始まりは17になっているため、
        // 下位4ビットに駒の種類に関する情報が格納されているはず。
        // 【例】
        // 先手の歩(01): 0000 0001
        // 後手の歩(17): 0001 0001
        // 先手の龍(14): 0000 1110
        // 後手の龍(30): 0001 1110
        return (PieceType)((int)piece & 0b1111);
    }

    /// <summary>
    /// 指定された駒が成れるかどうかを判断します。
    /// </summary>
    /// <param name="piece">駒</param>
    /// <returns>
    /// 指定された駒が成れる場合は<see langword="true"/>を返します。
    /// 成れない場合は<see langword="false"/>を返します。
    /// </returns>
    [SuppressMessage("Style", "IDE0075:条件式を簡略化する", Justification = "最適化のため")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool CanPromote(this Piece piece)
    {
        // 成れる駒は、歩と香、桂、銀、角、飛。
        // つまり、成れない駒はNoPieceと金、王、成駒。
        // インライン化された際の最適化のため、三項演算子でtrue/falseを返す。
        // https://github.com/dotnet/runtime/issues/4207
        return (piece == NoPiece || piece.IsPromotionOrKingInternal() || piece.ToPieceType() == PieceType.Gold)
            ? false
            : true;
    }

    /// <summary>
    /// 指定された駒を手駒にすることができるかを判断します。
    /// </summary>
    /// <param name="piece">駒</param>
    /// <returns>
    /// 指定された駒を手駒にすることができる場合は<see langword="true"/>を返します。
    /// できない場合は<see langword="false"/>を返します。
    /// </returns>
    [SuppressMessage("Style", "IDE0075:条件式を簡略化する", Justification = "最適化のため")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool CanDrop(this Piece piece)
    {
        // NoPieceと成駒、王は手駒にすることはできない。
        // インライン化された際の最適化のため、三項演算子でtrue/falseを返す。
        // https://github.com/dotnet/runtime/issues/4207
        return (piece == NoPiece || piece.IsPromotionOrKingInternal())
            ? false
            : true;
    }
}
