using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : BaseState
{
    public NavMeshAgent NMA;
    [SerializeField] GameObject enemyTorpedoPrefab;


    public override void OnEnter()
    {
        NMA = GetComponent<NavMeshAgent>();
        NMA.isStopped = true;
        NMA.ResetPath();
        StartCoroutine(fireTorpedo());
    }

    public override void OnExit()
    {
    }

    public override void OnUpdate()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Torpedo")
        {
            owner.SwitchState(typeof(FearState));
        }
    }

    IEnumerator fireTorpedo()
    {
        Instantiate(enemyTorpedoPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);
        owner.SwitchState(typeof(PatrolState));
    }
}
