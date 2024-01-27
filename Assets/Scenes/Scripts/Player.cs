using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Dir
{
    LEFT,
    RIGHT,
    NONE
}

public enum LANE
{   
    ONE = 1,
    TWO = 2,
    THREE = 3
}

public struct SyncInput
{
    public float timeToConfirm;
    public Dir player1;
    public Dir player2;
};

public class Player : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public bool isInversed = true;
    
    SyncInput controlState;
    LANE currentLane;

    void Start()
    {
        ResetInputs();  
        currentLane = LANE.TWO; 
    }

    void ResetInputs()
    {
        controlState.timeToConfirm = 0.0f;
        controlState.player1 = Dir.NONE;
        controlState.player2 = Dir.NONE;
    }

    void MovePlayers(Dir direction)
    {
        if (isInversed)
        {
            if (direction == Dir.RIGHT && currentLane != LANE.ONE)
            {
                currentLane-=1;
                player1.transform.position = player1.transform.position + new Vector3(-3f,0,0);
                player2.transform.position = player2.transform.position + new Vector3(-3f,0,0);
            }
            else if (direction == Dir.LEFT && currentLane != LANE.THREE)
            {
                currentLane+=1;
                player1.transform.position = player1.transform.position + new Vector3(3f,0,0);
                player2.transform.position = player2.transform.position + new Vector3(3f,0,0);
            }
        }
        else
        {
            if (direction == Dir.LEFT && currentLane != LANE.ONE)
            {
                currentLane-=1;
                player1.transform.position = player1.transform.position + new Vector3(-3f,0,0);
                player2.transform.position = player2.transform.position + new Vector3(-3f,0,0);
            }
            else if (direction == Dir.RIGHT && currentLane != LANE.THREE)
            {
                currentLane+=1;
                player1.transform.position = player1.transform.position + new Vector3(3f,0,0);
                player2.transform.position = player2.transform.position + new Vector3(3f,0,0);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            controlState.player1 = Dir.LEFT;
            if (controlState.timeToConfirm <= 0.0f)
            {
                controlState.timeToConfirm = 0.25f;
            }
        }
        if (Input.GetKeyDown(KeyCode.J)) 
        {
            controlState.player2 = Dir.LEFT;
            if (controlState.timeToConfirm <= 0.0f)
            {
                controlState.timeToConfirm = 0.25f;
            }
        }
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            controlState.player1 = Dir.RIGHT;
            if (controlState.timeToConfirm <= 0.0f)
            {
                controlState.timeToConfirm = 0.25f;
            }
        }
        if (Input.GetKeyDown(KeyCode.L)) 
        {
            controlState.player2 = Dir.RIGHT;
            if (controlState.timeToConfirm <= 0.0f)
            {
                controlState.timeToConfirm = 0.25f;
            }
        }

        if (controlState.player1 == controlState.player2)
        {
            if (controlState.player1 == Dir.LEFT)
            {
                MovePlayers(Dir.LEFT);
                ResetInputs();
            }
            else if (controlState.player1 == Dir.RIGHT)
            {
                MovePlayers(Dir.RIGHT);
                ResetInputs();
            }
        }

        if (controlState.timeToConfirm <= 0.0f)  //Reset if time is up
        {
            ResetInputs();
        }
        
        controlState.timeToConfirm -= Time.deltaTime;
    }
}
