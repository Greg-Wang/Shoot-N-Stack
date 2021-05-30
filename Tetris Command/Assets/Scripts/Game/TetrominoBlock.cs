using UnityEngine;

public class TetrominoBlock : Tetromino
{
    Game gameController;

    [SerializeField] TetrominoObject groundedTetromino;
    [SerializeField] LayerMask bulletLayer;

    [HideInInspector] public TetrominoObject tetromino;
    [HideInInspector] public bool isGrounded;
    [HideInInspector] public int originalSiblingIndex;

    readonly float fallSpeed = 1f;

    SpriteRenderer spriteRenderer;

    protected override void Awake()
    {
        base.Awake();
        spriteRenderer = GetComponent<SpriteRenderer>();

        FindObjectOfType<PauseHandler>().PauseAction += OnPauseStateChanged;
        FindObjectOfType<GameOverHandler>().GameOverAction += OnGameOver;
        gameController = FindObjectOfType<Game>();
    }

    void Start()
    {
        originalSiblingIndex = transform.GetSiblingIndex();
        spriteRenderer.sprite = tetromino.sprite;

        Vector2 localPos = tetromino.positions[originalSiblingIndex];
        localPos.x *= tetromino.sprite.rect.width / tetromino.sprite.pixelsPerUnit;
        localPos.y *= tetromino.sprite.rect.height / tetromino.sprite.pixelsPerUnit;

        transform.localPosition = localPos;
    }

    protected override void Update()
    {
        if (!isGrounded)
        {
            transform.Translate(fallSpeed * Time.deltaTime * Vector3.down);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (1 << other.gameObject.layer != bulletLayer.value)
        {
            TetrominoBlock[] siblings = transform.parent.GetComponentsInChildren<TetrominoBlock>();

            for (int i = 0; i < siblings.Length; i++)
            {
                siblings[i].SetGroundedState(true);

                if(i == 0 || siblings[i].transform.position.y != siblings[Mathf.Max(0, i - 1)].transform.position.y)
                {
                    gameController.CheckRows(siblings[i].transform.position.y);
                }
            }            
        }
    }

    public void SetGroundedState(bool state)
    {
        isGrounded = state;

        if (isGrounded)
        {
            spriteRenderer.sprite = groundedTetromino.sprite;
            gameObject.layer = LayerMask.NameToLayer("Ground");
            enabled = false;
        }
    }

    void OnPauseStateChanged(bool state)
    {
        enabled = !state;
    }

    void OnGameOver()
    {
        SetGroundedState(true);
    }
}