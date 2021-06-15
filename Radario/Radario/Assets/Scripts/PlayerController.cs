using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [Header("PlayerLook")]
    public Transform kamera;
    public float mouseSens = 10f;
    private float x = 0;
    private float y = 0;

    [Header("PlayerMove")]
    [SerializeField]
    float moveSpeed = 6;
    private Rigidbody rb;

    [Header("Button Interactive")]
    public float buttonRaycastLength;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        playerLook();
        playerMove();
        Debug.DrawRay(kamera.transform.position, kamera.transform.forward * buttonRaycastLength);
        if (Input.GetMouseButtonUp(0))
        {
            buttonRayCast();
        }
    }
    void playerLook()
    {
        x -= Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
        y += Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;

        x = Mathf.Clamp(x, -90, 90);

        kamera.localRotation = Quaternion.Euler(x, 0, 0);
        transform.localRotation = Quaternion.Euler(0, y, 0);
    }
    void playerMove()
    {
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        float y = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 movePos = transform.right * x + transform.forward * y;
        Vector3 NewMovePos = new Vector3(movePos.x, rb.velocity.y, movePos.z);

        rb.velocity = NewMovePos;
    }

    void buttonRayCast()
    {
        RaycastHit buttonHit;
        if (Physics.Raycast(kamera.transform.position, kamera.transform.forward, out buttonHit, buttonRaycastLength))
        {
            if (buttonHit.transform.tag == "Button")
            {
                buttonHit.transform.gameObject.GetComponentInParent<Button>()?.buttonPressed?.Invoke();
                //Debug.Log("RAAK");
            }
        }
    }
}