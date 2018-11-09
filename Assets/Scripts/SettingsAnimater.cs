using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsAnimater : MonoBehaviour {
    public Animator animator;
    public GameObject SettingMenus;
   

    public void DisableAnimation(Animator ani)

    {
        ani.SetBool("isDisplayed", false);

    }
    public void EnableAnimation(Animator ani)

    {
        ani.SetBool("isDisplayed", true);

    }
}
