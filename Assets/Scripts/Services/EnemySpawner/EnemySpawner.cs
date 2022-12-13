using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviourService
{
    [SerializeField] private UnityEvent onWaveStarted; //Done for modularity...just in case I decide to do something else during spawn.

    [SerializeField] private UnityEvent onWaveEnded;

    [SerializeField] private GameObject[] spawnPoints;

    private GameObject enemy;

    private void Start()
    {
        enemy = GameRuntime.ServiceLocator.GetService<EnemySpawnerSystem>().Enemy;
    }

    public void OnWaveStarted()
    {
        GameRuntime.ServiceLocator.GetService<EnemySpawnerSystem>().WaveState = WaveState.Started;

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(enemy, enemy.gameObject.transform.position, enemy.gameObject.transform.rotation);
        }
    }

    public void OnWaveEnded()
    {
        GameRuntime.ServiceLocator.GetService<EnemySpawnerSystem>().WaveState = WaveState.Ended;

    }



}
