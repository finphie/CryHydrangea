using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static CryHydrangea.Shogi.RawPieceType;

namespace CryHydrangea.Shogi;

/// <summary>
/// 手駒を表す書き換え可能な構造体です。
/// </summary>
public struct Hand : IEquatable<Hand>
{
    /// <summary>
    /// 各種手駒を格納するために必要なビット数
    /// </summary>
    const int HandBitCount = 8;

    /// <summary>
    /// 各種手駒の格納に使用する範囲を1にしたビットマスク
    /// </summary>
    const int HandMask = 0b_1111_1111;

    /// <summary>
    /// 各種手駒格納位置の1つ上位のビットを1にした、手駒が格納されていないビットの集合
    /// </summary>
    /// <remarks>
    /// <see cref="IsEqualOrSuperior(Hand)"/>メソッドで使用するビットマスク
    /// </remarks>
    const ulong BorrowMask =
        ((PawnBitMask << PawnBitNumber) + (1UL << PawnBitNumber)) |
        ((LanceBitMask << LanceBitNumber) + (1UL << LanceBitNumber)) |
        ((KnightBitMask << KnightBitNumber) + (1UL << KnightBitNumber)) |
        ((SilverBitMask << SilverBitNumber) + (1UL << SilverBitNumber)) |
        ((BishopBitMask << BishopBitNumber) + (1UL << BishopBitNumber)) |
        ((RookBitMask << RookBitNumber) + (1UL << RookBitNumber)) |
        ((GoldBitMask << GoldBitNumber) + (1UL << GoldBitNumber));

    // 駒別の枚数が格納されている最初のビット番号
    const int PawnBitNumber = HandBitCount;
    const int LanceBitNumber = PawnBitNumber + HandBitCount;
    const int KnightBitNumber = LanceBitNumber + HandBitCount;
    const int SilverBitNumber = KnightBitNumber + HandBitCount;
    const int BishopBitNumber = SilverBitNumber + HandBitCount;
    const int RookBitNumber = BishopBitNumber + HandBitCount;
    const int GoldBitNumber = RookBitNumber + HandBitCount;

    // 駒別の枚数が格納されている範囲を1にしたビットマスク
    const ulong PawnBitMask = 0b1_1111;
    const ulong LanceBitMask = 0b111;
    const ulong KnightBitMask = 0b111;
    const ulong SilverBitMask = 0b111;
    const ulong BishopBitMask = 0b11;
    const ulong RookBitMask = 0b11;
    const ulong GoldBitMask = 0b111;

    /// <summary>
    /// <see cref="Hand"/>構造体の内部値です。
    /// </summary>
    /// <remarks>
    /// 最適化のために、書き換え可能にする。<br/>
    /// また、各種手駒を8ビットの領域に分ける。<br/>
    /// bit8～12: 歩（最大18枚、5ビット）<br/>
    /// bit16～18: 香（最大4枚、3ビット）<br/>
    /// bit24～26: 桂（最大4枚、3ビット）<br/>
    /// bit32～34: 銀（最大4枚、3ビット）<br/>
    /// bit40～41: 角（最大2枚、2ビット）<br/>
    /// bit48～49: 飛（最大2枚、2ビット）<br/>
    /// bit56～58: 金（最大4枚、3ビット）<br/>
    /// <br/>
    /// テーブル引きすれば32ビットに収めることもできるが、64ビットの方が実装がシンプルになる。
    /// </remarks>
    ulong _value;

    [Obsolete("Do not use default constructor.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable
    public Hand() => throw new NotSupportedException();
#pragma warning restore

    /// <summary>
    /// <see cref="Hand"/>構造体の新しいインスタンスを初期化します。
    /// </summary>
    /// <remarks>
    /// 本来はコンストラクターを使用せずに<see cref="Unsafe.As{TFrom, TTo}(ref TFrom)"/>を使うべきだが、
    /// <see cref="ulong"/>型を保持する構造体では、最適化されるため問題ない。
    /// </remarks>
    /// <param name="value">内部値</param>
    Hand(ulong value) => _value = value;

    /// <summary>
    /// 手駒なしの状態を表します。
    /// </summary>
    /// <value>
    /// 手駒なしの状態を表す<see cref="Hand"/>構造体のインスタンスを返します。
    /// </value>
    public static Hand Zero => new(0);

    /// <summary>
    /// 2つの手駒を比較して、等しいかどうかを判断します。
    /// </summary>
    /// <param name="left"><paramref name="right"/>と比較する手駒</param>
    /// <param name="right"><paramref name="left"/>と比較する手駒</param>
    /// <returns>
    /// <paramref name="left"/>と<paramref name="right"/>が等しい場合は<see langword="true"/>を返します。
    /// 異なる場合は<see langword="false"/>を返します。
    /// </returns>
    public static bool operator ==(Hand left, Hand right)
        => left.Equals(right);

    /// <summary>
    /// 2つの手駒を比較して、異なるかどうかを判断します。
    /// </summary>
    /// <param name="left"><paramref name="right"/>と比較する手駒</param>
    /// <param name="right"><paramref name="left"/>と比較する手駒</param>
    /// <returns>
    /// <paramref name="left"/>と<paramref name="right"/>が異なる場合は<see langword="true"/>を返します。
    /// 等しい場合は<see langword="false"/>を返します。
    /// </returns>
    public static bool operator !=(Hand left, Hand right)
        => !(left == right);

    /// <inheritdoc/>
    public readonly bool Equals(Hand other)
        => _value == other._value;

    /// <inheritdoc/>
    public override readonly bool Equals(object? obj)
        => obj is Hand hand && Equals(hand);

    /// <inheritdoc/>
    public override readonly int GetHashCode()
        => _value.GetHashCode();

    /// <summary>
    /// すべての種類の手駒が<paramref name="other"/>と等しいか多いかどうかを判断します。
    /// </summary>
    /// <param name="other">手駒</param>
    /// <returns>
    /// すべての種類の手駒が<paramref name="other"/>と等しいか多い場合は<see langword="true"/>を返します。
    /// 少ない場合は<see langword="false"/>を返します。
    /// </returns>
    public readonly bool IsEqualOrSuperior(Hand other)
    {
        // 繰り下がりを用いて同等または優等かどうかを求める。
        // https://yaneuraou.yaneu.com/2016/01/07/連載やねうら王miniを強くしよう！6日目/
        var value = (_value - other._value) & BorrowMask;
        return value == 0;
    }

    /// <summary>
    /// 指定された駒の手駒の数を取得します。
    /// </summary>
    /// <param name="rawPieceType"><see cref="NoPiece"/>と<see cref="King"/>を除く生駒の種類</param>
    /// <returns>手駒になっている<paramref name="rawPieceType"/>の数を返します。</returns>
    public readonly ulong GetCount(RawPieceType rawPieceType)
    {
        Assert(rawPieceType);
        return (_value >> ((int)rawPieceType * HandBitCount)) & HandMask;
    }

    /// <summary>
    /// 指定された駒を手駒に加えます。
    /// </summary>
    /// <param name="rawPieceType"><see cref="NoPiece"/>と<see cref="King"/>を除く生駒の種類</param>
    /// <param name="count">手駒に加える数</param>
    public void Add(RawPieceType rawPieceType, uint count = 1)
    {
        Assert(rawPieceType, count);

        // 歩は最大18枚
        // 角・飛は最大2枚
        // 香・桂・銀・金は最大4枚
        Debug.Assert(
            (rawPieceType == Pawn && GetCount(rawPieceType) + count <= 18) ||
            ((rawPieceType is Bishop or Rook) && GetCount(rawPieceType) + count <= 2) ||
            ((rawPieceType is Lance or Knight or Silver or Gold) && GetCount(rawPieceType) + count <= 4),
            "手駒の数が最大値を超えています。");

        _value += (1UL << ((int)rawPieceType * HandBitCount)) * count;
    }

    /// <summary>
    /// 指定された駒を手駒から除去します。
    /// </summary>
    /// <param name="rawPieceType"><see cref="NoPiece"/>と<see cref="King"/>を除く生駒の種類</param>
    /// <param name="count">手駒から除去する数</param>
    public void Subtract(RawPieceType rawPieceType, uint count = 1)
    {
        Assert(rawPieceType, count);
        Debug.Assert(
            (rawPieceType == Pawn && GetCount(rawPieceType) - count >= 0) ||
            ((rawPieceType is Bishop or Rook) && GetCount(rawPieceType) - count >= 0) ||
            ((rawPieceType is Lance or Knight or Silver or Gold) && GetCount(rawPieceType) - count >= 0),
            "手駒が0枚未満になっています。");

        _value -= (1UL << ((int)rawPieceType * HandBitCount)) * count;
    }

    [Conditional("DEBUG")]
    static void Assert(RawPieceType rawPieceType)
        => Debug.Assert(rawPieceType is not NoPiece and not King, $"{rawPieceType}は、手駒に出来ない駒です。");

    [Conditional("DEBUG")]
    static void Assert(RawPieceType rawPieceType, uint count)
    {
        Assert(rawPieceType);
        Debug.Assert(count > 0, $"{nameof(count)}は、0より大きい数値が必要です。");
    }
}
