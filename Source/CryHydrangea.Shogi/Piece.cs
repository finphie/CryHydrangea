namespace CryHydrangea.Shogi;

/// <summary>
/// 駒
/// </summary>
/// <remarks>
/// 0: なし<br/>
/// 1～8: 先手の生駒<br/>
/// 9～14: 先手の成駒<br/>
/// 17～24: 後手の生駒<br/>
/// 24～30: 後手の成駒<br/>
/// <br/>
/// <see cref="PieceType"/>型との変換をビット演算で行うため、
/// 後手の駒は17から始まるようにする必要がある。
/// </remarks>
public enum Piece
{
    /// <summary>
    /// なし
    /// </summary>
    NoPiece,

    /// <summary>
    /// 先手の歩
    /// </summary>
    BlackPawn,

    /// <summary>
    /// 先手の香
    /// </summary>
    BlackLance,

    /// <summary>
    /// 先手の桂
    /// </summary>
    BlackKnight,

    /// <summary>
    /// 先手の銀
    /// </summary>
    BlackSilver,

    /// <summary>
    /// 先手の角
    /// </summary>
    BlackBishop,

    /// <summary>
    /// 先手の飛
    /// </summary>
    BlackRook,

    /// <summary>
    /// 先手の金
    /// </summary>
    BlackGold,

    /// <summary>
    /// 先手の王
    /// </summary>
    BlackKing,

    /// <summary>
    /// 先手のと
    /// </summary>
    BlackProPawn,

    /// <summary>
    /// 先手の成香
    /// </summary>
    BlackProLance,

    /// <summary>
    /// 先手の成桂
    /// </summary>
    BlackProKnight,

    /// <summary>
    /// 先手の成銀
    /// </summary>
    BlackProSilver,

    /// <summary>
    /// 先手の馬
    /// </summary>
    BlackPegasus,

    /// <summary>
    /// 先手の龍
    /// </summary>
    BlackDragon,

    /// <summary>
    /// 後手の歩
    /// </summary>
    WhitePawn = 17,

    /// <summary>
    /// 後手の香
    /// </summary>
    WhiteLance,

    /// <summary>
    /// 後手の桂
    /// </summary>
    WhiteKnight,

    /// <summary>
    /// 後手の銀
    /// </summary>
    WhiteSilver,

    /// <summary>
    /// 後手の角
    /// </summary>
    WhiteBishop,

    /// <summary>
    /// 後手の飛
    /// </summary>
    WhiteRook,

    /// <summary>
    /// 後手の金
    /// </summary>
    WhiteGold,

    /// <summary>
    /// 後手の王
    /// </summary>
    WhiteKing,

    /// <summary>
    /// 後手のと
    /// </summary>
    WhiteProPawn,

    /// <summary>
    /// 後手の成香
    /// </summary>
    WhiteProLance,

    /// <summary>
    /// 後手の成桂
    /// </summary>
    WhiteProKnight,

    /// <summary>
    /// 後手の成銀
    /// </summary>
    WhiteProSilver,

    /// <summary>
    /// 後手の馬
    /// </summary>
    WhitePegasus,

    /// <summary>
    /// 後手の龍
    /// </summary>
    WhiteDragon,
}
