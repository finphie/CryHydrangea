using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CryHydrangea.Shogi.Extensions;
using CryHydrangea.Shogi.Helpers;
using static CryHydrangea.Shogi.Move16;

namespace CryHydrangea.Shogi;

/// <summary>
/// 指し手を表す構造体です。
/// </summary>
public readonly struct Move : IEquatable<Move>, IMove
{
    /// <summary>
    /// 駒が格納されている最初のビット番号
    /// </summary>
    const int PieceBitNumber = 16;

    /// <summary>
    /// 手番が格納されている最初のビット番号
    /// </summary>
    const int ColorBitNumber = 20;

    /// <summary>
    /// <see cref="Move"/>構造体の内部値です。
    /// </summary>
    /// <remarks>
    /// 【上位16bit】駒（<see cref="PieceAfterMove"/>型）<br/>
    /// 【下位16bit】16bitの指し手（<see cref="Move"/>型）<br/>
    /// <br/>
    /// bit0～6: 移動先<br/>
    /// bit7～13: 移動元（駒打ちの場合は駒の種類）<br/>
    /// bit14: 駒打ちかどうか<br/>
    /// bit15: 成りかどうか<br/>
    /// bit16～20: 駒（bit20は手番）
    /// </remarks>
    readonly uint _value;

    [Obsolete("Do not use default constructor.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable
    public Move() => throw new NotSupportedException();
#pragma warning restore

    /// <summary>
    /// <see cref="Move"/>構造体の新しいインスタンスを初期化します。
    /// </summary>
    /// <remarks>
    /// 本来はコンストラクターを使用せずに<see cref="Unsafe.As{TFrom, TTo}(ref TFrom)"/>を使うべきだが、
    /// <see cref="uint"/>型を保持する構造体では、最適化されるため問題ない。
    /// </remarks>
    /// <param name="value">内部値</param>
    Move(uint value) => _value = value;

    /// <summary>
    /// 無効な移動を表す指し手です。
    /// </summary>
    /// <value>
    /// 無効な移動を表す<see cref="Move"/>構造体のインスタンスを返します。
    /// </value>
    public static Move None => new(0);

    /// <summary>
    /// NULL MOVEを表す指し手です。
    /// </summary>
    /// <remarks>
    /// 1一のマスから1一のマスへの移動は存在しないので、特殊な定数として扱う。
    /// </remarks>
    /// <value>
    /// NULL MOVEを表す<see cref="Move"/>構造体のインスタンスを返します。
    /// </value>
    public static Move Null => new((1 << FromBitNumber) + 1);

    /// <summary>
    /// 投了を表す指し手です。
    /// </summary>
    /// <remarks>
    /// 2二のマスから2二のマスへの移動は存在しないので、特殊な定数として扱う。
    /// </remarks>
    /// <value>
    /// 投了を表す<see cref="Move"/>構造体のインスタンスを返します。
    /// </value>
    public static Move Resign => new((2 << FromBitNumber) + 2);

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
    /// 動かす前の駒を取得します。
    /// </summary>
    /// <value>
    /// 駒を表す<see cref="Shogi.Piece"/>を返します。
    /// 成る指し手の場合は成る前の駒を返します。
    /// </value>
    //　TODO:
    public Piece Piece
        => (Piece)((int)PieceAfterMove ^ ((_value & PromoteFlag) >> 12));

    /// <summary>
    /// 動かした後の駒を取得します。
    /// </summary>
    /// <value>
    /// 駒を表す<see cref="Shogi.Piece"/>を返します。
    /// 成る指し手の場合は成った後の駒を返します。
    /// </value>
    public Piece PieceAfterMove
        => (Piece)(_value >> PieceBitNumber);

    /// <summary>
    /// 手番を取得します。
    /// </summary>
    /// <value>
    /// 手番を表す<see cref="Shogi.Color"/>を返します。
    /// </value>
    public Color Color
        => (Color)(_value >> ColorBitNumber);

    /// <summary>
    /// 2つの指し手を比較して、等しいかどうかを判断します。
    /// </summary>
    /// <param name="left"><paramref name="right"/>と比較する指し手</param>
    /// <param name="right"><paramref name="left"/>と比較する指し手</param>
    /// <returns>
    /// <paramref name="left"/>と<paramref name="right"/>が等しい場合は<see langword="true"/>を返します。
    /// 異なる場合は<see langword="false"/>を返します。
    /// </returns>
    public static bool operator ==(Move left, Move right)
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
    public static bool operator !=(Move left, Move right)
        => !(left == right);

    /// <summary>
    /// 指定された指し手で、<see cref="Move"/>構造体の新しいインスタンスを作成します。
    /// </summary>
    /// <param name="from">移動元</param>
    /// <param name="to">移動先</param>
    /// <param name="piece">駒</param>
    /// <returns>
    /// <paramref name="piece"/>を<paramref name="from"/>から<paramref name="to"/>に移動する指し手を設定した、
    /// <see cref="Move"/>構造体のインスタンスを返します。
    /// </returns>
    public static Move MakeMove(Square from, Square to, Piece piece)
    {
        Debug.Assert(piece != Piece.NoPiece, $"{nameof(Piece.NoPiece)}は指定できません。");
        return new((uint)to + ((uint)from << FromBitNumber) + ((uint)piece << PieceBitNumber));
    }

    /// <summary>
    /// 指定された指し手で、<see cref="Move"/>構造体の新しいインスタンスを作成します。
    /// <see cref="Piece.NoPiece"/>や「金」、「王」、成駒は指定できません。
    /// </summary>
    /// <param name="from">移動元</param>
    /// <param name="to">移動先</param>
    /// <param name="piece">
    /// <see cref="Piece.NoPiece"/>や<see cref="Piece.BlackGold"/>、<see cref="Piece.BlackKing"/>、
    /// <see cref="Piece.WhiteGold"/>、<see cref="Piece.WhiteKing"/>を除く生駒
    /// </param>
    /// <returns>
    /// <paramref name="piece"/>を<paramref name="from"/>から<paramref name="to"/>に移動して成る指し手を設定した、
    /// <see cref="Move"/>構造体のインスタンスを返します。
    /// </returns>
    public static Move MakePromotionMove(Square from, Square to, Piece piece)
    {
        Debug.Assert(piece.CanPromote(), $"{nameof(Piece.NoPiece)}や金、王、成駒は指定できません。");
        return new((uint)to + ((uint)from << FromBitNumber) + PromoteFlag + ((uint)piece.DangerousPromotion() << PieceBitNumber));
    }

    /// <summary>
    /// 指定された駒打ちの指し手で、<see cref="Move"/>構造体の新しいインスタンスを作成します。
    /// <see cref="RawPieceType.NoPiece"/>と<see cref="RawPieceType.King"/>は指定できません。
    /// </summary>
    /// <param name="rawPieceType"><see cref="RawPieceType.NoPiece"/>と<see cref="RawPieceType.King"/>を除く駒の種類</param>
    /// <param name="to">移動先</param>
    /// <param name="color">手番</param>
    /// <returns>
    /// <paramref name="color"/>側の駒種<paramref name="rawPieceType"/>を<paramref name="to"/>に打つ指し手を設定した、
    /// <see cref="Move"/>構造体のインスタンスを返します。
    /// </returns>
    public static Move MakeDropMove(RawPieceType rawPieceType, Square to, Color color)
    {
        Debug.Assert(rawPieceType.CanDrop(), $"{nameof(RawPieceType.NoPiece)}や王は指定できません。");
        return new((uint)to + ((uint)rawPieceType << FromBitNumber) + DropFlag + ((uint)rawPieceType.DangerousToPiece(color) << PieceBitNumber));
    }

    /// <inheritdoc/>
    public bool Equals(Move other)
        => _value == other._value;

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is Move move && Equals(move);

    /// <inheritdoc/>
    public override int GetHashCode()
        => _value.GetHashCode();

    /// <inheritdoc/>
    public override string ToString()
    {
        if (this == None)
        {
            return nameof(None);
        }

        if (this == Null)
        {
            return nameof(Null);
        }

        if (this == Resign)
        {
            return nameof(Resign);
        }

        if (IsDrop)
        {
            // 出力サイズは5文字
            var result = new string('\0', 5);
            ref var resultStart = ref MemoryMarshal.GetReference(result.AsSpan());

            // 駒打ちの指し手
            // 手番、移動先、「打」の順番で出力する。
            // 出力例: ☗２六歩打
            resultStart = Color.ToHumanReadableChar();
            To.WriteHumanReadableStringInternal(ref Unsafe.Add(ref resultStart, 1));
            Unsafe.Add(ref resultStart, 3) = DroppedPiece.ToHumanReadableChar();
            Unsafe.Add(ref resultStart, 4) = '打';

            return result;
        }

        // 出力サイズは最大7文字
        Span<char> buffer = stackalloc char[7];
        ref var bufferStart = ref MemoryMarshal.GetReference(buffer);

        // 駒を移動する指し手
        // 手番、移動元、移動先、成る場合は最後に「成」の順番で出力する。
        // 出力例: ☗２七２六歩、☖２六２七歩成
        bufferStart = Color.ToHumanReadableChar();
        From.WriteHumanReadableStringInternal(ref Unsafe.Add(ref bufferStart, 1));
        To.WriteHumanReadableStringInternal(ref Unsafe.Add(ref bufferStart, 3));

        if (IsPromotion)
        {
            // 成る場合は、成る前の指し手を出力する。
            Unsafe.Add(ref bufferStart, 5) = Piece.ToPieceType().ToHumanReadableChar();
            Unsafe.Add(ref bufferStart, 6) = '成';

            // 出力サイズは7文字
            return buffer.ToString();
        }

        Unsafe.Add(ref bufferStart, 5) = PieceAfterMove.ToPieceType().ToHumanReadableChar();

        // 出力サイズは6文字
        return MemoryMarshal.CreateReadOnlySpan(ref bufferStart, 6).ToString();
    }
}
