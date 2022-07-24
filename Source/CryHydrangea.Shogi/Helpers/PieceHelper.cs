using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using static CryHydrangea.Shogi.Piece;

namespace CryHydrangea.Shogi.Helpers;

/// <summary>
/// <see cref="Piece"/>型に関するヘルパークラスです。
/// </summary>
public static class PieceHelper
{
    /// <summary>
    /// 駒をUTF-8文字に変換するためのテーブルです。
    /// </summary>
    /// <value>
    /// <see cref="Piece"/>型からUTF-8文字に変換する際に使用するテーブルです。
    /// </value>
    static ReadOnlySpan<byte> PieceToUtf8Char => new[]
    {
        // NoPiece
        (byte)' ',

        // 先手の生駒
        (byte)'P', (byte)'L', (byte)'N', (byte)'S', (byte)'B', (byte)'R', (byte)'G', (byte)'K',

        // 使用しない領域
        (byte)' ', (byte)' ', (byte)' ', (byte)' ', (byte)' ', (byte)' ', (byte)' ', (byte)' ',

        // 後手の生駒
        (byte)'p', (byte)'l', (byte)'n', (byte)'s', (byte)'b', (byte)'r', (byte)'g', (byte)'k'
    };

    /// <summary>
    /// 駒を文字に変換するためのテーブルです。
    /// </summary>
    /// <value>
    /// <see cref="Piece"/>型からUTF-8文字に変換する際に使用するテーブルです。
    /// </value>
    static ReadOnlySpan<char> PieceToChar => new[]
    {
        // NoPiece
        ' ',

        // 先手の生駒
        'P', 'L', 'N', 'S', 'B', 'R', 'G', 'K',

        // 使用しない領域
        ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',

        // 後手の生駒
        'p', 'l', 'n', 's', 'b', 'r', 'g', 'k'
    };

    /// <summary>
    /// 指定された値を<see cref="Piece"/>型に変換できるか判断します。
    /// </summary>
    /// <param name="value">値</param>
    /// <returns>
    /// <see cref="Piece"/>型に変換できる場合は<see langword="true"/>を返します。
    /// 変換できない場合は<see langword="true"/>を返します。
    /// </returns>
    [SuppressMessage("Style", "IDE0075:条件式を簡略化する", Justification = "最適化のため")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsPiece(byte value)
    {
        // インライン化された際の最適化のため、三項演算子でtrue/falseを返す。
        // https://github.com/dotnet/runtime/issues/4207
        return (value is (>= (byte)BlackPawn and <= (byte)BlackKing) or (>= (byte)WhitePawn and <= (byte)WhiteKing))
            ? true
            : false;
    }

    /// <inheritdoc cref="IsPiece(byte)"/>
    [SuppressMessage("Style", "IDE0075:条件式を簡略化する", Justification = "最適化のため")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsPiece(char value)
    {
        // インライン化された際の最適化のため、三項演算子でtrue/falseを返す。
        // https://github.com/dotnet/runtime/issues/4207
        return (value is (>= (char)BlackPawn and <= (char)BlackKing) or (>= (char)WhitePawn and <= (char)WhiteKing))
            ? true
            : false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Piece DangerousParse(byte value)
    {
        Debug.Assert(IsPiece(value), $"{nameof(Piece)}型に変換できない値です。");
        return ParseInternal(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Piece DangerousParse(char value)
    {
        Debug.Assert(IsPiece(value), $"{nameof(Piece)}型に変換できない値です。");
        return ParseInternal(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(byte value, out Piece piece)
    {
        if (IsPiece(value))
        {
            piece = ParseInternal(value);
            return true;
        }

        Unsafe.SkipInit(out piece);
        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static Piece ParseInternal(byte value)
        => (Piece)PieceToUtf8Char.IndexOf(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static Piece ParseInternal(char value)
        => (Piece)PieceToChar.IndexOf(value);
}
