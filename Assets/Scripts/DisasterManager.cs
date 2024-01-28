using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisasterManager : MonoBehaviour
{
    bool isEventHappening = false;
    float timer;            //how long event lasts for
    public float rerollTimer = 10.0f;
    [SerializeField]
    Player player;
    [SerializeField]
    ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEventHappening)
        {
            if (rerollTimer <= 0.0f)
            {
                float i = Random.Range(0.0f, 100f);
                if (i < 50f)
                {
                    player.isInversed = true;
                    timer = 10.0f;
                    isEventHappening = true;
                    scoreManager.SetEvent("INVERSE CONTROLS!!");
                }
                else rerollTimer = 10.0f;
            }
            
            rerollTimer -= Time.deltaTime;
        }

        timer -= Time.deltaTime;

        if (timer < 0.0f && isEventHappening)
        {
            player.isInversed = false;
            timer = 0.0f;
            scoreManager.SetEvent("");
            rerollTimer = 10.0f;
            isEventHappening = !isEventHappening;
        }
    }
}
