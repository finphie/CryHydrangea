namespace CryHydrangea.Shogi;

/// <summary>
/// 指し手の定義です。
/// </summary>
public interface IMove
{
    /// <summary>
    /// 移動元を取得します。
    /// </summary>
    /// <value>
    /// 移動元を表す<see cref="Square"/>を返します。駒打ちの場合は、このプロパティは呼び出せません。
    /// </value>
    Square From { get; }

    /// <summary>
    /// 移動先を取得します。
    /// </summary>
    /// <value>
    /// 移動先を表す<see cref="Square"/>を返します。
    /// </value>
    Square To { get; }

    /// <summary>
    /// 指し手が成りを行うかどうかを判断します。
    /// </summary>
    /// <value>
    /// 指し手が成りを行う場合は<see langword="true"/>を返します。
    /// それ以外は<see langword="false"/>を返します。
    /// </value>
    bool IsPromotion { get; }

    /// <summary>
    /// 指し手が駒打ちかどうかを判断します。
    /// </summary>
    /// <value>
    /// 指し手が駒打ち場合は<see langword="true"/>を返します。
    /// それ以外は<see langword="false"/>を返します。
    /// </value>
    bool IsDrop { get; }

    /// <summary>
    /// 打った駒を取得します。
    /// </summary>
    /// <value>
    /// 駒の種類を表す<see cref="RawPieceType"/>を返します。駒打ちの場合のみ、このプロパティを呼び出せます。
    /// </value>
    RawPieceType DroppedPiece { get; }
}
