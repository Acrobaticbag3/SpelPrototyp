using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

    public Transform player;
    private float mouseSensitivity = 100.0f;

    private float yAxisRotation = 0.0f; // rotation around the up/y axis
    private float xAxisRotation = 0.0f; // rotation around the right/x axis
    
    void Start () {
        Cursor.visible = false;
        Vector3 rot = transform.localRotation.eulerAngles;
        yAxisRotation = rot.y;
        xAxisRotation = rot.x;
    }

    void Update () {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        yAxisRotation += mouseX * mouseSensitivity * Time.deltaTime;
        xAxisRotation += mouseY * mouseSensitivity * Time.deltaTime;

        Quaternion localRotation = Quaternion.Euler(xAxisRotation, yAxisRotation, 0.0f);
        transform.rotation = localRotation;


        Quaternion pLocalRotation = Quaternion.Euler(0.0f, yAxisRotation, 0.0f);
        player.rotation = pLocalRotation;
    }
}
