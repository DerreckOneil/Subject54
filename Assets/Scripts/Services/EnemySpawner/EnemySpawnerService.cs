using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemySpawnerService : ScriptableObject
{
    //There will only be one of these...no interface attached.
    [SerializeField] private GameRuntime gameRuntime;

    [SerializeField] private GameObject[] spawnPoints; 

    //Need a reference to the current game state; whether or not if the round has ended etc.

}
