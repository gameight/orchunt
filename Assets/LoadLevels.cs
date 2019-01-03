using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadLevels : MonoBehaviour {

    void Start()
    {
        addPhysics2DRaycaster();
    }

    void addPhysics2DRaycaster()
    {
        Physics2DRaycaster physicsRaycaster = GameObject.FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
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
