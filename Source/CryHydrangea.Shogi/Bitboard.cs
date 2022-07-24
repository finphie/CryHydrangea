using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace CryHydrangea.Shogi;

/// <summary>
/// 盤面上の情報を表す構造体です。
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public readonly struct Bitboard : IEquatable<Bitboard>
{
    /// <summary>
    /// <see cref="Square"/>に対応するビットを1にしたビットボードのテーブルです。
    /// </summary>
    static readonly SquareBitboardTable SquareBitboard;

    /// <summary>
    /// <see cref="Bitboard"/>構造体の内部値です。
    /// </summary>
    /// <remarks>
    /// 1～7筋を<see cref="_value0"/>、8～9筋を<see cref="_value1"/>の合計128bitを保持しています。
    /// </remarks>
    [FieldOffset(0)]
    readonly Vector128<ulong> _value;

    /// <summary>
    /// <see cref="_value"/>の上位64bitです。
    /// </summary>
    /// <remarks>
    /// <para>
    /// 内部のビット表現<br/>
    /// bit63は未使用なので注意。<br/>
    /// <br/>
    /// F6 F5 F4 F3 F2 F1 F0<br/>
    /// ----------------------<br/>
    /// 54 45 36 27 18 09 00 | R0<br/>
    /// 55 46 37 28 19 10 01 | R1<br/>
    /// 56 47 38 29 20 11 02 | R2<br/>
    /// 57 48 39 30 21 12 03 | R3<br/>
    /// 58 49 40 31 22 13 04 | R4<br/>
    /// 59 50 41 32 23 14 05 | R5<br/>
    /// 60 51 42 33 24 15 06 | R6<br/>
    /// 61 52 43 34 25 16 07 | R7<br/>
    /// 62 53 44 35 26 17 08 | R8<br/>
    /// <br/>
    /// 頭文字Fは<see cref="File"/>、Rは<see cref="Rank"/>を表す。
    /// </para>
    /// </remarks>
    [FieldOffset(0)]
    readonly ulong _value0;

    /// <summary>
    /// <see cref="_value"/>の下位64bitです。
    /// </summary>
    /// <remarks>
    /// <para>
    /// 内部のビット表現<br/>
    /// <br/>
    /// F8 F7<br/>
    /// -------<br/>
    /// 09 00 | R1<br/>
    /// 10 01 | R2<br/>
    /// 11 02 | R3<br/>
    /// 12 03 | R4<br/>
    /// 13 04 | R5<br/>
    /// 14 05 | R6<br/>
    /// 15 06 | R7<br/>
    /// 16 07 | R8<br/>
    /// 17 08 | R9<br/>
    /// <br/>
    /// 頭文字Fは<see cref="File"/>、Rは<see cref="Rank"/>を表す。
    /// </para>
    /// </remarks>
    [FieldOffset(8)]
    readonly ulong _value1;

    [Obsolete("Do not use default constructor.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable
    public Bitboard() => throw new NotSupportedException();
#pragma warning restore

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Bitboard(in Vector128<ulong> value)
        => Unsafe.As<Vector128<ulong>, Bitboard>(ref Unsafe.AsRef(value));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Vector128<ulong>(in Bitboard value)
        => Unsafe.As<Bitboard, Vector128<ulong>>(ref Unsafe.AsRef(value));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(in Bitboard left, in Bitboard right)
        => left.Equals(right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(in Bitboard left, in Bitboard right)
        => !(left == right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bitboard operator &(in Bitboard left, in Bitboard right)
        => left._value & right._value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bitboard operator |(Bitboard left, Bitboard right)
        => left._value | right._value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bitboard operator ^(Bitboard left, Bitboard right)
        => left._value ^ right._value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bitboard operator ^(Bitboard board, Square square)
       => board ^ SquareBitboard[square];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bitboard operator +(Bitboard left, Bitboard right)
        => left._value + right._value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bitboard operator -(Bitboard left, Bitboard right)
        => left._value - right._value;

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static BitBoard operator <<(BitBoard board, int count)
    //{
    //    if (Sse2.IsSupported)
    //    {
    //        var value = Sse2.ShiftLeftLogical(board._value, (byte)count);
    //        return new(value);
    //    }

    //    return SoftwareFallback(board, count);

    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //    static BitBoard SoftwareFallback(in BitBoard board, int count)
    //        => new(board._value0 << count, board._value1 << count);
    //}

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static BitBoard operator >>(BitBoard board, int count)
    //{
    //    if (Sse2.IsSupported)
    //    {
    //        var value = Sse2.ShiftRightLogical(board._value, (byte)count);
    //        return new(value);
    //    }

    //    return SoftwareFallback(board, count);

    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //    static BitBoard SoftwareFallback(in BitBoard board, int count)
    //        => new(board._value0 >> count, board._value1 >> count);
    //}

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bitboard operator ~(Bitboard board)
    {
        // https://github.com/dotnet/runtime/issues/44115
        var one = Vector128.Create(0xffffffffffffffffUL);
        return board._value ^ one;
    }

    public static Bitboard Create(ulong value0, ulong value1)
    {
        // 引数の順番に注意
        var value = Vector128.Create(value1, value0);

        // 最適化のため、コンストラクターを使用しない。
        return Unsafe.As<Vector128<ulong>, Bitboard>(ref value);
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Bitboard other)
        => _value.Equals(other._value);

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object? obj)
        => obj is Bitboard board && Equals(board);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}
