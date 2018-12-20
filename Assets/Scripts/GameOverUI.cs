using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverUI : MonoBehaviour
{

    public void Quit()
    {
        Debug.Log("Application Quit");
        Application.Quit();

    }
    public void Retry()
    {
      
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 

    }


}