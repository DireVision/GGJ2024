using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text eventText;

    float score = 0f;

    void Start()
    {
        scoreText.text = "Score: 0";
        eventText.text = "";
    }

    void Update()
    {
        score += Time.deltaTime;
        
        scoreText.text = "Score: " + (int)score;
    }

    public void SetEvent(string text)
    {
        eventText.text = text;
    }

    public void DeductScore(float s)
    {
        score -= s;
    }
}
