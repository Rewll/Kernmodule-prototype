using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BlackBoard))]
public class Damageable : MonoBehaviour
{
    private FloatVariable HealthVariable;
    private void Start()
    {
        HealthVariable = GetComponent<BlackBoard>().GetValueByName("Health");
    }

    public void OnTakeDamage(float damage)
    {
        HealthVariable?.AddValue(-damage);
        Debug.Log("health is: " + HealthVariable.Value);
    }

}
