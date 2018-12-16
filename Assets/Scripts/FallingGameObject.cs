using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingGameObject : MonoBehaviour {

    Rigidbody2D rb;
    [SerializeField] float dropTime = 0.2f; //default invoke time

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            Invoke("DropPlatform", dropTime);
            Destroy(gameObject, dropTime+0.8f);
        }
    }
    void DropPlatform()
    {
        rb.isKinematic = false;
    }
}
