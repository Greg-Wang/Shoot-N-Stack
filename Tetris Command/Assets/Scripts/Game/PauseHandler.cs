using System;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    bool isPaused;
    public event Action<bool> PauseAction;

    void Awake()
    {
        FindObjectOfType<GameOverHandler>().GameOverAction += OnGameOver;
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            isPaused = !isPaused;
            PauseAction?.Invoke(isPaused);
        }
    }

    void OnGameOver()
    {
        enabled = false;
    }
}