using UnityEngine;

public class RaycastTriggers : MonoBehaviour
{
    [SerializeField] private float distance = 1f;
    [SerializeField] private LayerMask overlapLayer;
    [SerializeField] private Transform[] raycastTransforms;

    public void DoRaycastAction()
    {
        foreach (Transform rayCastTransform in raycastTransforms)
        {
            if(Physics.Raycast(rayCastTransform.position, rayCastTransform.forward, out RaycastHit hit, distance, overlapLayer))
            {
                var trigger = hit.collider.GetComponent<ITriggerable>();
                trigger?.OnTrigger();
            }

        }
    } 

    private void OnDrawGizmos()
    {
        if(raycastTransforms == null || raycastTransforms.Length == 0) { return; }
        foreach(Transform t in raycastTransforms)
        {
            Gizmos.DrawLine(t.position, t.position + t.forward * distance);
        }
    }
}
