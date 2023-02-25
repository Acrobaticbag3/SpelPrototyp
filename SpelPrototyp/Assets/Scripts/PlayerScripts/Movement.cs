/*
    This Script was written by Kevin Johansson.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Movement : MonoBehaviour {
    private Rigidbody rb;
    public Transform transform;
    public Camera camera;

    public float speed = 4f;
    public float sprintSpeed = 9f;

    public float jumpHeight = 1;
    public float gravityScale = 10;
    public float fallingGravityScale = 40;

    private float vertical;
    private float horizontal;

    public CapsuleCollider col;

    void Start() {
        camera.fieldOfView = 80;
        rb = GetComponent<Rigidbody>(); 
    }  

    void Update() {                                                     // Jumping.
        if(Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0) {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }

    void FixedUpdate() {
        
        float verticalPlayerInput = Input.GetAxisRaw(axisName: "Vertical");             // Gets vertical input.
        float horizontalPlayerInput = Input.GetAxisRaw(axisName: "Horizontal");         // Gets horizontal input.

        Vector3 forward = transform.InverseTransformVector (vector: Camera.main.transform.forward);
        Vector3 right = transform.InverseTransformVector (vector: Camera.main.transform.right);

        forward.y = 0;
        right.y = 0;

        forward = forward.normalized;
        right = right.normalized;

        float speed = this.speed;
        Vector3 forwardRelativeVerticalInput = verticalPlayerInput * forward * Time.fixedDeltaTime;         // Fixes relative movment for vertical movment.
        Vector3 rightRelativeHorizontalInput = horizontalPlayerInput * right * Time.fixedDeltaTime;         // Fixes relative movment for horizontal movment.

        Vector3 cameraRelativeMovement = forwardRelativeVerticalInput + rightRelativeHorizontalInput;
        if(Input.GetKey(key: KeyCode.LeftShift)) { // Sprinting.
            speed = sprintSpeed;
            camera.fieldOfView = 90;  

        } else {
            camera.fieldOfView = 80;  
        }

        transform.Translate(translation: cameraRelativeMovement * speed, relativeTo: Space.World);

        if(Input.GetButton("Crouch")) {
            col.height = Mathf.Max(0.6f, col.height - Time.deltaTime * 10.0f); 
        } else {
            col.height = Mathf.Min(1.8f, col.height + Time.deltaTime * 10.0f);
        }
    }
}