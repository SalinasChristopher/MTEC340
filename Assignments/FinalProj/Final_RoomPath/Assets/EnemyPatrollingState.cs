using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrollingState : StateMachineBehaviour
{
    float timer;
    public float patrollingTime = 10f;

    Transform player;
    NavMeshAgent agent;

    public float detectionArea = 18f;
    public float patrolSpeed = 2f;
    
    List<Transform> waypointList = new List<Transform>();
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Initializing variables
        player = GameObject.FindGameObjectWithTag("PlayerEmpty").transform;
        agent = animator.GetComponent<NavMeshAgent>();

        agent.speed = patrolSpeed;
        timer = 0;

        // Get all waypoints and move to first waypoint
        GameObject waypointsEmpty = GameObject.FindGameObjectWithTag("Waypoints"); // waypointEmpty is the waypoint cluster
        foreach (Transform t in waypointsEmpty.transform)
        {
            waypointList.Add(t);
        }

        Vector3 nextPosition = waypointList[Random.Range(0, waypointList.Count)].position; // picking a random waypoint from the list
        agent.SetDestination(nextPosition); // setting the waypoint as a destination
       
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // If the agent has arrived at waypoint, move to next
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(waypointList[Random.Range(0, waypointList.Count)].position); // set next destination randomly from the same list
        }

        // Transition to idle state

        timer += Time.deltaTime;
        if (timer > patrollingTime)
        {
            animator.SetBool("IsPatrolling", false);
        }
        
        // Transition to Chase State
        float distanceFromPlayer = Vector3.Distance(player.position, animator.transform.position); 

        if (distanceFromPlayer < detectionArea)
        {
            animator.SetBool("IsChasing", true);
        }

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Stop agent
        agent.SetDestination(agent.transform.position);
       
    }

}
