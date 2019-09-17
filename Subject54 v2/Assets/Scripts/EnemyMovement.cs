using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    
    public NavMeshAgent enemyNav;
    GameObject target;
    

    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (StopTimeMech.state == GameStates.Normal)
        {
            enemyNav.speed = 1.5f;
            FollowPlayer();
        }
        else
        {
            enemyNav.speed = 0;
        }

        if (StopTimeMech.state == GameStates.Normal)
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
}
