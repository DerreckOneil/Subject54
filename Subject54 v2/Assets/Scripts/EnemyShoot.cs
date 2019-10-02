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
    // Start is called before the first frame update
    void Start()
    {
        enemy = this.gameObject.GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {
        float time;
        time = Time.fixedTime;
        if(time % 1 == 0 && time != 0)
        {
            print("Every one second");
            if (StopTimeMech.state == GameStates.Normal && !enemy.burned)
            {
                soundPlayer.PlayOneShot(shootSound, ShotVolume);
                spawnBullet();
            }
        }
    }

    void spawnBullet()
    {
        Instantiate(EnemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}
