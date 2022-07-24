using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using static CryHydrangea.Shogi.RawPieceType;

namespace CryHydrangea.Shogi.Extensions;

/// <summary>
/// <see cref="RawPieceType"/>列挙型関連の拡張メソッド集です。
/// </summary>
public static partial class RawPieceTypeExtensions
{
    // TODO: UTF-8: void DangerousWriteHumanReadableString(this RawPieceType rawPieceType, Span<byte> destination)
    // TODO: UTF-8: void TryWriteHumanReadableStringthis RawPieceType rawPieceType, Span<byte> destination)
    // TODO: UTF-8: byte[] ToHumanReadableUtf8String(this RawPieceType rawPieceType)

    /// <summary>
    /// 駒の種類を取得します。
    /// </summary>
    /// <param name="rawPieceType">生駒の種類</param>
    /// <returns> 指定された生駒の種類から<see cref="PieceType"/>を返します。</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PieceType ToPieceType(this RawPieceType rawPieceType)
        => (PieceType)rawPieceType;

    /// <summary>
    /// 指定された駒を手駒にすることができるかを判断します。
    /// </summary>
    /// <param name="rawPieceType">生駒の種類</param>
    /// <returns>
    /// 指定された駒を手駒にすることができる場合は<see langword="true"/>を返します。
    /// できない場合は<see langword="false"/>を返します。
    /// </returns>
    [SuppressMessage("Style", "IDE0075:条件式を簡略化する", Justification = "最適化のため")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool CanDrop(this RawPieceType rawPieceType)
    {
        // NoPieceと王は手駒にすることはできない。
        // インライン化された際の最適化のため、三項演算子でtrue/falseを返す。
        // https://github.com/dotnet/runtime/issues/4207
        return (rawPieceType is NoPiece or King)
            ? false
            : true;
    }

    /// <summary>
    /// 指定された駒から人間に読みやすい形式に変換した文字を取得します。
    /// </summary>
    /// <param name="rawPieceType">生駒の種類</param>
    /// <returns>指定された駒を、人間に読みやすい形式にした文字にして返します。</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ToHumanReadableChar(this RawPieceType rawPieceType)
        => rawPieceType.ToPieceType().ToHumanReadableChar();
}
