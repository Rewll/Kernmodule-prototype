using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submarine : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speedModifier;   
    [SerializeField] float submarineSpeed = 0;
    [SerializeField] float submarineStartSpeed = .5f;
    [SerializeField] float divingSpeed;
    [SerializeField] float steeringAmount;
    [SerializeField] float rotationSpeed;
    Rigidbody submarineRB;

    private void Start()
    {
        submarineRB = GetComponent<Rigidbody>();
        submarineSpeed = submarineStartSpeed;
        //submarineRB.velocity = new Vector3(submarineRB.velocity.x, submarineRB.velocity.y, submarineSpeed);
    }
    private void Update()
    {
        transform.Translate(Vector3.up * submarineSpeed *  Time.deltaTime);
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

    public void anchor()
    {
        Debug.Log("ANCHOR BEING DROPPED");
    }


    public void sendSonar()
    {
        Debug.Log("SONAR BEING SEND");
    }

    public void boostSubmarine()
    {
        Debug.Log("SUBMARINE BEING BOOSTED");
    }

    public void Dive()
    {
        Debug.Log("SUBMARINE IS DIVING");
        submarineRB.AddForce(new Vector3(0, -divingSpeed, 0), ForceMode.Impulse);
    }

    public void Upturn()
    {
        Debug.Log("SUBMARINE IS UPTURNING");
        submarineRB.AddForce(new Vector3(0, divingSpeed, 0), ForceMode.Impulse);
    }

    public void moveRight()
    {
        Debug.Log("SUBMARINE GOING RIGHT");
        transform.Rotate(0, 0, -steeringAmount);
    }

    public void moveLeft()
    {
        Debug.Log("SUBMARINE GOING Left");
        transform.Rotate(0, 0, steeringAmount);
    }



}