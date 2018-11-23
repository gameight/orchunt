using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearController : MonoBehaviour {

    int attackDamage = 10;

    GameObject player;                          // Reference to the player GameObject.
    PlayerHealth playerHealth;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        //anim = GetComponent<Animator>();
    }

    public Vector2 direction = new Vector2(-10, 0);

    private Rigidbody2D rigidbody2D;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    //private void FixedUpdate()
    //{
    //    rigidbody2D.velocity = direction;
    //}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            rigidbody2D.velocity = direction;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") || collision.gameObject.name.Equals("Crate"))
        {
            Attack();
            Destroy(gameObject, 0f);
        }
    }

    void Attack()
    {
        // Reset the timer.
        

        // If the player has health to lose...
        if (playerHealth.currentHealth > 0)
        {
            // ... damage the player.
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
