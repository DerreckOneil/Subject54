using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootButStopBefore : MonoBehaviour
{
    GameObject Target;

    GameObject [] enemyTargets;
    float[] distanceFromTarget;

    public float moveSpeed = 10.0f;
    TimeState state;
    float distance;

    bool triggered;

    // Start is called before the first frame update
    void Start()
    {
        //Target = GameObject.FindWithTag("Target");
        //enemyTargets = GameObject.FindGameObjectsWithTag("Target");
    }

    // Update is called once per frame
    void Update()
    {
        

        if (PlayerInventory.Knife)
            transform.Translate(Vector3.up *moveSpeed* Time.deltaTime);
        else
            transform.Translate(Vector3.forward *moveSpeed* Time.deltaTime);

        if (triggered)
        {
            print("stop moving");
            moveSpeed = 0;
        }
        if (StopTimeMech.state == TimeState.TimeStopped)
        {
            print("Thrown In stopped Time!");
            
           
            
        }
         if(StopTimeMech.state == TimeState.Normal)
        {
            triggered = false;
            print("now move");
            moveSpeed = 30;
        }


        

        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Target.transform.rotation, 100.0f);
        
    }
    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "StopTrigger")
        {
            print("I triggered the target!");
            triggered = true;
            
        }
    }
    void OnCollisionEnter(Collision coll)
    {
        print("I hit: " + coll.gameObject.name);
        
        if (coll.gameObject.tag == "Target")
        {
            print("I hit the target");
            
        }
        if(!(gameObject.tag == "Fire"))
            Destroy(gameObject);
    }
}
