using UnityEngine;
using UnityEngine.Events;

public class TriggerAction : MonoBehaviour, ITriggerable
{
    public UnityEvent OnTriggerEvent;
    public void OnTrigger()
    {
        OnTriggerEvent?.Invoke();
    }
}
