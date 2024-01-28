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
    public float difficulty = 1f;
    float timer = 0f;

    public AudioSource loseSoundEffect;

    bool gameEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        //loseSoundEffect = gameObject.GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0 && gameEnd == false)
        {
            loseSoundEffect.Play();
            EndGame();
        }
        scoreboard.SetText("Score: " + score);
        timer += Time.deltaTime;

        if (difficulty <= 2.5)
        {
            difficulty = 1 + (1 * (timer / 60));
        }

    }

    void EndGame()
    {
        gameEnd = true;
        Time.timeScale = 0;
        egUI.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ReturnToGame()
    {
        SceneManager.LoadScene("Game");
    }
}
