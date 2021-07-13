using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Submarine : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speedModifier;   
    [SerializeField] float submarineSpeed = 0;
    [SerializeField] float submarineStartSpeed = .5f;
    [SerializeField] float divingSpeed;
    [SerializeField] float steeringAmount;
    [SerializeField] float rotationSpeed;
    [SerializeField] float treasureRange;
    [SerializeField] GameObject torpedoPrefab;
    [SerializeField] GameObject torpedoPos;


    Rigidbody submarineRB;
    [SerializeField] GameObject treasure;
    [SerializeField] UnityEvent win;

    private void Start()
    {
        submarineRB = GetComponent<Rigidbody>();
        submarineSpeed = submarineStartSpeed;
        treasure = GameObject.FindWithTag("Treasure");
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
        Instantiate(torpedoPrefab, torpedoPos.transform.position, Quaternion.identity);
        //sound?
    }

    public void Grab()
    {
        Debug.Log("SUBMARINE BEING MAGNETED");
        if (Vector3.Distance(transform.position, treasure.transform.position) < treasureRange)
        {
            win.Invoke();
        }
        else
        {
            //NO WIN
        }
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