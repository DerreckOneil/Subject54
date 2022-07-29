using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Stats : MonoBehaviour
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
    private GameObject gun;
    [SerializeField]
    private GameObject ammoMag;
    [SerializeField]
    private GameObject myPivot;
    [SerializeField]
    private int explosiveForce;
    [SerializeField]
    private int explosiveRadius;


    public bool burned;
    public bool dead;
    public static int maxPosibility = 5;
    bool spawned;
    // Start is called before the first frame update
    void Start()
    {
        //fireGO = GameObject.FindWithTag("Fire");
        fireGO.SetActive(false);
        fireGO2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            print("I'm dead");
            dead = true;

            PlayerStats.KIAs += .1f;
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        print("enemyHIT!");
        if (coll.gameObject.tag == "PlayerBullet")
        {
            print("I was hit by player!");
            //health--;
            gun.SetActive(false);
            StartCoroutine(beforeDeath());
            PlayerStats.score += 100;
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
            gun.SetActive(false);
            StartCoroutine(beforeDeath());
        }
        if (coll.gameObject.tag == "Fire")
        {
            print("Burned!!! Instant Death!");
            burned = true;
            fireGO.SetActive(true);
            fireGO2.SetActive(true);
            gun.SetActive(false);
            StartCoroutine(beforeDeath());
        }
        if (coll.gameObject.tag == "Grab")
        {
            print("Hit by throwable");
            gun.SetActive(false);
            StartCoroutine(beforeDeath());
        }
        if (coll.gameObject.tag == "PlayerHB")
        {
            CharacterController CPlayer = coll.gameObject.GetComponent<CharacterController>();
            print("I ran into the player!");
            //CPlayer.Move(Vector3.back * 10);
            //coll.gameObject.transform.parent.GetComponent<Rigidbody>().AddExplosionForce(explosiveForce, coll.gameObject.transform.position, explosiveRadius);
            //coll.gameObject.transform.parent.GetComponent<CharacterController>().Move(Vector3.back * explosiveForce * Time.deltaTime);
            float Zpos = coll.gameObject.transform.position.z;
            //coll.gameObject.transform.Translate(Vector3(coll.gameObject.transform.position.x, coll.gameObject.transform.position.y, Zpos -= (float)explosiveForce * Time.deltaTime)); 
            //coll.gameObject.transform.parent.Translate(Vector3.back * explosiveForce * Time.deltaTime);
        }
    }

    IEnumerator beforeDeath()
    {
        dead = true;
        yield return new WaitForSeconds(1.5f);
        int randomNum = Random.Range(1,maxPosibility);
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
            switch (rnum)
            {
                case 1:
                    print("num 1");
                    spawned = false;
                    break;
                case 2:
                    if (!spawned)
                    {
                        Instantiate(ammoMag, myPivot.transform.position, myPivot.transform.rotation);
                        print("num 2");
                        spawned = true;
                    }
                    break;
                case 3:
                    print("num 3");
                    spawned = false;
                    break;
                case 4:
                    print("num 4");
                    spawned = false;
                    break;
                case 5:
                    print("num 5");
                    spawned = false;
                    break;
            }
            dead = false;
        }

    }
     void downFiveUnits()
    {
        for (int i = 0; i<10; i++)
        {
            float posY;
            posY = transform.position.y;
            gameObject.transform.position = new Vector3(transform.position.x, posY -= .1f * Time.deltaTime, transform.position.z);
        }
    }
}
