using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerStatsContainer : ScriptableObject, IPlayerStats
{
    [SerializeField] private int health;
    [SerializeField] private string playerName;
    [SerializeField] private int score;
    [SerializeField] private int killPoints;

    public int Health { get { return health; } set { health = value; } }

    public string PlayerName => playerName;

    public int Score { get { return score; } set { score = value; } }

    public int KillPoints { get { return killPoints; } set { killPoints = value; } }

    
    //Big ohhhhhhh moment here for this syntax and utilizing interfaces with getters.

    //This will go onto each player

    
}
