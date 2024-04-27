using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kill : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag);
        
       if (other.tag == "Player")
        {
            SceneManager.LoadScene(2);
        }
    }



}
