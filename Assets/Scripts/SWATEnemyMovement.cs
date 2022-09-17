using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SWATEnemyMovement : MonoBehaviour
{
    public NavMeshAgent enemyNav;
    GameObject target;

    [SerializeField]
    private Animator EnemyAnimEngine;

    //[SerializeField] private Enemy3Stats refs;
    bool slashing;

    public bool Slashing
    {
        get
        {
            return slashing;
        }
        set
        {
            slashing = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
       
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (StopTimeMech.state == TimeState.Normal)
        {
            print("Look at player");
            transform.LookAt(target.transform.position);
            EnemyAnimEngine.enabled = true;
            enemyNav.speed = 1.5f;
            FollowPlayer();
        }
        else
        {
            enemyNav.speed = 0;
            EnemyAnimEngine.enabled = false;
        }
        if(refs.dead)
        {
            StartCoroutine(Death());
        }
        */

    }
    void FollowPlayer()
    {
        if (target != null)
        {
            enemyNav.SetDestination(target.transform.position);

        }
        if(Vector3.Distance(transform.position, target.transform.position) < 2.0f)
        {
            StartCoroutine(Attack());
        }
        else
        {
            EnemyAnimEngine.SetTrigger("Walk");
        }
        
    }
    IEnumerator Attack()
    {
        //slashing = true;
        enemyNav.speed = 0;
        EnemyAnimEngine.SetTrigger("Slash");
        yield return new WaitForSeconds(1);
        //slashing = false;
        
    }
    IEnumerator Death()
    {
        EnemyAnimEngine.SetTrigger("Dead");
        yield return new WaitForSeconds(1.5f);
        Destroy(transform.parent.gameObject);
    }

}
