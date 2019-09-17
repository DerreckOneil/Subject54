using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] spawnPoint;


    GameObject[] numEnemies;
    int numE;

    public static int wave;
    public Text waveText;

    bool waveEnd;
    bool waited;
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        wave++;
        spawnPoint = GameObject.FindGameObjectsWithTag("sp");
    }

    // Update is called once per frame
    void Update()
    {
        waveText.text = "Wave: " + wave;
        numEnemies = GameObject.FindGameObjectsWithTag("Target");

        print("Enemy/enemies: " + numEnemies.Length);

        if(numEnemies.Length <= 0 && waveEnd ==false)
        {
            waveEnd = true;
            print("there are no more enemies!");
            
            StartCoroutine(newRoundPause());
            //spawnEnemy();
        }
    }

    
    IEnumerator newRoundPause()
    {
        waited = false;
        print("wait!");
        yield return new WaitForSeconds(2);
        print("Okay, new round");
        if (waveEnd)
        {
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                Instantiate(enemyPrefab, spawnPoint[i].transform.position, spawnPoint[i].transform.rotation);

            }
        }
        print("spawned!");

        waveEnd = false;
        wave++;
        waited = true;
    }
}
