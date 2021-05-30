using System;
using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
    public event Action GameOverAction;

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameOverAction?.Invoke();
    }
}