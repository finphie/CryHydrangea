namespace CryHydrangea.Shogi;

/// <summary>
/// 生駒の種類
/// </summary>
/// <remarks>
/// 0: なし<br/>
/// 1～8: 生駒
/// </remarks>
public enum RawPieceType
{
    /// <summary>
    /// なし
    /// </summary>
    NoPiece,

    /// <summary>
    /// 歩
    /// </summary>
    Pawn,

    /// <summary>
    /// 香
    /// </summary>
    Lance,

    /// <summary>
    /// 桂
    /// </summary>
    Knight,

    /// <summary>
    /// 銀
    /// </summary>
    Silver,

    /// <summary>
    /// 角
    /// </summary>
    Bishop,

    /// <summary>
    /// 飛
    /// </summary>
    Rook,

    /// <summary>
    /// 金
    /// </summary>
    Gold,

    /// <summary>
    /// 王
    /// </summary>
    King
}
