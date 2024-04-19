using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Range(5, 50)] public float sens;

    public Transform body;

    private float xRot = 0f;
    void Start()
    {
         Cursor.lockState = CursorLockMode.Locked;
         Cursor.visible = false;
    }

    void Update()
    {
        float rotX = Input.GetAxis("Mouse X") * sens;
        float rotY = Input.GetAxis("Mouse Y") * sens;

        xRot -= rotY;
        xRot = Mathf.Clamp(xRot, -80f, 80f);
        
        transform.localRotation = Quaternion.Euler(xRot,0f,0f); 

        body.Rotate(Vector3.up * rotX);
    }
}
