using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject EnemyBullet;
    public AudioSource soundPlayer;
    public AudioClip shootSound;

    [Range(0.0f, 1.0f)]
    public float ShotVolume;

    EnemyStats enemy;
    Enemy2Stats enemy2;
    Enemy3Stats enemy3;
    // Start is called before the first frame update
    void Start()
    {
        enemy = this.gameObject.GetComponent<EnemyStats>();
        enemy2 = this.gameObject.GetComponent<Enemy2Stats>();
        enemy3 = gameObject.GetComponent<Enemy3Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        float time;
        time = Time.fixedTime;
        if(time % 1 == 0 && time != 0)
        {
            print("Every one second");
            if (enemy != null)
            {
                if (StopTimeMech.state == TimeState.Normal && !enemy.burned)
                {
                    soundPlayer.PlayOneShot(shootSound, ShotVolume);
                    spawnBullet();
                }
                
            }
            if (enemy2 != null)
            {
                if (StopTimeMech.state == TimeState.Normal && !enemy2.burned)
                {
                    soundPlayer.PlayOneShot(shootSound, ShotVolume);
                    spawnBullet();
                }
            }
        }


    }

    void spawnBullet()
    {
        Instantiate(EnemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}
