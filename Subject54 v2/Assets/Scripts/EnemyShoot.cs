using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject EnemyBullet;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float time;
        time = Time.fixedTime;
        if(time % 1 == 0 && time != 0)
        {
            print("Every one second");
            if(StopTimeMech.state == GameStates.Normal)
                spawnBullet();
        }
    }

    void spawnBullet()
    {
        Instantiate(EnemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}
