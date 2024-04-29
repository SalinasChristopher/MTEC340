using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : StateMachineBehaviour
{

    float timer;
    public float idleTime = 0;

    Transform player;

    public float detectionAreaRadius = 18f;
    

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       timer = 0;
       player = GameObject.FindGameObjectWithTag("PlayerEmpty").transform;

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Transition to Patrol State
        timer += Time.deltaTime;
        if (timer > idleTime)
        {
            animator.SetBool("IsPatrolling", true);
        }

        // Transition to Chase State
        float distanceFromPlayer = Vector3.Distance(player.position, animator.transform.position); 

        if (distanceFromPlayer < detectionAreaRadius)
        {
            animator.SetBool("IsChasing", true);
        }
    }

}
