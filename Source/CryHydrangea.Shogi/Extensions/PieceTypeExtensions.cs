using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static CryHydrangea.Shogi.PieceType;

namespace CryHydrangea.Shogi.Extensions;

/// <summary>
/// <see cref="PieceType"/>列挙型関連の拡張メソッド集です。
/// </summary>
public static partial class PieceTypeExtensions
{
    // TODO: UTF-8: void DangerousWriteHumanReadableString(this PieceType pieceType, Span<byte> destination)
    // TODO: UTF-8: void TryWriteHumanReadableString(this PieceType pieceType, Span<byte> destination)
    // TODO: UTF-8: byte[] ToHumanReadableUtf8String(this PieceType pieceType)

    /// <summary>
    /// 指定された駒が成れるかどうかを判断します。
    /// </summary>
    /// <param name="pieceType">駒の種類</param>
    /// <returns>
    /// 指定された駒が成れる場合は<see langword="true"/>を返します。
    /// 成れない場合は<see langword="false"/>を返します。
    /// </returns>
    [SuppressMessage("Style", "IDE0075:条件式を簡略化する", Justification = "最適化のため")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool CanPromote(this PieceType pieceType)
    {
        // 成れる駒は、歩と香、桂、銀、角、飛。
        // つまり、成れない駒はNoPieceと金、王、成駒。
        // 王と成駒については、IsPromotionInternalで一括判定できる。
        // インライン化された際の最適化のため、三項演算子でtrue/falseを返す。
        // https://github.com/dotnet/runtime/issues/4207
        return (pieceType == NoPiece || pieceType.IsPromotionOrKingInternal() || pieceType == Gold)
            ? false
            : true;
    }

    /// <summary>
    /// 指定された駒を手駒にすることができるかを判断します。
    /// </summary>
    /// <param name="pieceType">駒の種類</param>
    /// <returns>
    /// 指定された駒を手駒にすることができる場合は<see langword="true"/>を返します。
    /// できない場合は<see langword="false"/>を返します。
    /// </returns>
    [SuppressMessage("Style", "IDE0075:条件式を簡略化する", Justification = "最適化のため")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool CanDrop(this PieceType pieceType)
    {
        // NoPieceと成駒、王は手駒にすることはできない。
        // インライン化された際の最適化のため、三項演算子でtrue/falseを返す。
        // https://github.com/dotnet/runtime/issues/4207
        return (pieceType == NoPiece || pieceType.IsPromotionOrKingInternal())
            ? false
            : true;
    }

    /// <summary>
    /// 指定された駒から人間に読みやすい形式に変換した文字を取得します。
    /// </summary>
    /// <param name="pieceType">駒の種類</param>
    /// <returns>指定された駒を、人間に読みやすい形式にした文字にして返します。</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ToHumanReadableChar(this PieceType pieceType)
    {
        ReadOnlySpan<char> table = "N歩香桂銀角飛金王と杏圭全馬龍";
        return Unsafe.Add(ref MemoryMarshal.GetReference(table), (nint)(uint)pieceType);
    }
}
