using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadLevels : MonoBehaviour {

    void Start()
    {
    }

  
	
	// Update is called once per frame
	void Update () {
		
	}
    [SerializeField]
    public void LoadLevel(int levelID){
        
        SoundManager.PlaySound("LevelBackground");

        //SceneManager.LoadScene("Level" + levelID);
        SceneManager.LoadSceneAsync("Level" + levelID);        
    }

}
