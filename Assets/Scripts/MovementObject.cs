using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementObject : MonoBehaviour
{
    public float MoveSpeed;
    public float distance;
    public bool surpriseObstacle;
    LevelManager LM;
    HealthManager HM;
    bool check;
    AudioSource collectionSoundEffect;
    AudioSource obstacleSoundEffect;

    private void Start()
    {
        check = false;
        LM = FindObjectOfType<LevelManager>();
        HM = FindObjectOfType<HealthManager>();
        obstacleSoundEffect = LM.GetComponent<AudioSource>();
        collectionSoundEffect = HM.GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
            Vector3 forwardMovement = transform.forward * MoveSpeed * Time.fixedDeltaTime * LM.difficulty;
            transform.position -= forwardMovement;

            distance += (MoveSpeed * Time.fixedDeltaTime);
            if (surpriseObstacle && distance >= 10)
            {
            surpriseObstacle = false;
            int random = 0;
            if (transform.position.x < 0)
            {
                random = Random.Range(1, 3);
            }
            else if (transform.position.x > 0)
            {
                random = Random.Range(-2, 0);
            }
            else if (transform.position.x == 0)
            {
                random = Random.Range(-1, 2);
            }
            transform.position = transform.position + new Vector3(random * 3.33f, 0, 1);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!check)
            {
                Destroy();
            }
            check = true;
        }
    }

    void Destroy()
    {
        if (gameObject.tag == "Obstacle")
        {
            obstacleSoundEffect.Play();
            Destroy(gameObject);
            LM.lives -= 1;
            HM.TakeDamage(100 / 3);
        }
        if (gameObject.tag == "Collectible")
        {
            collectionSoundEffect.Play();
            Destroy(gameObject);
            LM.score += 1000;
        }
        if (gameObject.tag == "Healable")
        {
            collectionSoundEffect.Play();
            Destroy(gameObject);
            if (LM.lives < 3)
            {
                LM.lives += 1;
                HM.Heal(100 / 3);
            }
        }
    }
}
