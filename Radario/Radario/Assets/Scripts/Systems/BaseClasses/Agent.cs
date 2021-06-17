using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    private FSM fsm;
    // Start is called before the first frame update
    void Start()
    {
        fsm = new FSM(typeof(PatrolState), GetComponents<BaseState>()); //Starting state, with getcomponentSSS because multiple states are being used
    }

    // Update is called once per frame
    void Update()
    {
        fsm.OnUpdate();
    }
}
