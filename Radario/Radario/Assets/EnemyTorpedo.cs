using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTorpedo : MonoBehaviour
{
    [SerializeField] Transform targetEnemy;
    [SerializeField] float torpedoSpeed;
    [SerializeField] float torpedoHitRange;
    [SerializeField] bool enemyCloseOrNot;

    private void Start()
    {
        targetEnemy = GameObject.FindGameObjectWithTag("Submarine").transform;



        Debug.Log(Vector3.Distance(transform.position, targetEnemy.position));
        if (Vector3.Distance(transform.position, targetEnemy.position) < torpedoHitRange)
        {
            enemyCloseOrNot = true;
        }
        else
        {
            enemyCloseOrNot = false;
        }
    }

    private void FixedUpdate()
    {
        if (enemyCloseOrNot)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetEnemy.position, torpedoSpeed * Time.deltaTime);
        }
        else if (!enemyCloseOrNot)
        {
            transform.position += transform.TransformDirection(Vector3.up) * torpedoSpeed * 0.2f;
        }
    }


}
