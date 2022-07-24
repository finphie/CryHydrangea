namespace CryHydrangea.Shogi;

/// <summary>
/// 定数を定義するクラスです。
/// </summary>
public static class ShogiConstants
{
    /// <summary>
    /// 最大分岐数
    /// </summary>
    /// <remarks>
    /// 参考情報:
    /// <see href="http://www.nara-wu.ac.jp/math/personal/shinoda/bunki.html">将棋における最大分岐数</see>
    /// </remarks>
    public const int MaxMoves = 593;

    /// <summary>
    /// 駒の種類の数
    /// </summary>
    public const int PieceTypeCount = (int)PieceType.Dragon;

    /// <summary>
    /// 生駒の種類の数
    /// </summary>
    public const int RawPieceTypeCount = (int)RawPieceType.King;
}
