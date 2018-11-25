using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileButtonsScript : MonoBehaviour {
    
    public static bool buttonClick = false;
    //public Animator animator;

    public void leftButtonClicked()
    {
        Debug.Log("left");
        buttonClick = true;
        PlayerMovement.horizontalMove = -40f;
    }

    public void rightButtonClicked()
    {
        Debug.Log("right");
        buttonClick = true;
        PlayerMovement.horizontalMove = 40f;
    }

    public void buttonRelease()
    {
        Debug.Log("button release");
        buttonClick = false;
        PlayerMovement.horizontalMove = 0f;
    }

    public void jumpButton()
    {
        Debug.Log("jump");
        PlayerMovement.jump = true;
    }

    public void Update()
    {
        //animator.SetFloat("Speed", Mathf.Abs(PlayerMovement.horizontalMove));
    }
}
