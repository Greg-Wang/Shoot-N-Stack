using UnityEngine;

[CreateAssetMenu(fileName = "New Tetromino", menuName = "Custom Data Type/Tetromino")]
public class TetrominoObject : ScriptableObject
{
    public Sprite sprite;
    public int index;
    public Vector2[] positions = new Vector2[4];
}