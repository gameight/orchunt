using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingGameObject : MonoBehaviour {

    Rigidbody2D rb;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            Invoke("DropPlatform", 0.2f);
            Destroy(gameObject, 1f);
            
        }
    }
    void DropPlatform()
    {
        rb.isKinematic = false;
    }
}
