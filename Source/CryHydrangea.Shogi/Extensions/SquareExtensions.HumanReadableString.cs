using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CryHydrangea.Shogi.Extensions;

/// <content>
/// 指定されたマス目から人間に読みやすい形式に変換する拡張メソッドです。
/// </content>
partial class SquareExtensions
{
    // TODO: UTF-8: void DangerousWriteHumanReadableString(this Square square, Span<byte> destination)
    // TODO: UTF-8: void TryWriteHumanReadableString(this Square square, Span<byte> destination)
    // TODO: UTF-8: byte[] ToHumanReadableUtf8String(this Square square)

    /// <summary>
    /// 人間に読みやすい形式に変換する際に必要なUTF-16文字列の長さ
    /// </summary>
    /// <value>
    /// 2
    /// </value>
    const int HumanReadableUtf16StringLength = 2;

    /// <summary>
    /// 指定されたマス目から人間に読みやすい形式に変換した文字列をバッファーに出力します。
    /// このメソッドは引数チェックを行わないため、
    /// バッファーサイズが<inheritdoc cref="HumanReadableUtf16StringLength" path="//value"/>以上あることを事前に確認してください。
    /// </summary>
    /// <param name="square">マス目</param>
    /// <param name="destination">出力先のバッファー</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void DangerousWriteHumanReadableString(this Square square, Span<char> destination)
    {
        Debug.Assert(destination.Length >= HumanReadableUtf16StringLength, "バッファーサイズが不足しています。");
        square.WriteHumanReadableStringInternal(destination);
    }

    /// <summary>
    /// 指定されたマス目から人間に読みやすい形式に変換した文字列をバッファーに出力します。
    /// </summary>
    /// <param name="square">マス目</param>
    /// <param name="destination">出力先のバッファー</param>
    /// <returns>
    /// 出力に成功した場合は<see langword="true"/>を返します。
    /// 失敗した場合は<see langword="false"/>を返します。
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryWriteHumanReadableString(this Square square, Span<char> destination)
    {
        if (destination.Length < HumanReadableUtf16StringLength)
        {
            return false;
        }

        square.WriteHumanReadableStringInternal(destination);
        return true;
    }

    /// <summary>
    /// 指定されたマス目から人間に読みやすい形式に変換した文字列を取得します。
    /// </summary>
    /// <param name="square">マス目</param>
    /// <returns>指定されたマス目を、人間に読みやすい形式にした文字列にして返します。</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToHumanReadableString(this Square square)
    {
        // string.Createは、オーバーヘッドがあるので使用しない。
        // 直接文字列を書き換える。
        var result = new string('\0', HumanReadableUtf16StringLength);
        square.WriteHumanReadableStringInternal(ref MemoryMarshal.GetReference(result.AsSpan()));

        return result;
    }

    /// <summary>
    /// 指定されたマス目から人間に読みやすい形式に変換した文字列をバッファーに出力します。
    /// </summary>
    /// <param name="square">マス目</param>
    /// <param name="destination">出力先のバッファー</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void WriteHumanReadableStringInternal(this Square square, ref char destination)
    {
        var file = square.ToFile();
        var rank = square.ToRank();

        // 筋、段の順番で出力する。
        destination = file.ToHumanReadableChar();
        Unsafe.Add(ref destination, 1) = rank.ToHumanReadableChar();
    }

    /// <inheritdoc cref="WriteHumanReadableStringInternal(Square, ref char)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static void WriteHumanReadableStringInternal(this Square square, Span<char> destination)
        => square.WriteHumanReadableStringInternal(ref MemoryMarshal.GetReference(destination));
}
