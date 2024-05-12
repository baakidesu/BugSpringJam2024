using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgainScript : MonoBehaviour
{

    public TryAgain scriptableObject;
    private void Start()
    {
        scriptableObject.previousScene = SceneManager.GetActiveScene().buildIndex;
    }
}
