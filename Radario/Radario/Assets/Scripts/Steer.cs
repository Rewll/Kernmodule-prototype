using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steer : MonoBehaviour
{

    public LayerMask steerLayer;
    private Vector3 targetPos;
    private Vector3 centerPos;

    private Vector3 startDir;
    private Vector3 endDir;
    [SerializeField] GameObject Submarine;
    [SerializeField] float rotationOffset;
    public float rayCastLength = 100;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (DoRayCast(out targetPos))
            {
                endDir = targetPos - transform.position;
                float DeltaAngle = Vector3.SignedAngle(startDir, endDir, transform.up);
                transform.Rotate(transform.forward, -DeltaAngle, Space.World);
                Submarine.transform.Rotate(Submarine.transform.up, -DeltaAngle * rotationOffset, Space.Self);
                startDir = endDir;
            }
        }
    }

    private bool DoRayCast(out Vector3 hitPosition)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction);
        if (Physics.Raycast(ray, out hit, rayCastLength, steerLayer))
        {
            Debug.Log("Hit something!");
            hitPosition = hit.point;
            return true;
        }
        hitPosition = Vector3.zero;
        return false;
    }
}