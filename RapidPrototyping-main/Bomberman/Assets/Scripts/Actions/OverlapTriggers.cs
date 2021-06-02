using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OverlapTriggers : MonoBehaviour
{
    [SerializeField] private float radius = 1f;
    [SerializeField] private LayerMask overlapLayer;

    public UnityEvent<GameObject> OverlapEvent;
    public void DoOverlapAction()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, radius, overlapLayer);
        foreach(var c in col)
        {
            var trigger = c.GetComponent<ITriggerable>();
            if(trigger != null)
            {
                trigger.OnTrigger();
            }
        }
    }
    public void DoOverlapActionWithCallback()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, radius, overlapLayer);
        foreach (var c in col)
        {
           //var trigger = c.GetComponent<ITriggerable>();
            //if (trigger != null)
            {
                OverlapEvent?.Invoke(c.gameObject); 
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}