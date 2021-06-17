using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    private bool canBePressed = true;

    [SerializeField] GameObject buttonMesh;
    BoxCollider buttonCollider;

    public UnityEvent buttonPressed;
    private void Start()
    {
        buttonMesh = transform.GetChild(0).gameObject;
        buttonCollider = buttonMesh.GetComponent<BoxCollider>();
    }


    private void Update()
    {
        checkPressStatus();
    }

    void checkPressStatus()
    {
        if (!SubmarineManager.Instance.isExecutingMoves)
        {
            buttonCollider.enabled = true;
        }
        else if (SubmarineManager.Instance.isExecutingMoves)
        {
            buttonCollider.enabled = false;
        }
    }

}