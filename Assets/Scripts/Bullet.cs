using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static Vector3 lastBulletPosition;

    private void OnCollisionEnter(Collision other)
    {
        lastBulletPosition = transform.position;
        Destroy(gameObject);
    }
}
