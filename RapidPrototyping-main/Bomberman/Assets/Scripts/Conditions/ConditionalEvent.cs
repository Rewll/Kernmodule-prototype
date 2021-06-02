using UnityEngine;
using UnityEngine.Events;
using System.Linq;
[System.Serializable]
public class ConditionalEvent : MonoBehaviour
{
    public UnityEvent OnConditionSuccess;
    public Condition[] conditions;
    public void Evaluate()
    {
        if(conditions.All(x => x.Evaluate(gameObject)))
        {
            OnConditionSuccess?.Invoke();
        }
    }
}
