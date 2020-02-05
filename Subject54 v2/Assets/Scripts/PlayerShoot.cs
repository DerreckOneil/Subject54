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
    [SerializeField]
    private GameObject fbSpawnPoint2;

    int pistolMag = 0;
    public int pistolBullets;
    int bulletsNeeded;
    public static bool empty;

    [SerializeField]
    private Text gunText;
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
    [SerializeField] private Animator fireballAnimator;

    

    // Start is called before the first frame update
    void Start()
    {
        fire = true;
        pistolBullets = 7;
        //gunReload.enabled = true;
        //spawnPoint = GameObject.FindWithTag("").transform;
    }

    // Update is called once per frame

    
    void Update()
    {
        
        if(pistolBullets < 0)
        {
            pistolBullets = 0;
        }
        if(pistolBullets > 0)
        {
            empty = false;
        }
        print("grab from ps: " + PlayerThrowMechanic.grab);
        if (Input.GetKeyDown(KeyCode.Mouse0) && PlayerInventory.Pistol && PlayerThrowMechanic.grab == false)
        {


            
                print("Shoot!");
                if (pistolMag <= 0 && stopShooting == false)
                {

                    if (pistolBullets <= 0 && pistolMag <= 0)
                    {
                        soundPlayer.PlayOneShot(clickSound, ShotVolume);
                        empty = true;
                    }
                    else
                    {
                        stopShooting = true;
                        soundPlayer.PlayOneShot(clickSound, ShotVolume);
                        waiting = true;

                        StartCoroutine(quickPause());
                    }
                }
                

                if (!waiting)
                {
                    soundPlayer.PlayOneShot(shootSound, ShotVolume);
                }

                if (!stopShooting)
                {
                    StartCoroutine(shootBullet());
                    pistolMag--;
                }
                else
                {
                    soundPlayer.PlayOneShot(clickSound, ShotVolume);
                }
        }

        if (Input.GetKeyDown(KeyCode.R) && PlayerInventory.Pistol && pistolBullets > 0)
        {
            stopShooting = true;
            waiting = true;
            StartCoroutine(quickPause());
        }

        if (Input.GetKeyDown(KeyCode.Mouse2) && PlayerInventory.Pistol && PlayerStats.energy > 1 && stopShooting == false)
        {
            print("shoot Fireball!");
                if (fire)
                {
                    StartCoroutine(shootFireball());
                }
            
        }
        if (Input.GetKeyDown(KeyCode.Mouse2) && PlayerStats.energy > 1 && stopShooting == false)
        {
            print("shoot Fireball!");
            if (fire)
            {
                StartCoroutine(shootFireballIdle());
            }

        }

        if (PlayerInventory.Pistol)
        {
            gunText.text = "Pistol: " + pistolMag + "/ " + pistolBullets;
        }
        else
        {
            gunText.text = "";
        }
    }


    void spawnBullet()
    {
        print("spawning bullet");
        Instantiate(playerBullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

     IEnumerator quickPause()
    {
        Debug.Log("Let's wait a bit");
        //gunReload = GameObject.FindWithTag("Pistol").GetComponent<Animator>();
        
        soundPlayer.PlayOneShot(reloadSound, ShotVolume);
        gunReload.SetTrigger("Reloading");

        YieldInstruction yield = new WaitForSeconds(1.6f);
        yield return yield;

        //yield return new WaitForSeconds(2.6f);
        if (pistolBullets > 7)
        {
            bulletsNeeded = (7-pistolMag);
            pistolBullets = pistolBullets - bulletsNeeded;
            pistolMag += bulletsNeeded;
        }
        else
        {
            //bulletsNeeded = (pistolMag-7);
            //pistolBullets = pistolBullets + bulletsNeeded;
            
            if(pistolMag + pistolBullets <= 7)
            {
                pistolMag = pistolMag + pistolBullets;
                print("mag: " + pistolMag + "pistolBullets: " + pistolBullets);
                pistolBullets = 0;
            }
            else
            {
                bulletsNeeded = (pistolMag - 7);
                pistolBullets = pistolBullets + bulletsNeeded;
                pistolMag -= bulletsNeeded;
            }
        }

        

        gunReload.SetTrigger("BackToIdle");

        Debug.Log("Ok...start shooting again");
        stopShooting = false;
        
        waiting = false;
    }

    IEnumerator shootFireball()
    {
        fire = false;
        gunReload.SetTrigger("MeleeHit");
        yield return new WaitForSeconds(0.85f);
        Instantiate(fireBall, fbSpawnPoint.transform.position, fbSpawnPoint.transform.rotation);
        PlayerStats.energy--;
        yield return new WaitForSeconds(.2f);
        fire = true;
    }
    IEnumerator shootFireballIdle()
    {
        fire = false;
        fireballAnimator.SetTrigger("Fireball");
        yield return new WaitForSeconds(0.85f);
        Instantiate(fireBall, fbSpawnPoint2.transform.position, fbSpawnPoint2.transform.rotation);
        PlayerStats.energy--;

        yield return new WaitForSeconds(.2f);
        fire = true;
    }
    IEnumerator shootBullet()
    {
        print("going to Corotine...");
        gunReload.SetTrigger("PistolShoot");
        stopShooting = true;
        spawnBullet();
        yield return new WaitForSeconds(0.04f); //Keep below 0.1f (.05f is good so far...)
        gunReload.SetTrigger("BackToIdle");
        yield return new WaitForSeconds(0.25f);
        stopShooting = false;

    }
}
