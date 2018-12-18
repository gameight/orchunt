using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public static float speed;
    public float stoppingDistance;
    bool facingRight = true;
    private Transform target;
    private Transform enemy;
    public Animator animator;
    public static float horizontalMove = 0f;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
    }
    private void Update()
    {
        if (!MobileButtonsScript.buttonClick)
            horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        //if (Input.GetButtonDown("Jump"))
        //{
        //    jump = true;
        //    animator.SetBool("IsJumping", true);
        //}

        //if (Input.GetButtonDown("Fire1"))
        //{
        //    animator.SetBool("IsCasting", true);
        //}

        //if (Input.GetButtonUp("Fire1"))
        //{
        //    animator.SetBool("IsCasting", false);
        //}
    }

    //public void OnLanding()
    //{
    //    animator.SetBool("IsJumping", false);
    //    //Debug.Log("Landing");
    //}


    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.position) > 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        }
        if (target.position.x > enemy.position.x && facingRight)
        {
            Flip();
        }
        if (target.position.x < enemy.position.x && !facingRight)
        {
            Flip_Other();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void Flip_Other()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

   
}
