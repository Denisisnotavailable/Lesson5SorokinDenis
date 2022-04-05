using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform goal;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    void Update()
    {
        agent.destination = goal.position;
    }
}
