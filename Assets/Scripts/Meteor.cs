using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meteor : MonoBehaviour
{
   private Rigidbody rb;
   public float forceX, forceZ;

   public GameObject player; 

   private void Awake()
   {
      rb = gameObject.GetComponent<Rigidbody>();
   }

   private void Start()
   {
      rb.AddForce(new Vector3(0,forceX,forceZ), ForceMode.Impulse);
   }
   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Player")
      {
         SceneManager.LoadScene(2);
      }
   }
}
