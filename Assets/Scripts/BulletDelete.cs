using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDelete : MonoBehaviour
{

    GameObject Player;
    float distanceAway;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distanceAway = Vector3.Distance(transform.position, Player.transform.position);
        //print("This bullet is: " + distanceAway + " Units away from player!");
        if (distanceAway > 100)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "PlayerBullet")
        {
            print("I collided with myself!");
            Destroy(coll.gameObject);
        }
    }
}
