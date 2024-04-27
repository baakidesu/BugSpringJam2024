using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public GameObject panel;
    public GameObject mainMenu;
    public GameObject story1;
    public GameObject story2;
    
    private float currentTime;


    private bool story2Work;

    private void Update()
    {
        currentTime += Time.deltaTime;
        //Debug.Log(currentTime);
    }

    public void PlayGame()
    { 
        currentTime = 0f;
      mainMenu.SetActive(false);
      story1.SetActive(true);
    }

  public void Exit()
  {
      Application.Quit();
  }

  public void ForcePlay()
  {
      SceneManager.LoadScene(1);
  }
 
    
  public void OpenCredit()
  {
      mainMenu.SetActive(false);
      panel.SetActive(true);
  }

  public void CloseCredit()
  {
      panel.SetActive(false);
      mainMenu.SetActive(true);
  } 
  public void storyChange()
  {
      story1.SetActive(false);
      story2.SetActive(true);
  }


}
