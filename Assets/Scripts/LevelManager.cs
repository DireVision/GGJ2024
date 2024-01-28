using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public float[] lane = { -3f, 0f, 3f };
    public float score;
    public int lives;
    public GameObject egUI;
    public TMP_Text scoreboard;
    //public Player pg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            EndGame();
        }
        scoreboard.SetText("Score: " + score);

    }

    void EndGame()
    {
        Time.timeScale = 0;
        egUI.SetActive(true);
    }

    void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
