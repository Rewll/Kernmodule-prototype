using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimedAction : MonoBehaviour
{
    public UnityEvent OnTimerStarted;
    public UnityEvent OnTimerFinished;
    [SerializeField] private float autoStartDuration = 1f;
    [SerializeField] private bool SetTimerOnStart = false;

    private void Start()
    {
        if (SetTimerOnStart)
        {
            SetTimer(autoStartDuration);
        }
    }

    public void SetTimer(float duration)
    {
        StopAllCoroutines();
        StartCoroutine(TimedActionRoutine(duration));
    }

    IEnumerator TimedActionRoutine(float duration)
    {
        OnTimerStarted?.Invoke();
        yield return new WaitForSeconds(duration);
        OnTimerFinished?.Invoke();
    }
}
