using UnityEngine;

public class SkillsMenuConroller : MonoBehaviour {

    public Animator animator;

    // Update is called once per frame
    void Update () {
        		
	}

    public GameObject SkillsMenu;
    
    public void OnButtonClick()
    {

        bool isSkillsMenuOpen = animator.GetBool("isDisplayed");

        Debug.Log("OnButtonClick has been called.");
        SkillsMenu.SetActive(true);

        if (isSkillsMenuOpen == false) { 
        animator.SetBool("isDisplayed", true);
            Debug.Log("isDisplayessettrue");
        } else
        {
            animator.SetBool("isDisplayed", false);
        }


    }
}
