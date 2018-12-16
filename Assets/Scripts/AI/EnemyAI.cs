using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public float walkingSpeed;
    public float runSpeed;
    public float patrolMin;
    public float patrolMax;
    public float perceptionDistance;
    public float stoppingDistance;

    [HideInInspector]
    public bool facingRight = true;

    private Vector2 playerPosition;
    private Animator animator;

    //public float speed;
    //public float stoppingDistance;

    //private Transform target;
    //private Transform enemy;

    //public static float horizontalMove = 0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;

        DetectPlayer();

        //if (!MobileButtonsScript.buttonClick)
        //    horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        //animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

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
        //if (Vector2.Distance(transform.position, target.position) > 3)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        //}
        //if (target.position.x > enemy.position.x && facingRight)
        //{
        //    Flip();
        //}
        //if (target.position.x < enemy.position.x && !facingRight)
        //{
        //    Flip_Other();
        //}
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void DetectPlayer()
    {
        if (Vector2.Distance(transform.position, playerPosition) < perceptionDistance && Vector2.Distance(transform.position, playerPosition) > stoppingDistance)
        {
            //Debug.Log("Rina Görüldü, Mesafe: " + Vector2.Distance(transform.position, playerPosition));
            animator.SetBool("IsFollowing", true);
        }
        else if (Vector2.Distance(transform.position, playerPosition) <= stoppingDistance)
        {
            animator.SetBool("IsFollowing", false);
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            //Debug.Log("Rina Görülmedi, Mesafe: " + Vector2.Distance(transform.position, playerPosition));
            animator.SetBool("IsFollowing", false);
        }
    }

    public void OrcYFix()
    {
        transform.position = new Vector2(transform.position.x, -0.05f);
    }

}