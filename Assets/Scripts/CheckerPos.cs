using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerPos : MonoBehaviour
{
    public Transform handPos; // Takip edilecek objenin Transform bileşeni

    private Vector3 offset; // İki obje arasındaki başlangıç farkı

    void Start()
    {
        // İki obje arasındaki başlangıç farkını hesapla
        if (handPos != null)
        {
            offset = transform.position - handPos.position;
        }
    }

    void Update()
    {
        // Takip edilecek objenin varlığını kontrol et
        if (handPos != null)
        {
            // Takip edilen objenin pozisyonunu al, offset değeri ile kendi pozisyonunu ayarla
            transform.position = handPos.position + offset;
        }
    }
}
