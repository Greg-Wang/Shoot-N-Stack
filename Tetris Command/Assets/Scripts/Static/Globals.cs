using UnityEngine;

public static class Globals
{
    public const int TetrominoCount = 7;
    public const int TetrominoBlockCount = 4;

    public const int TetrominoPixelDimension = 48;
    public const float TetrominoPixelsPerUnit = 100f;
    public const float TetrominoActualDimension = TetrominoPixelDimension / TetrominoPixelsPerUnit;

    public static Vector2Int[,,] RotationTable = new Vector2Int[TetrominoCount, TetrominoBlockCount, 4]
    {
        #region Red

        {
            { new Vector2Int(2, 0), new Vector2Int(0, -2), new Vector2Int(-2, 0), new Vector2Int(0, 2) },
            { new Vector2Int(1, -1), new Vector2Int(-1, -1), new Vector2Int(-1, 1), new Vector2Int(1, 1) },
            { new Vector2Int(0, 0), new Vector2Int(0, 0), new Vector2Int(0, 0), new Vector2Int(0, 0) },
            { new Vector2Int(-1, -1), new Vector2Int(-1, 1), new Vector2Int(1, 1), new Vector2Int(1, -1) }
        },

        #endregion

        #region Orange

        {
            { new Vector2Int(0, -2), new Vector2Int(-2, 0), new Vector2Int(0, 2), new Vector2Int(2, 0) },
            { new Vector2Int(1, 1), new Vector2Int(1, -1), new Vector2Int(-1, -1), new Vector2Int(-1, 1) },
            { new Vector2Int(0, 0), new Vector2Int(0, 0), new Vector2Int(0, 0), new Vector2Int(0, 0) },
            { new Vector2Int(-1, -1), new Vector2Int(-1, 1), new Vector2Int(1, 1), new Vector2Int(1, -1) }
        },

        #endregion

        #region Yellow

        {
            { new Vector2Int(0, 0), new Vector2Int(0, 0), new Vector2Int(0, 0), new Vector2Int(0, 0) },
            { new Vector2Int(0, 0), new Vector2Int(0, 0), new Vector2Int(0, 0), new Vector2Int(0, 0) },
            { new Vector2Int(0, 0), new Vector2Int(0, 0), new Vector2Int(0, 0), new Vector2Int(0, 0) },
            { new Vector2Int(0, 0), new Vector2Int(0, 0), new Vector2Int(0, 0), new Vector2Int(0, 0) }
        },

        #endregion

        #region Green

        {
            { new Vector2Int(1, -1), new Vector2Int(-1, -1), new Vector2Int(-1, 1), new Vector2Int(1, 1) },
            { new Vector2Int(0, -2), new Vector2Int(-2, 0), new Vector2Int(0, 2), new Vector2Int(2, 0) },
            { new Vector2Int(1, 1), new Vector2Int(1, -1), new Vector2Int(-1, -1), new Vector2Int(-1, 1) },
            { new Vector2Int(0, 0), new Vector2Int(0, 0), new Vector2Int(0, 0), new Vector2Int(0, 0) }
        },

        #endregion

        #region Light blue

        {
            { new Vector2Int(1, 2), new Vector2Int(2, -1), new Vector2Int(-1, -2), new Vector2Int(-2, 1) },
            { new Vector2Int(0, 1), new Vector2Int(1, 0), new Vector2Int(0, -1), new Vector2Int(-1, 0) },
            { new Vector2Int(-1, 0), new Vector2Int(0, 1), new Vector2Int(1, 0), new Vector2Int(0, -1) },
            { new Vector2Int(-2, -1), new Vector2Int(-1, 2), new Vector2Int(2, 1), new Vector2Int(1, -2) }
        },

        #endregion

        #region Blue

        {
            { new Vector2Int(2, 0), new Vector2Int(0, -2), new Vector2Int(-2, 0), new Vector2Int(0, 2) },
            { new Vector2Int(1, 1), new Vector2Int(1, -1), new Vector2Int(-1, -1), new Vector2Int(-1, 1) },
            { new Vector2Int(0, 0), new Vector2Int(0, 0), new Vector2Int(0, 0), new Vector2Int(0, 0) },
            { new Vector2Int(-1, -1), new Vector2Int(-1, 1), new Vector2Int(1, 1), new Vector2Int(1, -1) }
        },

        #endregion

        #region Purple

        {
            { new Vector2Int(1, -1), new Vector2Int(-1, -1), new Vector2Int(-1, 1), new Vector2Int(1, 1) },
            { new Vector2Int(1, 1), new Vector2Int(1, -1), new Vector2Int(-1, -1), new Vector2Int(-1, 1) },
            { new Vector2Int(0, 0), new Vector2Int(0, 0), new Vector2Int(0, 0), new Vector2Int(0, 0) },
            { new Vector2Int(-1, -1), new Vector2Int(-1, 1), new Vector2Int(1, 1), new Vector2Int(1, -1) }
        }

        #endregion
    };
}