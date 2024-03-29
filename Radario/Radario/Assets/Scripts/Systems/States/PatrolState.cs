using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : BaseState
{
    public NavMeshAgent NMA;
    [SerializeField] List<Transform> waypoints = new List<Transform>();
    Transform targetWayPoint;
    int currentWayPointIndex;
    int randomStartPoint;

    public GameObject submarine;

    [SerializeField] float enemyDist;
    [SerializeField] float playerDist;
    [SerializeField] float destinationReachedTreshold;
    [SerializeField] float attackRange;
    [SerializeField] int health = 3;

    [SerializeField] bool wayPointReached;
    private void Start()
    {
        NMA = GetComponent<NavMeshAgent>();
        randomStartPoint = Random.Range(0, waypoints.Count);
        transform.position = waypoints[randomStartPoint].position;
        targetWayPoint = waypoints[0];
        NMA.SetDestination(targetWayPoint.position);
        SubmarineManager.Instance.allEnemies.Add(this.gameObject.transform);
    }
    public override void OnEnter()
    {

    }
    public override void OnUpdate()
    {
        //Debug.Log(enemyDist);
        //Debug.Log(playerDist);
        enemyDist = Vector3.Distance(transform.position, targetWayPoint.position);
        playerDist = Vector3.Distance(transform.position, submarine.transform.position);

        if (enemyDist < destinationReachedTreshold) 
        {
            wayPointReached = true;
        }

        if (wayPointReached) 
        {
            StartCoroutine(switchWayPoints());
            wayPointReached = false;
        }
        else if (playerDist < attackRange)
        {
            owner.SwitchState(typeof(AttackState));
        }
    }

    public override void OnExit()
    {

    }

    IEnumerator switchWayPoints()
    {
        currentWayPointIndex = (currentWayPointIndex + 1) % waypoints.Count;
        targetWayPoint = waypoints[currentWayPointIndex];
        NMA.SetDestination(targetWayPoint.position);
        wayPointReached = false;
        yield return new WaitForEndOfFrame();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Torpedo")
        {
            owner.SwitchState(typeof(FearState));
        }
    }
}

