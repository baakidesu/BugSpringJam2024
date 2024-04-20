using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
   private Rigidbody rb;
   public float forceX, forceZ;

   private void Awake()
   {
      rb = gameObject.GetComponent<Rigidbody>();
   }

   private void Start()
   {
      rb.AddForce(new Vector3(forceX,0, forceZ), ForceMode.Impulse);
   }
}
