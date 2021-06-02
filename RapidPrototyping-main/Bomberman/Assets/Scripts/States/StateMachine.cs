using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class StateMachine : MonoBehaviour
{
    public State currentState { get; private set; }
    [SerializeField] private string currentStateName;
    [SerializeField] private List<State> states = new List<State>();
    private Dictionary<string, State> statesDictionary = new Dictionary<string, State>();
    // Start is called before the first frame update
    void Start()
    {
        foreach(var state in states)
        {
            statesDictionary.Add(state.Name, state);
        }
        SwitchState(currentStateName);
    }

    // Update is called once per frame
    void Update()
    {
        currentState?.OnUpdate?.Invoke();
    }

    public void SwitchState(string newStateName)
    {
        if (statesDictionary.ContainsKey(newStateName))
        {
            currentState?.OnExit?.Invoke();
            currentState = statesDictionary[newStateName];
            currentStateName = newStateName;
            currentState.OnEnter?.Invoke();
        }
    }
}

[System.Serializable]
public class State
{
    public string Name;
    public UnityEvent OnEnter;
    public UnityEvent OnUpdate;
    public UnityEvent OnExit;
}