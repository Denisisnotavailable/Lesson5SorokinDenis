using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Petrule : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform[] wayPoints;

    int currentGoal = 0;

    private void Start()
    {
        agent.SetDestination(wayPoints[0].position);
    }

    private void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            currentGoal++;
            agent.SetDestination(wayPoints[currentGoal].position);
            if (currentGoal == wayPoints.Length-1) currentGoal = -1;
        }
    }

}
