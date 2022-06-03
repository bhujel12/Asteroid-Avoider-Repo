using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float forceMagnitude;
    [SerializeField] private float maximumVelocity;

    
    public Rigidbody rb;
    public Camera mainCamera;

    private Vector3 movementDirection;
    
    void Start()
    {
        rb.GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }


    void Update()
    {
        if(Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);

            movementDirection = transform.position - worldPosition;
            movementDirection.z = 0f;
            // Normalize so that distance from finger doesnt affect the force
            movementDirection.Normalize();
        }
        else
        {
            movementDirection = Vector3.zero;
        }
    }

    void FixedUpdate()
    {
        if(movementDirection == Vector3.zero) { return; }
        // deltaTime not required for this one since it'x fixed update
        rb.AddForce(movementDirection * forceMagnitude / 50, ForceMode.Force);

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maximumVelocity);
    }
}
