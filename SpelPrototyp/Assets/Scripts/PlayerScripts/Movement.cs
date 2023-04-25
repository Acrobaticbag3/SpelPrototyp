/*  
    === === === === === === === === === === === ===

    This script was made by kevin.
    
    This script handles all movement related stuff
    for the player itself.

    === === === === === === === === === === === ===
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static PlayerStamina;

public class Movement : MonoBehaviour {
    private Rigidbody rb;
    [SerializeField] private Camera camera;

    // Ground movement \\
    private float _speed = 200f;
    private float sprintSpeed = 400f;
    
    // Jumping and gravity \\
    public float jumpHeight = 1;
    public float gravityScale = 10;
    public float fallingGravityScale = 40;

    // Axis for movement \\
    private float vertical;
    private float horizontal;

    // References \\ 
    private Task task;
    public Task Task => task;
    PlayerStamina playerStamina;

    // Collider \\
    [SerializeField] private CapsuleCollider col;

    void Start() {
        rb = GetComponent<Rigidbody>();
        camera.fieldOfView = 90;

        GameObject player = GameObject.Find("Player");
        playerStamina = player.GetComponent<PlayerStamina>();
    }

    void Update() {   
        // Everything after this code stops when paused 
        // if code wants to be run even if pasued put before
        if (GameManager.isPaused || GameManager.swtichingSpells) {
            return;
        } 
        
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y >= 0.1f && playerStamina.SuffitiantStamina) {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            task = PlayerStamina.Task.jumping;
        }
    } 

    void FixedUpdate() {
        // Everything after this code stops when paused 
        // if code wants to be run even if pasued put before
        if (GameManager.isPaused || GameManager.swtichingSpells) {
            return;
        } 
        float verticalPlayerInput = Input.GetAxisRaw(axisName: "Vertical");             // Gets vertical input.
        float horizontalPlayerInput = Input.GetAxisRaw(axisName: "Horizontal");         // Gets horizontal input.

        float speed = this._speed;
        Vector3 forwardRelativeVerticalInput = verticalPlayerInput * transform.forward * Time.fixedDeltaTime;         // Fixes relative movement for vertical movement. Note -transform is a temp fix
        Vector3 rightRelativeHorizontalInput = horizontalPlayerInput * transform.right * Time.fixedDeltaTime;         // Fixes relative movement for horizontal movement. Note -transform is a temp fix

        Vector3 cameraRelativeMovement = forwardRelativeVerticalInput + rightRelativeHorizontalInput;                           
        Vector3 targetPosition = new Vector3(camera.transform.position.x, 1, camera.transform.position.z);  
        transform.rotation = Quaternion.LookRotation(transform.position - targetPosition); 
        var rot = transform.eulerAngles;
        rot.x = 0;
        transform.eulerAngles = rot;                      // Make the player look in the direction that the camera is faceing.

        if (Input.GetKey(key: KeyCode.LeftShift) && playerStamina.SuffitiantStamina) {
            speed = sprintSpeed;
            Debug.Log("Sprinting!");
            camera.fieldOfView = 100;
            task = PlayerStamina.Task.running;
        }
        else {
            camera.fieldOfView = 90;
            task = PlayerStamina.Task.standing;
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