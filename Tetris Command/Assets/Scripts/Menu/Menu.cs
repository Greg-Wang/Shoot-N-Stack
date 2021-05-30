using System.Collections;
using UnityEngine;
using static CoroutineHelper;

[RequireComponent(typeof(Canvas))]
public abstract class Menu : MonoBehaviour
{
    protected Canvas thisMenu;

    Camera mainCam;
    AnimationCurve zoomInterpolation = AnimationCurve.EaseInOut(0, 0, 1, 1);

    protected virtual void Awake()
    {
        thisMenu = GetComponent<Canvas>();
        mainCam = Camera.main;
    }

    public void Open()
    {
        thisMenu.enabled = true;
        if (thisMenu.TryGetComponent(out Menu m)) m.Enable();
    }

    public void Close()
    {
        thisMenu.enabled = false;
        Disable();
    }

    public void Disable()
    {
        if (TryGetComponent(out CanvasGroup cg))
        {
            cg.interactable = false;
            cg.blocksRaycasts = false;
        }

        enabled = false;
    }

    public void Enable()
    {
        if (TryGetComponent(out CanvasGroup cg))
        {
            cg.interactable = true;
            cg.blocksRaycasts = true;
        }

        enabled = true;
    }

    public void LoadScene(int sceneIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }

    protected IEnumerator Zoom(float startSize, float endSize, int sceneIndex)
    {
        float currentLerpTime = 0f;
        float totalLerpTime = 1f;
        
        mainCam.orthographicSize = startSize;

        while(currentLerpTime < totalLerpTime)
        {
            yield return EndOfFrame;
            currentLerpTime += Time.deltaTime;

            mainCam.orthographicSize = Mathf.Lerp(startSize, endSize, zoomInterpolation.Evaluate(currentLerpTime / totalLerpTime));
        }

        LoadScene(sceneIndex);
    }
}