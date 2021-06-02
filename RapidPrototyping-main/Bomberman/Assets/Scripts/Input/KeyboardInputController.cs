using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyboardInputController : MonoBehaviour
{
    [SerializeField] private List<InputEvent> inputs = new List<InputEvent>();
    
    void Start()
    {
        
    }

    private void Update()
    {
        foreach(var input in inputs)
        {
            if (Input.GetKeyDown(input.key))
            {
                input.OnKeyDown?.Invoke();
            }
            if (Input.GetKey(input.key))
            {
                input.OnKey?.Invoke();
            }
            if (Input.GetKeyUp(input.key))
            {
                input.OnKeyUp?.Invoke();
            }
        }
    }
}

[System.Serializable]
public class InputEvent
{
    [SerializeField] private string name;
    public KeyCode key;
    public UnityEvent OnKeyDown;
    public UnityEvent OnKeyUp;
    public UnityEvent OnKey;
}