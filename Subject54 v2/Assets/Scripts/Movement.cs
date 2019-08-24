using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 0;
    public static float timeFrame = 1;
    //private float rand;
    // Use this for initialization
    void Start()
    {

        //rand = Random.Range(.6f,1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += Vector3.forward * moveSpeed; 
        transform.Translate(Vector3.forward * moveSpeed * timeFrame);

    }
}
