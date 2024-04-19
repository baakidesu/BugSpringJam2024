using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Narrative : MonoBehaviour
{
    private float currentTime;

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= 10f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
