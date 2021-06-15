using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submarine : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speedModifier;   
    [SerializeField] float submarineSpeed = 0;
    Rigidbody submarineRB;

    private void Start()
    {
        submarineRB = GetComponent<Rigidbody>();
        submarineRB.velocity = new Vector3(submarineRB.velocity.x, submarineRB.velocity.y, submarineSpeed);
    }
    private void FixedUpdate()
    {
        submarineRB.velocity = new Vector3(submarineRB.velocity.x, submarineRB.velocity.y, submarineSpeed);
    }

    public void addSpeed()
    {
        Debug.Log("Adding speed");
        submarineSpeed += speedModifier;
        //submarineRB.velocity = new Vector3(submarineRB.velocity.x, submarineSpeed, submarineRB.velocity.z);
    }
    public void substractSpeed()
    {
        Debug.Log("Substracting speed");
        submarineSpeed -= speedModifier;
        //submarineRB.velocity = new Vector3(submarineRB.velocity.x, submarineSpeed, submarineRB.velocity.z);
    }

    public void fireTorpedo()
    {
        Debug.Log("TORPEDO BEING FIRED");
    }

    public void sendSonar()
    {
        Debug.Log("SONAR BEING SEND");
    }

    public void boostSubmarine()
    {
        Debug.Log("SUBMARINE BEING BOOSTED");
    }
}