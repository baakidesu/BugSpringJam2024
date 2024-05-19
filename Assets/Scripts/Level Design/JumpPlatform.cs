using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour
{
    public GameObject playerRigidbody;
    private Rigidbody rigidbody;
    public float jumpStrength;
    
    private void Awake()
    {
        rigidbody = playerRigidbody.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        rigidbody.AddForce(Vector3.up * 100 * jumpStrength);

    }
}
