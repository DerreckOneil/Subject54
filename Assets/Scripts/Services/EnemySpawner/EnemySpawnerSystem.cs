using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class EnemySpawnerSystem : ScriptableObject
{
    [SerializeField] private GameRuntime gameRuntime;

    private WaveState waveState;

    public WaveState WaveState
    {
        get { return waveState; }
        set
        {
            Debug.Log("Changing the wave state");
            WaveState previous = waveState;
            waveState = value;
            //Let's not worry about notifying the other listeners regarding this.
        }
    }

    [SerializeField] private GameObject enemy;

    public GameObject Enemy => enemy;

    //There should be multiple SO for this per scene (if I decide to create another scene. )

    //Need a reference to the current game state; whether or not if the round has ended etc.




}
