using UnityEngine;

public class SkillsMenuConroller : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        		
	}

    public GameObject SkillsMenu;
    
    public void OnButtonClick()
    {
        SkillsMenu.SetActive(true);
    }
}
