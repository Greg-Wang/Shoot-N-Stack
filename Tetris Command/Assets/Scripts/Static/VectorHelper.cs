using UnityEngine;
using static Globals;

public static class VectorHelper
{
    public static Vector3 Shift(this Vector3 v, int xOffset, int yOffset)
    {
        v.x += xOffset * TetrominoActualDimension;
        v.y += yOffset * TetrominoActualDimension;

        return v;
    }
}