using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] private PlayerStatsContainer playerStatsContainer;
    //I wanna have the health accessible across scenes. This means I want it in something like a SO
    //such that when the game goes from scene to scene, everything doesn't disapate
    [SerializeField] private int health;
    [SerializeField] private string playerName;
    [SerializeField] private int score;
    [SerializeField] private int killPoints;

    [SerializeField] private GameRuntime gameRuntime;

    // Start is called before the first frame update
    void Awake()
    {
        SetPlayerStats();
        
                    
        //health will stay as is between scenes but must be set upon start of game...
        //score will stay as is between scenes

    }

    private void SetPlayerStats()
    {
        playerName = playerStatsContainer.PlayerName;
        health = playerStatsContainer.Health;
        score = playerStatsContainer.Score;
        killPoints = playerStatsContainer.KillPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //editor method everytime the player is hit...update the stats accordingly
    
}
