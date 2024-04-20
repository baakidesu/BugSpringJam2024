using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static Vector3 lastBulletPosition;
    public float maxDistance = 10f;

    private float travelled;

    private void Update()
    {
        travelled += Gun.bulletSpeed * Time.deltaTime;
        if (travelled >= maxDistance)
        {
            Destroy(gameObject);
        }

     
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
