using UnityEngine;
using UnityEngine.UI;

public class PauseOverlay : Menu
{
    [SerializeField] Image gameBackgroundImage;
    [SerializeField] Image menuBackgroundImage;
    [SerializeField] Sprite menuBackground;

    protected override void Awake()
    {
        base.Awake();
        FindObjectOfType<PauseHandler>().PauseAction += OnPauseStateChanged;
    }

    void OnPauseStateChanged(bool state)
    {
        if (state) Open();
        else Close();
    }

    public void OnSelectBack()
    {
        StartCoroutine(Zoom(2.5f, 5f, 0));
        gameBackgroundImage.color = Color.black;
        menuBackgroundImage.sprite = menuBackground;
        menuBackgroundImage.color = Color.white;
    }
}