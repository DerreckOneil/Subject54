using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private PlayerShoot refs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider coll)
    {
        //print("I collided with: " + coll.gameObject.name); //(works)
        if (coll.gameObject.tag == "Mag")
        {
            refs.pistolBullets += 10;
            Destroy(coll.gameObject);
        }
    }
}
