using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;
	[HideInInspector] public float runSpeed = 20f;

	public static float horizontalMove = 0f;
	public static bool jump = false;
    bool IsAlive = true;

    // Update is called once per frame
    private void Update ()
    {
        if (!MobileButtonsScript.buttonClick)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        }           

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}

        /**
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("IsCasting", true);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("IsCasting", false);
        }
        */
    }

	public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
        //Debug.Log("Landing");
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
        //Debug.Log(jump);
    }


  
}
