/*  
    === === === === === === === === === === === ===

    This script was made by kevin.
    
    As the name states, this script takes care of
    "most" camera related behaviours.

    === === === === === === === === === === === ===
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    #region [Veriables]

    private float mouseSensitivity = 30.0f;

    // Camera variables \\
    private float clampAngle = 20.0f;
    private float yAxisRot = 0.0f;      // rotation around the up/y axis
    private float xAxisRot = 0.0f;      // rotation around the right/x axis
    private float turnSpeed = 5.0f;

    public Transform target;
    private float targetDistance = 2.5f;

    private float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    #endregion

    void Start () {
        #region [Start Check]

        Vector3 rot = transform.localRotation.eulerAngles;
        yAxisRot = rot.y;
        xAxisRot = rot.x;
        Cursor.visible = false;

        #endregion
    }

    void Update () {
        #region [Body]

        float mouseAxisX = Input.GetAxis(axisName: "Mouse X") * turnSpeed;      // Turn camera in the appropiate axis
        float mouseAxisY = -Input.GetAxis(axisName: "Mouse Y") * turnSpeed;     // Turn camera in the appropiate axis

        yAxisRot += mouseAxisX * mouseSensitivity * Time.fixedDeltaTime;
        xAxisRot += mouseAxisY * mouseSensitivity * Time.fixedDeltaTime;

        xAxisRot = Mathf.Clamp(value: xAxisRot, min: -clampAngle, max: clampAngle * 3);

        transform.eulerAngles = new Vector3(-mouseAxisX, transform.eulerAngles.y + mouseAxisY, 0);

        Quaternion localRotation = Quaternion.Euler(x: xAxisRot, y: yAxisRot, z: 0.0f);
        transform.rotation = localRotation;

        transform.position = target.transform.position - (transform.forward * targetDistance);    // Make sure that the camera is in the right position

        #endregion
    }
}