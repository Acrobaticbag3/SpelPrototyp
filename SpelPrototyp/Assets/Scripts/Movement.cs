using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Movement : MonoBehaviour {
 
    private Rigidbody body;          // The Rigidbody attached to the GameObject.

    public float speed;              // Speed scale for the velocity of the Rigidbody.
    public float rotationSpeed;      // Rotation Speed scale for turning.
 
    private float vertical;          // The vertical input from input devices.
    private float horizontal;       // The horizontal input from input devices

    void Start() {
        body = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        Vector3 velocity = (transform.forward * vertical) * speed * Time.fixedDeltaTime;
        velocity.y = body.velocity.y;
        body.velocity = velocity;
        transform.Rotate((transform.up * horizontal) * rotationSpeed * Time.fixedDeltaTime);
    }
}