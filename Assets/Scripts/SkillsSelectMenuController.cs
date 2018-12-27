using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsSelectMenuController : MonoBehaviour {


    private Animator animator;

    private List<GameObject> selectedSkills;

    private Color32 oldColor = new Color32(0,252,255,255);
    private Color32 newColor = new Color32(255, 91, 0, 255);


    // Use this for initialization
    void Start () {

        animator = GameObject.Find("SkillsMenu").GetComponent<Animator>();
        selectedSkills = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   
    

    public void skillButtonClicked(GameObject gameObject)
    {
        
        Image SkillImage = gameObject.transform.Find("Mask").GetChild(0).GetComponent<Image>();

        checkTheList(gameObject);
        
    }
    
    public void AcceptButtonClicked() {

        Image selected1 = GameObject.Find("selectedSkillImage1").GetComponent<Image>();
        Image selected2 = GameObject.Find("selectedSkillImage2").GetComponent<Image>();

        if (selectedSkills.Count == 2)
        {
            selected1.sprite = selectedSkills[0].transform.Find("Mask").GetChild(0).GetComponent<Image>().sprite;
            selected2.sprite = selectedSkills[1].transform.Find("Mask").GetChild(0).GetComponent<Image>().sprite;
        }

        closeSkillMenu();
        
    }

    public void closeSkillMenu()
    {
        animator.SetBool("isOpen", false);
    }

    public void checkTheList(GameObject gameObject)
    {
        

        if (!selectedSkills.Contains(gameObject))
        {
            selectedSkills.Add(gameObject);
            gameObject.GetComponent<Image>().color = newColor;

            if(selectedSkills.Count > 2)
            {
                selectedSkills[0].GetComponent<Image>().color = oldColor;
                selectedSkills.Remove(selectedSkills[0]);
                
            }
            
        }
        else
        {
            selectedSkills.Remove(gameObject);
            gameObject.GetComponent<Image>().color = oldColor;
            

        }

    }

   

}
