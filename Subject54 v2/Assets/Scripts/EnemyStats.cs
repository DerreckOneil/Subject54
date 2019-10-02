using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
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

    public bool burned;
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

            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        print("enemyHIT!");
        if(coll.gameObject.tag == "PlayerBullet")
        {
            print("I was hit by player!");
            health--;
            PlayerStats.score += 100;
        }
        if(coll.gameObject.tag == "Fire")
        {
            print("Burned!!! Instant Death!");
            burned = true;
            fireGO.SetActive(true);
            fireGO2.SetActive(true);
            gun.SetActive(false);
            StartCoroutine(beforeDeath());
        }
    }

    IEnumerator beforeDeath()
    {
        yield return new WaitForSeconds(1.5f);
        health = 0;
        PlayerStats.score += 150;
    }
}
