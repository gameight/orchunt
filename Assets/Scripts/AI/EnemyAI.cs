using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public float walkingSpeed = 1.5f;
    public float runSpeed = 2.5f;
    public float patrolMin = 0f;
    public float patrolMax = 5f;
    public float perceptionDistance = 10f;
    public float stoppingDistance = 3f;
    public float damage = 15f;

    [HideInInspector] public float health = 100f;
    [HideInInspector] public Vector2 startPosition;
    [HideInInspector] public bool facingRight = true;

    private Vector2 playerPosition;
    private int playerHealth;
    private Animator animator;
    private int nextUpdate = 1; // Next update in second
    private bool isAttacking = false;
    private bool isDying = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        startPosition = transform.position;

        //Invoke("Die", 5f);
    }

    private void Update()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().playerStats.Health;

        DetectPlayer();

        //Die();

        //Debug.Log("Health: " + playerHealth);

        // If the next update is reached
        if (Time.time >= nextUpdate)
        {
            //Debug.Log(Time.time + ">=" + nextUpdate);

            // Change the next update (current second + 1)
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;

            // Call your function
            if (isAttacking)
            {
                Attack();
            }
        }
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
        if (Vector2.Distance(transform.position, playerPosition) < perceptionDistance && Vector2.Distance(transform.position, playerPosition) > stoppingDistance && playerHealth > 0 && playerHealth <= 100 && !isAttacking) //Follow
        {
            //Debug.Log("Rina Görüldü, Mesafe: " + Vector2.Distance(transform.position, playerPosition));

            animator.SetBool("IsAttacking", false);
            isAttacking = false;

            animator.SetBool("IsFollowing", true);            
        }
        else if (Vector2.Distance(transform.position, playerPosition) <= stoppingDistance && playerHealth > 0 && playerHealth <= 100 && !isAttacking) // Attack
        {
            //Debug.Log("Rina'ya Saldırılıyor, Mesafe: " + Vector2.Distance(transform.position, playerPosition));

            animator.SetBool("IsFollowing", false);

            animator.SetBool("IsAttacking", true);
            isAttacking = true;
        }
        else //Idling
        {
            //Debug.Log("Rina Görülmedi, Mesafe: " + Vector2.Distance(transform.position, playerPosition));

            animator.SetBool("IsAttacking", false);
            isAttacking = false;

            animator.SetBool("IsFollowing", false);          
        }
    }

    private void Die()
    {
        health = 0f;

        if (health <= 0f && !isDying)
        {
            isDying = true;
            animator.SetBool("IsDying", true);
        }
    }

    private void Attack()
    {
        if (playerHealth > 0 && playerHealth <= 100)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().playerStats.Health -= (int)(UnityEngine.Random.Range(0.75f, 1f) * damage);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
            isAttacking = false;
        }        
    }

    public void DoPatrollingCoroutine(Animator animator, bool isPatrol)
    {
        StartCoroutine(ChangePatrolling(animator, isPatrol));
    }

    IEnumerator ChangePatrolling(Animator animator, bool isPatrol)
    {
        yield return new WaitForSeconds(4f);

        animator.SetBool("IsPatrolling", isPatrol);
    }

    public void DoDestroyEnemy()
    {
        StartCoroutine(DestroyEnemy());
    }

    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(3f);

        Destroy(gameObject);
    }
}