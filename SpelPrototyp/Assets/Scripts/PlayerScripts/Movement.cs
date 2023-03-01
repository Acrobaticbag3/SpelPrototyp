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

    // Ground movement \\
    public float speed = 200f;
    public float sprintSpeed = 300f;
    private float stamina = 100;

    // Jumping and gravity \\
    public float jumpHeight = 1;
    public float gravityScale = 10;
    public float fallingGravityScale = 40;

    // Axis for movement \\
    private float vertical;
    private float horizontal;

    // Colider \\
    public CapsuleCollider col;

    void Start() {
        camera.fieldOfView = 80;
        rb = GetComponent<Rigidbody>(); 
    }  

    void Update() { // Jumping.
        if(GameManager.isPaused == false | GameManager.swtichingSpells == false)
        {
            if(Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0 && stamina != 0) {
                rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                stamina = stamina - 20;
            }
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
        
        if (Input.GetKey(key: KeyCode.LeftShift) && stamina != 0) {
            speed = sprintSpeed;
            camera.fieldOfView = 90; 
            stamina = stamina - 3;

        } else {
            stamina++;
            camera.fieldOfView = 80;  
        }

        transform.Translate(translation: cameraRelativeMovement * speed * Time.deltaTime, relativeTo: Space.World);

        if(Input.GetButton("Crouch")) {
            col.height = Mathf.Max(0.6f, col.height - Time.deltaTime * 10.0f); 
        } else {
            col.height = Mathf.Min(1.8f, col.height + Time.deltaTime * 10.0f);
        }
    }
}