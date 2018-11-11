using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearController : MonoBehaviour {

    Rigidbody2D rb;
    public Vector2 dir = new Vector2(-10, 0);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = dir;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") || collision.gameObject.name.Equals("Crate"))
        {
            Destroy(gameObject, 0f);
        }
    }
}
