using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeThrow : MonoBehaviour
{
    GameObject Target;
    float moveSpeed = 100.0f;
    GameStates state;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindWithTag("Target");
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Target.transform.position);
        
        transform.Translate(Vector3.up*moveSpeed*Time.deltaTime);
        if (distance <= 5)
        {
            print("I hit the target");
            PlayerInteraction.hits++;

            Destroy(gameObject);
        }
        if (distance <= 20)
        {
            print("I'm Too close!");
            moveSpeed = 0;
        }
        if (distance >= 500)
        {
            Destroy(gameObject);
        }
        if (StopTimeMech.state == GameStates.TimeStop)
        {
            print("Thrown In stopped Time!");
            
           
            
        }
        else
        {
            moveSpeed = 100;
        }
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Target.transform.rotation, 100.0f);
        
    }
    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Target")
        {
            print("I hit the target");
        }
    }
}
