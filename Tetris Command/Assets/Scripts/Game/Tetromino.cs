using UnityEngine;
using static Globals;

public class Tetromino : MonoBehaviour
{
    [HideInInspector] public new Transform transform;
    TetrominoBlock[] blocks = new TetrominoBlock[TetrominoBlockCount];

    int currentRotation = 0;

    protected virtual void Awake()
    {
        transform = GetComponent<Transform>();
    }

    void Start()
    {
        blocks = GetComponentsInChildren<TetrominoBlock>();
    }

    protected virtual void Update()
    {
        if (transform.childCount == 0) Destroy(gameObject);
    }

    public void Rotate(bool clockwise)
    {
        for (int i = 0; i < TetrominoBlockCount; i++)
        {
            if (blocks[i] != null)
            {
                Vector2Int offset = RotationTable[blocks[i].tetromino.index, i, currentRotation];
                blocks[i].transform.position = blocks[i].transform.position.Shift(offset.x, offset.y);
            }
        }

        currentRotation = currentRotation == 3 ? 0 : currentRotation + 1;
    }
}