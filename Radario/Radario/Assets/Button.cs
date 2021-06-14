using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    enum buttons {Torpedo};
    [SerializeField]
    buttons buttonType;

    [SerializeField]
    public bool isPressed;
    public UnityEvent buttonPressed;

    // Update is called once per frame
    void Update()
    {

    }
}