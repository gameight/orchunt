using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadLevels : MonoBehaviour {

    void Start()
    {
        SoundManager.PlaySound("MenuBackground");
    }

  
	
	// Update is called once per frame
	void Update () {
		
	}
    [SerializeField]
    public void LoadLevel(int levelID){
        Debug.Log("hfghgfhfg");

        SceneManager.LoadScene("Level1");
        
    }

}
