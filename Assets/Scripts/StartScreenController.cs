﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenController : MonoBehaviour {



	// Use this for initialization
	void Start () {
     
		
	}
	
	// Update is called once per frame
    void Update () {
        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            SoundManager.PlaySound("Start");
        }
      
        if (GameObject.Find("SaveSystem").GetComponent<SaveSystem>().loaded && Input.GetMouseButtonDown(0)) {
         
            SceneManager.LoadScene("MapScene");
        }

    }
}
