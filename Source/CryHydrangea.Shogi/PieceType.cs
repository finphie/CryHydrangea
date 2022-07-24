namespace CryHydrangea.Shogi;

/// <summary>
/// 駒の種類
/// </summary>
/// <remarks>
/// 0: なし<br/>
/// 1～8: 生駒<br/>
/// 9～14: 成駒
/// </remarks>
public enum PieceType
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
    King,

    /// <summary>
    /// と
    /// </summary>
    ProPawn,

    /// <summary>
    /// 成香
    /// </summary>
    ProLance,

    /// <summary>
    /// 成桂
    /// </summary>
    ProKnight,

    /// <summary>
    /// 成銀
    /// </summary>
    ProSilver,

    /// <summary>
    /// 馬
    /// </summary>
    Pegasus,

    /// <summary>
    /// 龍
    /// </summary>
    Dragon
}
