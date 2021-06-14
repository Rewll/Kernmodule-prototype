using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SubmarineManager : MonoBehaviour
{
    [SerializeField]
    bool test;

    public void testVoid()
    {
        Debug.Log("TestVoid");
        test = true;
    }


}
