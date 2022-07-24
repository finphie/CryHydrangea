using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CryHydrangea.Shogi.Extensions;
using CryHydrangea.Shogi.Helpers;

namespace CryHydrangea.Shogi;

/// <summary>
/// 16bitの指し手を表す構造体です。
/// </summary>
public readonly struct Move16 : IEquatable<Move16>, IMove
{
    /// <summary>
    /// 移動元が格納されている最初のビット番号
    /// </summary>
    internal const int FromBitNumber = 7;

    /// <summary>
    /// 駒打ちかどうかが格納されているビット番号
    /// </summary>
    internal const int DropBitNumber = 14;

    /// <summary>
    /// 成りかどうかが格納されているビット番号
    /// </summary>
    internal const int PromoteBitNumber = 15;

    /// <summary>
    /// 移動元または移動先の格納に必要な範囲を1にしたビットマスク
    /// </summary>
    internal const int SquareMask = 0b111_1111;

    /// <summary>
    /// 駒打ちフラグ
    /// </summary>
    internal const int DropFlag = 1 << DropBitNumber;

    /// <summary>
    /// 成りフラグ
    /// </summary>
    internal const int PromoteFlag = 1 << PromoteBitNumber;

    /// <summary>
    /// <see cref="Move16"/>構造体の内部値です。
    /// </summary>
    /// <remarks>
    /// bit0～6: 移動先<br/>
    /// bit7～13: 移動元（駒打ちの場合は駒の種類）<br/>
    /// bit14: 駒打ちかどうか<br/>
    /// bit15: 成りかどうか<br/>
    /// <br/>
    /// （参考情報）<br/>
    /// <see href="https://yaneuraou.yaneu.com/2015/12/10/連載やねうら王miniで遊ぼう！4日目/">連載やねうら王miniで遊ぼう！4日目</see>
    /// </remarks>
    readonly ushort _value;

    [Obsolete("Do not use default constructor.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable
    public Move16() => throw new NotSupportedException();
#pragma warning restore

    /// <inheritdoc/>
    public Square From
    {
        get
        {
            Debug.Assert(!IsDrop, "駒打ちでは、移動元を取得できません。");
            return (Square)((_value >> FromBitNumber) & SquareMask);
        }
    }

    /// <inheritdoc/>
    public Square To => (Square)(_value & SquareMask);

    /// <inheritdoc/>
    public bool IsPromotion => BitHelper.HasFlag(_value, PromoteBitNumber);

    /// <inheritdoc/>
    public bool IsDrop => BitHelper.HasFlag(_value, DropBitNumber);

    /// <inheritdoc/>
    public RawPieceType DroppedPiece
    {
        get
        {
            Debug.Assert(IsDrop, "駒打ち以外では、打った駒を取得できません。");
            return (RawPieceType)((_value >> FromBitNumber) & SquareMask);
        }
    }

    /// <summary>
    /// 2つの指し手を比較して、等しいかどうかを判断します。
    /// </summary>
    /// <param name="left"><paramref name="right"/>と比較する指し手</param>
    /// <param name="right"><paramref name="left"/>と比較する指し手</param>
    /// <returns>
    /// <paramref name="left"/>と<paramref name="right"/>が等しい場合は<see langword="true"/>を返します。
    /// 異なる場合は<see langword="false"/>を返します。
    /// </returns>
    public static bool operator ==(Move16 left, Move16 right)
        => left.Equals(right);

    /// <summary>
    /// 2つの指し手を比較して、異なるかどうかを判断します。
    /// </summary>
    /// <param name="left"><paramref name="right"/>と比較する指し手</param>
    /// <param name="right"><paramref name="left"/>と比較する指し手</param>
    /// <returns>
    /// <paramref name="left"/>と<paramref name="right"/>が異なる場合は<see langword="true"/>を返します。
    /// 等しい場合は<see langword="false"/>を返します。
    /// </returns>
    public static bool operator !=(Move16 left, Move16 right)
        => !(left == right);

    /// <summary>
    /// 指定された指し手で、<see cref="Move16"/>構造体の新しいインスタンスを作成します。
    /// </summary>
    /// <param name="from">移動元</param>
    /// <param name="to">移動先</param>
    /// <returns>
    /// <paramref name="from"/>から<paramref name="to"/>に移動する指し手を設定した、
    /// <see cref="Move16"/>構造体のインスタンスを返します。
    /// </returns>
    public static Move16 MakeMove(Square from, Square to)
    {
        // コンストラクターを使用すると、movzx命令が余分に出力されるため回避する。
        var value = (ushort)((int)to + ((int)from << FromBitNumber));
        return Unsafe.As<ushort, Move16>(ref value);
    }

    /// <summary>
    /// 指定された指し手で、<see cref="Move16"/>構造体の新しいインスタンスを作成します。
    /// </summary>
    /// <param name="from">移動元</param>
    /// <param name="to">移動先</param>
    /// <returns>
    /// <paramref name="from"/>から<paramref name="to"/>に移動して成る指し手を設定した、
    /// <see cref="Move16"/>構造体のインスタンスを返します。
    /// </returns>
    public static Move16 MakePromotionMove(Square from, Square to)
    {
        // コンストラクターを使用すると、movzx命令が余分に出力されるため回避する。
        var value = (ushort)((int)to + ((int)from << FromBitNumber) + PromoteFlag);
        return Unsafe.As<ushort, Move16>(ref value);
    }

    /// <summary>
    /// 指定された駒打ちの指し手で、<see cref="Move16"/>構造体の新しいインスタンスを作成します。
    /// <see cref="RawPieceType.NoPiece"/>と<see cref="RawPieceType.King"/>は指定できません。
    /// </summary>
    /// <param name="rawPieceType"><see cref="RawPieceType.NoPiece"/>や<see cref="RawPieceType.King"/>を除く生駒の種類</param>
    /// <param name="to">移動先</param>
    /// <returns>
    /// 駒種<paramref name="rawPieceType"/>を<paramref name="to"/>に打つ指し手を設定した、
    /// <see cref="Move16"/>構造体のインスタンスを返します。
    /// </returns>
    public static Move16 MakeDropMove(RawPieceType rawPieceType, Square to)
    {
        Debug.Assert(rawPieceType.CanDrop(), $"{nameof(PieceType.NoPiece)}や王は指定できません。");

        // コンストラクターを使用すると、movzx命令が余分に出力されるため回避する。
        var value = (ushort)((int)to + ((int)rawPieceType << FromBitNumber) + DropFlag);
        return Unsafe.As<ushort, Move16>(ref value);
    }

    /// <inheritdoc/>
    public bool Equals(Move16 other)
        => _value == other._value;

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is Move16 move && Equals(move);

    /// <inheritdoc/>
    public override int GetHashCode()
        => _value.GetHashCode();

    /// <inheritdoc/>
    public override string ToString()
    {
        // TODO
        if (IsDrop)
        {
            return $"{To}打";
        }

        return $"{From}{To}{(IsPromotion ? "成" : string.Empty)}";
    }
}
