using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using CryHydrangea.Shogi.Extensions;

namespace CryHydrangea.Shogi;

/// <summary>
/// 局面を表す構造体です。
/// </summary>
public ref struct Position
{
    /// <summary>
    /// 盤上の駒
    /// </summary>
    readonly Piece[] _board;

    //readonly Span<>

    /// <summary>
    /// 先手・後手・先後両方の駒がある場所を示すビットボード
    /// </summary>
    readonly Bitboard[] _colorBitboards;

    Bitboard _allPieceBitboard;

    /// <summary>
    /// 駒の種類毎の駒がある場所を示すビットボード
    /// </summary>
    readonly Bitboard[] _pieceTypeBitboards;
    // piece_type_bb = new BotBoard[21] 14

    readonly HandArray _hands;

    // 手駒

    /// <summary>
    /// 手番を取得します。
    /// </summary>
    /// <value>
    /// 手番を表す<see cref="Color"/>を返します。
    /// </value>
    public Color SideToMove { readonly get; private set; }

    /// <summary>
    /// 手数を取得します。
    /// </summary>
    /// <value>
    /// 1以上の手数を表す数値を返します。
    /// </value>
    public int GamePly { readonly get; private set; }

    public Position(Color sideToMove, int gamePly)
    {
        //Debug.Assert(colorBitboard.Length == 3, $"{nameof(colorBitboard)}の長さは3にする必要があります。");
        //Debug.Assert(pieceTypeBitboard.Length == 14, $"{nameof(pieceTypeBitboard)}の長さは14にする必要があります。");
        Debug.Assert(gamePly > 0, $"{gamePly}は0より大きい必要があります。");

        _colorBitboards = new Bitboard[2];
        _allPieceBitboard = default;
        _pieceTypeBitboards = new Bitboard[14];
        _board = new Piece[81];

        SideToMove = sideToMove;
        GamePly = gamePly;


        _hands = default;
    }

    //public override readonly string ToString()
    //{

    //}

    public static Position Create(ReadOnlySpan<byte> sfen)
    {
        File file = File.File9;
        var rank = Rank.Rank1;
        var isPromotion = false;
        var count = 0;


        ReadOnlySpan<byte> table = Encoding.UTF8.GetBytes(" PLNSBRGK        plnsbrgk");

        foreach (var token in sfen)
        {
            // System.Text.Rune.IsDigitを使用
            // NoPieceの数
            if (token is >= (byte)'0' and <= (byte)'9')
            {
                file -= (File)(token - (byte)'0');
            }

            // 次の段
            else if (token == (byte)'/')
            {
                file = File.File9;
                rank++;
            }

            // 成駒
            else if (token == (byte)'+')
            {
                isPromotion = true;
            }

            else
            {
                var index = table.IndexOf(token);

            }
        }

        //                 count = (token - (byte)'0') + (count * 10);

    }

    /// <summary>
    /// 指定された指し手で局面を進めます。
    /// </summary>
    /// <param name="move">指し手</param>
    public void DoMove(Move move)
    {
        Debug.Assert(move != Move.None);

        // 移動先
        var to = move.To;

        // 駒打ちかどうか
        if (move.IsDrop)
        {
            var piece = move.PieceAfterMove;

            // 王を駒打ちすることはないため、この呼び出しは問題ない。
            var rawPieceType = piece.DangerousToRawPieceType();

            // 移動先に駒を配置
            PutPiece(to, piece);

            // 手駒から除去
            _hands[SideToMove].Subtract(rawPieceType);
        }
        else
        {
            // 駒打ちではない、つまり駒を移動する指し手となる。
            // 移動元にある駒が移動させる駒となる。
            var from = move.From;
            var piece = GetPiece(from);

            // 移動先に配置する駒
            // pieceと同じか成った駒になるはず。
            var pieceAfterMove = move.PieceAfterMove;
            Debug.Assert(piece == pieceAfterMove || piece.DangerousPromotion() == pieceAfterMove, "");

            var toPiece = GetPiece(to);

            // 移動先に駒があるか
            if (toPiece != Piece.NoPiece)
            {
                // 王が移動先にあり、それを手駒として追加することはないため、この呼び出しは問題ない。
                var toRawPieceType = toPiece.DangerousToRawPieceType();

                // 手駒に追加
                _hands[SideToMove].Add(toRawPieceType);

                // 移動先に配置されている駒を除去
                RemovePiece(to);
            }
            else
            {

            }

            // 移動元から駒を除去
            RemovePiece(from);

            // 移動先に駒を配置
            PutPiece(to, pieceAfterMove);
        }

        SideToMove = ~SideToMove;
        GamePly++;
    }

    /// <summary>
    /// 指定された指し手で局面を戻します。
    /// </summary>
    /// <param name="move">指し手</param>
    public void UndoMove(Move move)
    {
        // 移動先
        var to = move.To;

        var piece = move.PieceAfterMove;

        if (move.IsDrop)
        {

        }

        SideToMove = ~SideToMove;
        GamePly--;
    }

    void PutPiece(Square square, Piece piece)
    {
        ref var boardFirst = ref MemoryMarshal.GetArrayDataReference(_board);
        Unsafe.Add(ref boardFirst, (nint)(uint)square) = piece;

        XorPiece(square, piece);
    }

    void RemovePiece(Square square)
    {
        var piece = _board[(int)square];
        Debug.Assert(piece != Piece.NoPiece);

        _board[(int)square] = Piece.NoPiece;
        XorPiece(square, piece);
    }

    void XorPiece(Square square, Piece piece)
    {
        // 先手・後手の駒がある場所を示すビットボードの更新
        Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(_colorBitboards), (nint)(uint)piece.DangerousToColor()) ^= square;

        // 先後どちらかの駒がある場所を示すビットボードの更新
        _allPieceBitboard ^= square;

        // 駒の種類毎の駒がある場所を示すビットボードの更新
        Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(_pieceTypeBitboards), (nint)(uint)piece.ToPieceType()) ^= square;
    }

    Piece GetPiece(Square square)
        => _board[(int)square];

    readonly struct HandArray
    {
        public readonly Hand Black = Hand.Zero;
        public readonly Hand White = Hand.Zero;

        [Obsolete("Do not use default constructor.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HandArray() => throw new NotSupportedException();

        public Hand this[Color index]
            => Unsafe.Add(ref Unsafe.AsRef(Black), (nint)(uint)index);
    }
}
