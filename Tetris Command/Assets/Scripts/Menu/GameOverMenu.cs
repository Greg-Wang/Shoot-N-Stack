using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : Menu
{
    [SerializeField] Image gameBackgroundImage;
    [SerializeField] Image menuBackgroundImage;
    [SerializeField] Sprite menuBackground;

    protected override void Awake()
    {
        base.Awake();
        FindObjectOfType<GameOverHandler>().GameOverAction += Open;
    }

    public void OnSelectBack()
    {
        StartCoroutine(Zoom(2.5f, 5f, 0));
        gameBackgroundImage.color = Color.black;
        menuBackgroundImage.sprite = menuBackground;
        menuBackgroundImage.color = Color.white;
    }
}