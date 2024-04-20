using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static Vector3 lastBulletPosition;
    public float maxDistance = 10f;
    private Rigidbody rb;

    private float travelled;

    public float rotateSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        travelled += Gun.bulletSpeed * Time.deltaTime;
        if (travelled >= maxDistance)
        {
            Destroy(gameObject);
        }

        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other);
        lastBulletPosition = transform.position;
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
