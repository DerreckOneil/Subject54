using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] private PlayerStatsContainer playerStatsContainer;
    //I wanna have the health accessible across scenes. This means I want it in something like a SO
    //such that when the game goes from scene to scene, everything doesn't disapate
    [SerializeField] private int health;
    [SerializeField] private string playerName;
    [SerializeField] private int score;
    [SerializeField] private float killPoints;

    [SerializeField] private GameRuntime gameRuntime;

    public UnityEvent OnPlayerHit;

    public float KillPoints
    {
        get { return killPoints; }
        set { killPoints = value; }
    }
    
    // Start is called before the first frame update
    void Awake()
    {
        SetPlayerStats();
        
                    
        //health will stay as is between scenes but must be set upon start of game...
        //score will stay as is between scenes

    }

    private void SetPlayerStats()
    {
        health = playerStatsContainer.Health;
        score = playerStatsContainer.Score;
        killPoints = playerStatsContainer.KillPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Let's use listener pattern here. 
    //editor method everytime the player is hit...update the stats accordingly

    public void DecreaseHealth()
    {
        health--;
        //score +=100;
        //


        //Invoke ScreenShake effect! via editor tho
    }
    
}
