using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboveFallingObject : MonoBehaviour {
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
            rb.isKinematic = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals(""))
            Invoke("DropPlatform", 0.1f);
            Destroy(gameObject, 0.1f);
    }

}
