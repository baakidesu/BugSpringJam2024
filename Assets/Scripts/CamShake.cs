using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CamShake : MonoBehaviour
{
    public static CamShake Instance {get; private set;}
    
    public float shakeDuration = 0.2f;
    public float shakeIntensity = 0.1f;

    private Vector3 initialPosition;
    private float currentShakeDuration = 0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            initialPosition = transform.position;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if ( currentShakeDuration > 0)
        {
            Vector3 randomOffset = Random.insideUnitCircle * shakeIntensity;
            transform.position = initialPosition + randomOffset;

            currentShakeDuration -= Time.deltaTime;
            Debug.Log(currentShakeDuration);
        }
        else
        {
            transform.position = initialPosition;
        }
    }

    public void Shake()
    {
        currentShakeDuration = shakeDuration;
        Debug.Log("Done" + currentShakeDuration);
    }
}
