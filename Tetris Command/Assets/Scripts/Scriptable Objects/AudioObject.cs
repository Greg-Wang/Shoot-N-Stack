using UnityEngine;

[CreateAssetMenu(fileName = "New Audio Source", menuName = "Custom Data Type/Audio Source")]
public class AudioObject : ScriptableObject
{
    public AudioSource aux;
}