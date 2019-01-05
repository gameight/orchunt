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
        SaveSystem.playerData.remainingLive = 3;
        SaveSystem.playerData.level = 1;
        SaveSystem.playerData.activeSpells[0] = "Light";
        SaveSystem.playerData.activeSpells[1] = "Cosmic";
        SaveSystem.playerData.earnedSpells = new List<bool>() { true, true, false, false, false, false, false, false };
        SaveSystem.Save();
        SceneManager.LoadScene("MapScene"); 

    }


}