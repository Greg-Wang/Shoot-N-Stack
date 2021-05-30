using UnityEngine;

public class MainMenu : Menu
{
    [SerializeField] ParticleSystem mainMenuParticles;

    public void OnSelectPlay()
    {
        mainMenuParticles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

        Close();
        StartCoroutine(Zoom(5f, 2.5f, 1));
    }

    public void OnSelectQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();        
#endif
    }
}