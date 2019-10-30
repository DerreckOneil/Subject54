﻿using System.Collections;
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


    public bool burned;
    public bool dead;
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
        if (coll.gameObject.tag == "Fire")
        {
            print("Burned!!! Instant Death!");
            burned = true;
            fireGO.SetActive(true);
            fireGO2.SetActive(true);
            gun.SetActive(false);
            StartCoroutine(beforeDeath());
        }
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
    }

    IEnumerator beforeDeath()
    {
        dead = true;
        yield return new WaitForSeconds(1.5f);
        health = 0;
        PlayerStats.score += 150;
    }
}