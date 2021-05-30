using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public int score = 0;
    private TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateScore(int n)
    {
        score += n;
        int length = 6 - score.ToString().Length;
        scoreText.text = "";

        if (length >0)
        {
            for(int i=0; i < length; i++)
            {
                scoreText.text += "0";
            }
        }

        scoreText.text += score.ToString();
        
    }
}
