using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameRuntime gameRuntime;

    [SerializeField] private GameObject[] spawnPoints;

    [SerializeField] private UnityEvent OnWaveStarted;

    [SerializeField] private UnityEvent OnWaveEnded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
