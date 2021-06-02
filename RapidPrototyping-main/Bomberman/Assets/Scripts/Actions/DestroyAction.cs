using UnityEngine;
using UnityEngine.Events;

public class DestroyAction : MonoBehaviour
{
    public UnityEvent OnDestroyEvent;

    public void DestroyObject()
    {
        OnDestroyEvent?.Invoke();
        Destroy(gameObject);
    }
}
