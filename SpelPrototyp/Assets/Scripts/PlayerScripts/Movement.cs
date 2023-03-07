using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {
    private Rigidbody rb;
    public Transform target;
    public Camera camera;

    // Ground movement \\
    private float speed = 200f;
    private float sprintSpeed = 400f;

    // Stammina and stammina regen \\
    private float currentStamina = 100;
    [SerializeField] private RawImage staminaBar;
    
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
        rb = GetComponent<Rigidbody>();
        camera.fieldOfView = 80;
    }

    void Update() {   
        // Everything after this code stops when paused 
        // if code wants to be run even if pasued put before
        if (GameManager.isPaused || GameManager.swtichingSpells) {
            return;
        } 
        
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0 && currentStamina != 0) {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            currentStamina = currentStamina - 20;
        }
    }

    void FixedUpdate() {

        float verticalPlayerInput = Input.GetAxisRaw(axisName: "Vertical");             // Gets vertical input.
        float horizontalPlayerInput = Input.GetAxisRaw(axisName: "Horizontal");         // Gets horizontal input.

        Vector3 forward = transform.InverseTransformVector(vector: Camera.main.transform.forward);
        Vector3 right = transform.InverseTransformVector(vector: Camera.main.transform.right);

        forward.y = 0;
        right.y = 0;

        forward = forward.normalized;
        right = right.normalized;

        float speed = this.speed;
        Vector3 forwardRelativeVerticalInput = verticalPlayerInput * -transform.forward * Time.fixedDeltaTime;         // Fixes relative movment for vertical movment. Note -transform is a temp fix
        Vector3 rightRelativeHorizontalInput = horizontalPlayerInput * -transform.right * Time.fixedDeltaTime;         // Fixes relative movment for horizontal movment. Note -transform is a temp fix

        Vector3 cameraRelativeMovement = forwardRelativeVerticalInput + rightRelativeHorizontalInput;
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z); 
        transform.LookAt(targetPosition);

        if (Input.GetKey(key: KeyCode.LeftShift) && currentStamina != 0) {
            speed = sprintSpeed;
            camera.fieldOfView = 90;
            currentStamina = currentStamina - 3;
        }
        else {
            currentStamina++;
            camera.fieldOfView = 80;
        }

        transform.Translate(translation: cameraRelativeMovement * speed * Time.deltaTime, relativeTo: Space.World);

        if (Input.GetButton("Crouch")) {
            col.height = Mathf.Max(0.6f, col.height - Time.deltaTime * 10.0f);
        }
        else {
            col.height = Mathf.Min(1.8f, col.height + Time.deltaTime * 10.0f);
        }
    }
}