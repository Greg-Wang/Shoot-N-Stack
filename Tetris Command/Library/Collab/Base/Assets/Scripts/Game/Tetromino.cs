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
        for (int i = 0; i < TetrominoBlockCount; i++)
        {
            print(blocks[i].name);
        }
    }

    protected virtual void Update()
    {
        if (transform.childCount == 0) Destroy(gameObject);
    }

    public void Rotate(bool clockwise)
    {
        print("rotate called.");
        currentRotation = currentRotation == 3 ? 0 : currentRotation + 1;

        for (int i = 0; i < TetrominoBlockCount; i++)
        {
            //GetComponentsInChildren<Tetromino>()
            if (blocks[i] != null)
            {
                Vector2Int offset = RotationTable[blocks[i].tetromino.index, i, currentRotation];
                blocks[i].transform.position.Shift(offset.x, offset.y);
                print($"shifting {blocks[i].name} by {offset}");
            }
        }
    }
}