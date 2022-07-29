using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy3Stats : MonoBehaviour
{
    [SerializeField]
    private int health = 1;
    [SerializeField]
    private ParticleSystem ps;
    [SerializeField]
    private GameObject fireGO;
    [SerializeField]
    private GameObject fireGO2;
    
    [SerializeField]
    private GameObject ammoMag;
    
    [SerializeField]
    private int explosiveForce;
    [SerializeField]
    private int explosiveRadius;


    public bool burned;
    public bool dead;
    public static int maxPosibility = 5;

    [SerializeField] private Slider healthBar;
    bool spawned;
    int maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        //fireGO = GameObject.FindWithTag("Fire");
        fireGO.SetActive(false);
        fireGO2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
    }

    void OnCollisionEnter(Collision coll)
    {
        print("enemyHIT!");
        if (coll.gameObject.tag == "PlayerBullet")
        {
            print("I was hit by player!" + health);
            health--;
            //
            
            if (health <= 0)
            {
                print("I'm dead");
               
                StartCoroutine(beforeDeath());
                PlayerStats.score += 100;
                PlayerStats.KIAs += .1f;
                
            }
            

        }
        /*
        if (coll.gameObject.tag == "Fire")
        {
            print("Burned!!! Instant Death!");
            burned = true;
            fireGO.SetActive(true);
            fireGO2.SetActive(true);
            gun.SetActive(false);
            StartCoroutine(beforeDeath());
        }
        */
    }
    void OnTriggerEnter(Collider coll)
    {
        print("I hit: " + coll.name);
        if (coll.gameObject.tag == "PlayerFire")
        {
            print("Burned!!! Instant Death!");
            burned = true;
            fireGO.SetActive(true);
            fireGO2.SetActive(true);
            //gun.SetActive(false);
            StartCoroutine(beforeDeath());
        }
        if (coll.gameObject.tag == "Fire")
        {
            print("Burned!!! Instant Death!");
            burned = true;
            fireGO.SetActive(true);
            fireGO2.SetActive(true);
            //gun.SetActive(false);
            StartCoroutine(beforeDeath());
        }
        if (coll.gameObject.tag == "Grab")
        {
            print("Hit by throwable");
            //gun.SetActive(false);
            //StartCoroutine(beforeDeath());
        }
        if (coll.gameObject.tag == "PlayerHB")
        {
            CharacterController CPlayer = coll.gameObject.GetComponent<CharacterController>();
            print("I ran into the player!");

            float Zpos = coll.gameObject.transform.position.z;
        }
    }

    IEnumerator beforeDeath()
    {
        dead = true;
        yield return new WaitForSeconds(1.5f);
        int randomNum = Random.Range(1, maxPosibility);
        ammoSpawn(randomNum);
        downFiveUnits();
        //yield return new WaitForSeconds(.5f);

        health = 0;
        PlayerStats.score += 150;


    }
    void ammoSpawn(int rnum)
    {

        if (dead)
        {
            
            Instantiate(ammoMag, transform.position, transform.rotation);      
            dead = false;
        }

    }
    void downFiveUnits()
    {
        for (int i = 0; i < 10; i++)
        {
            float posY;
            posY = transform.position.y;
            gameObject.transform.position = new Vector3(transform.position.x, posY -= .1f * Time.deltaTime, transform.position.z);
        }
    }
}
