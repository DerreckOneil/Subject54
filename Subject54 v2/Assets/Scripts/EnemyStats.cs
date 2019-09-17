using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int health = 1;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
