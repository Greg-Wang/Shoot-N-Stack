using UnityEngine;

public class TetrominoSpawner : CustomYieldInstruction
{
    public override bool keepWaiting => !Object.FindObjectOfType<Game>().enabled;
}