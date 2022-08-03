using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    
    public NavMeshAgent enemyNav;
    GameObject target;

    [SerializeField]
    private Animator EnemyAnimEngine;
    [SerializeField]
    private GameObject Gun;

    bool movementActivated = false;
    [SerializeField]
    private Enemy2Stats refs;
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        if (gameObject.name == "EnemyPivot")
        {
            refs = transform.parent.GetComponent<Enemy2Stats>();
        }
        if (EnemyAnimEngine != null)
        {
            StartCoroutine(beginRunning());

            Gun.SetActive(false);
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
        //Check to see if burned is true
        if (refs != null)
        {
            print("Burned: " + refs.burned);
            print("Dead: " + refs.dead);
            if (refs.dead)
            {
                StartCoroutine(deathState());
            }

        }
        if (StopTimeMech.state == TimeState.Normal)
        {
            EnemyAnimEngine.enabled = true;
            enemyNav.speed = 1.5f;
            FollowPlayer();
        }
        else
        {
            enemyNav.speed = 0;
            EnemyAnimEngine.enabled = false;
        }

        if (StopTimeMech.state == TimeState.Normal)
        {
            print("Look at player");
            transform.LookAt(target.transform.position);
        }
        else
        {
            print("Game state is different...");
        }

        


    }
    void FollowPlayer()
    {
        if (target != null)
        {
            enemyNav.SetDestination(target.transform.position);
        }
    }
    IEnumerator beginRunning()
    {
        
        yield return new WaitForSeconds(1.5f);
        EnemyAnimEngine.SetTrigger("ToRunState");

        print("go to run state");
        Gun.SetActive(true);

    }
    IEnumerator IdleState()
    {
        yield return new WaitForSeconds(1);
        EnemyAnimEngine.SetTrigger("ToIdleState");

    }

    IEnumerator deathState()
    {
        EnemyAnimEngine.SetTrigger("Dead");
        yield return new WaitForSeconds(1);
        
    }
}
