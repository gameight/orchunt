using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SoundManager.PlaySound("MenuBackground"); 
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("SaveSystem").GetComponent<SaveSystem>().loaded && Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene("GameOverTest");
        }

    }
}
