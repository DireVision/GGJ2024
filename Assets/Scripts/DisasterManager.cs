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
    [SerializeField]
    InstantiateObject spawner;

    int currentEvent = 0;

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
                    isEventHappening = true;
                    switch (Random.Range(0, 2))
                    {
                        case 1:
                            currentEvent = 0;
                            player.isInversed = true;
                            timer = 10.0f;
                            scoreManager.SetEvent("INVERSE CONTROLS!!");
                            break;
                        case 0:
                            currentEvent = 1;
                            spawner.eventHappening = true;
                            timer = 10.0f;
                            scoreManager.SetEvent("SENTIENT WALLS!!");
                            break;
                    }
                    
                }
                else rerollTimer = 10.0f;
            }
            
            rerollTimer -= Time.deltaTime;
        }

        timer -= Time.deltaTime;

        if (timer < 0.0f && isEventHappening)
        {
            switch(currentEvent)
            {
                case 0:
                    player.isInversed = false;
                    break;
                case 1:
                    spawner.eventHappening = false;
                    break;
            }

            timer = 0.0f;
            scoreManager.SetEvent("");
            rerollTimer = 10.0f;
            isEventHappening = !isEventHappening;
        }
    }
}
