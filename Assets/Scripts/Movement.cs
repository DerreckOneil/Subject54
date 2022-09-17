using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 0;
    public static float timeFrame = 1;
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.forward *moveSpeed * timeFrame);

    }

    void OnCollisionEnter(Collision coll)
    {
        print("I Collided with something!!!");
        if (coll.gameObject.tag == "Player")
        {
            print("I hit the Player!");
            //call some public function that is accessed via editor for this maybe...
            //PlayerStats.health--;
            //PlayerInteraction.playerHit = true;
        }
        if(coll.gameObject.tag == "Target")
        {
            print("I hit the enemy!!!");

        }
        Destroy(gameObject);
    }
}
