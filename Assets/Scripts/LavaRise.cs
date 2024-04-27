using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRise : MonoBehaviour
{
    public float riseSpeed = 10f;

    private void Update()
    {
        transform.Translate(0,riseSpeed * Time.deltaTime, 0);
    }
}
