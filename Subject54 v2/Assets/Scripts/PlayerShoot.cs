using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject playerBullet;
    [SerializeField]
    private GameObject fireBall;
    [SerializeField]
    private GameObject fbSpawnPoint;

    int pistolMag = 7;

    public Text pistolText;
    bool stopShooting;
    bool waiting;
    bool fire;

    public AudioSource soundPlayer;
    public AudioClip shootSound;
    public AudioClip clickSound;
    public AudioClip reloadSound;

    [Range(0.0f, 1.0f)]
    public float ShotVolume;

    public Animator gunReload;

    

    // Start is called before the first frame update
    void Start()
    {
        fire = true;
        //gunReload.enabled = true;
        //spawnPoint = GameObject.FindWithTag("").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && PlayerInventory.Pistol)
        {
            print("Shoot!");
            if (pistolMag <= 0 && stopShooting == false)
            {
                stopShooting = true;
                soundPlayer.PlayOneShot(clickSound, ShotVolume);
                waiting = true;
                StartCoroutine(quickPause());
            }
            if(!waiting)
            {
                soundPlayer.PlayOneShot(shootSound, ShotVolume);
            }

            if (!stopShooting)
            {
                spawnBullet();
                pistolMag--;
            }
        }


        if (Input.GetKeyDown(KeyCode.Mouse2) && PlayerInventory.Pistol && PlayerStats.energy > 1 && stopShooting == false)
        {
            print("shoot Fireball!");
            if (fire)
            {
                StartCoroutine(shootFireball());
            }
            
        }

            if (PlayerInventory.Pistol)
        {
            pistolText.text = "Pistol: " + pistolMag + "/Unlimited";
        }
        else
        {
            pistolText.text = "";
        }
    }
    void spawnBullet()
    {
        Instantiate(playerBullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

     IEnumerator quickPause()
    {
        Debug.Log("Let's wait a bit");
        //gunReload = GameObject.FindWithTag("Pistol").GetComponent<Animator>();
        
        soundPlayer.PlayOneShot(reloadSound, ShotVolume);
        gunReload.SetTrigger("Reloading");
        yield return new WaitForSeconds(2.7f);
        pistolMag = 7;
        gunReload.SetTrigger("BackToIdle");
        Debug.Log("Ok...start shooting again");
        stopShooting = false;
        
        waiting = false;
    }

    IEnumerator shootFireball()
    {
        
        gunReload.SetTrigger("MeleeHit");
        yield return new WaitForSeconds(0.6f);
        Instantiate(fireBall, fbSpawnPoint.transform.position, fbSpawnPoint.transform.rotation);
        fire = true;
    }
}
