using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevels : MonoBehaviour {



    void Start()

    {
        Debug.Log(PlayerData.Instance.Level);
        switch (PlayerData.Instance.Level)
        {
            case 1:
                GameObject.Find("MapButton2").GetComponent<Button>().interactable = false;
                GameObject.Find("MapButton3").GetComponent<Button>().interactable = false;
                GameObject.Find("MapButton4").GetComponent<Button>().interactable = false;
                break;

            case 2:
              
                GameObject.Find("MapButton3").GetComponent<Button>().interactable = false;
                GameObject.Find("MapButton4").GetComponent<Button>().interactable = false;
                break;
            case 3:
                
                GameObject.Find("MapButton4").GetComponent<Button>().interactable = false;
                break;
        }



    }

  
	
	// Update is called once per frame
	void Update () {
		
	}

    [SerializeField]
    public void LoadLevel(int levelID){

        if (PlayerData.Instance.Level >= levelID)
        {
            SoundManager.PlaySound("LevelBackground");


            SceneManager.LoadSceneAsync("Level" + levelID);   
        }

             
    }

}
