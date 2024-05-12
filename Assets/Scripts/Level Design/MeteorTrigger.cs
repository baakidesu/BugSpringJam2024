using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeteorTrigger : MonoBehaviour
{
    public GameObject meteor;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            meteor.SetActive(true);
        }
    }
  

}
