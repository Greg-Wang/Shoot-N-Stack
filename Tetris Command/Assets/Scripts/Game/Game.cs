using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CoroutineHelper;

public class Game : MonoBehaviour
{
    [SerializeField] GameObject tetrominoPrefab;
    [SerializeField] Transform tetrominoHolder;
    [SerializeField] LayerMask groundLayer;

    IEnumerator tetrominoSpawnCoroutine;

    const int TetrominoCount = 7;
    [SerializeField] TetrominoObject[] tetrominos = new TetrominoObject[TetrominoCount];
    List<int> indices = new List<int>(TetrominoCount) { 0, 1, 2, 3, 4, 5, 6 };

    const float SpawnDelay = 5f;
    float timeToNextSpawn;
    int previousSpawnPos;

    Score score;

    void Awake()
    {
        GetComponent<PauseHandler>().PauseAction += OnPauseStateChanged;
        FindObjectOfType<GameOverHandler>().GameOverAction += OnGameOver;
    }

    void OnEnable()
    {
        if (tetrominoSpawnCoroutine == null)
        {
            tetrominoSpawnCoroutine = SpawnTetrominos();
            StartCoroutine(tetrominoSpawnCoroutine);
        }
    }

    IEnumerator SpawnTetrominos()
    {
        timeToNextSpawn = SpawnDelay;

        while (true)
        {
            RandomizeList();

            for (int i = 0; i < TetrominoCount; i++)
            {
                SpawnTetromino(i);
                timeToNextSpawn = SpawnDelay;

                while (timeToNextSpawn > 0f)
                {
                    yield return WaitUntil(() => enabled);
                    timeToNextSpawn -= Time.deltaTime;
                }
                FindObjectOfType<Score>().UpdateScore(10);

            }



            yield return null;
        }
    }

    void RandomizeList()
    {
        System.Random rand = new System.Random();
        int i = TetrominoCount;

        while (i > 1)
        {
            int j = rand.Next(i);
            i--;

            int temp = indices[j];
            indices[j] = indices[i];
            indices[i] = temp;
        }
    }

    void SpawnTetromino(int index, int position)
    {
        GameObject newTetromino = Instantiate(tetrominoPrefab, tetrominoHolder);

        TetrominoBlock[] blocks = newTetromino.GetComponentsInChildren<TetrominoBlock>();

        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].tetromino = tetrominos[indices[index]];
        }

        float newSpawnPosX = position * tetrominos[indices[index]].sprite.rect.width / tetrominos[indices[index]].sprite.pixelsPerUnit;
        newTetromino.transform.Translate(newSpawnPosX * Vector2.right);
    }

    void SpawnTetromino(int index)
    {
        GameObject newTetromino = Instantiate(tetrominoPrefab, tetrominoHolder);

        TetrominoBlock[] blocks = newTetromino.GetComponentsInChildren<TetrominoBlock>();

        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].tetromino = tetrominos[indices[index]];
        }

        int spawnPosX = GetRandomSpawnPos(indices[index]);

        float newSpawnPosX = spawnPosX * tetrominos[indices[index]].sprite.rect.width / tetrominos[indices[index]].sprite.pixelsPerUnit;
        newTetromino.transform.Translate(newSpawnPosX * Vector2.right);
    }

    int GetRandomSpawnPos(int index)
    {
        int spawnPos;

        switch (index)
        {
            case 2:
                spawnPos = UnityEngine.Random.Range(-4, 5);
                break;

            case 4:
                spawnPos = UnityEngine.Random.Range(-3, 4);
                break;

            default:
                spawnPos = UnityEngine.Random.Range(-3, 5);
                break;
        }

        return spawnPos == previousSpawnPos ? GetRandomSpawnPos(index) : spawnPos;
    }

    public void CheckRows(float yPosition)
    {
        Vector2 rayOrigin = new Vector2(-2.4f, yPosition);

        RaycastHit2D[] hits = Physics2D.RaycastAll(rayOrigin, Vector2.right, 4.8f, groundLayer.value);

        if (hits.Length == 10)
        {
            FindObjectOfType<Score>().UpdateScore(100);
            foreach (var hit in hits)
            {
                Destroy(hit.transform.gameObject);
            }

            MoveBlocksDown(yPosition);
        }
    }

    void MoveBlocksDown(float yPosition)
    {
        for (int i = -5; i < 5; i++)
        {
            Vector2 rayOrigin = new Vector2(i * 0.48f + 0.24f, yPosition);

            RaycastHit2D[] hits = Physics2D.RaycastAll(rayOrigin, Vector2.up, Mathf.Infinity, groundLayer.value);
            if (hits.Length > 0)
            {
                foreach (var hit in hits)
                {
                    hit.transform.Translate(0.48f * Vector2.down);
                }
            }
        }
    }

    void OnPauseStateChanged(bool state)
    {
        enabled = !state;
    }

    void OnGameOver()
    {
        enabled = false;
    }
}