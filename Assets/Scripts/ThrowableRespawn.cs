using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableRespawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform sp1;
    [SerializeField]
    private Transform sp2;
    [SerializeField]
    private Transform sp3;
    [SerializeField]
    private Transform sp4;
    EnemySpawner refs;
    bool once;

    [SerializeField]
    private GameObject throwableObj;
    void Start()
    {
        
        refs = gameObject.GetComponent<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {

        if(refs.waveEnd && !once)
        {
            Debug.Log("Spawning some Objs!!!!!!!!!!");
            Instantiate(throwableObj, sp1.transform.position, sp1.transform.rotation);
            Instantiate(throwableObj, sp2.transform.position, sp2.transform.rotation);
            Instantiate(throwableObj, sp3.transform.position, sp3.transform.rotation);
            Instantiate(throwableObj, sp4.transform.position, sp4.transform.rotation);
            once = true;
        }

        if(refs.waveEnd == false)
        {
            once = false;
        }
    }
}
