using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAbilityEffects : MonoBehaviour
{
    [SerializeField]
    private GameObject fire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision coll)
    {
        Instantiate(fire, gameObject.transform.position, gameObject.transform.rotation);
    }
}
