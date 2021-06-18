using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FearState : BaseState
{
    public NavMeshAgent NMA;
    public Transform scaredPoint;
    [SerializeField] int health;
    [SerializeField] float enemyDist;
    [SerializeField] float destinationReachedTreshold;
    [SerializeField] bool wayPointReached;

    public override void OnEnter()
    {
        Debug.Log("aaaaaaAAAAAAAAAAAH");
        NMA = GetComponent<NavMeshAgent>();
        NMA.SetDestination(scaredPoint.position);
        health--;
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {
        enemyDist = Vector3.Distance(transform.position, scaredPoint.position);

        if (enemyDist < destinationReachedTreshold)
        {
            wayPointReached = true;
        }

        if (wayPointReached)
        {
            wayPointReached = false;
            owner.SwitchState(typeof(PatrolState));
        }
    }
}
