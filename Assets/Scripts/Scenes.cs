using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public GameObject panel;
    public GameObject mainMenu;
  public void PlayGame()
  {
      SceneManager.LoadScene(1);
  }

  public void Exit()
  {
      Application.Quit();
  }

  public void ForcePlay()
  {
      SceneManager.LoadScene(3);
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
}
