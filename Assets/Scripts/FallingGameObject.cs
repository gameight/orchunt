using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingGameObject : MonoBehaviour {

    Rigidbody2D rb;
    GameObject thisGameObj;
    Vector3 oldPos;
    [SerializeField] float dropTime = 0.2f; //default invoke time
    [SerializeField] float recreateTime = 5f; //default recreate time

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        thisGameObj = this.gameObject;
        oldPos = transform.position;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            Invoke("DropPlatform", dropTime);
            StartCoroutine(RecreateObject());
        }
    }
    void DropPlatform()
    {
        rb.isKinematic = false;
    }

    IEnumerator RecreateObject()
    {
        yield return new WaitForSeconds(dropTime + 0.8f);
        thisGameObj.GetComponent<Renderer>().enabled = false;
        thisGameObj.GetComponent<BoxCollider2D>().enabled = false;
        
        yield return new WaitForSeconds(recreateTime);
        rb.bodyType = RigidbodyType2D.Static;
        thisGameObj.transform.position = oldPos;
        thisGameObj.GetComponent<Renderer>().enabled = true;
        thisGameObj.GetComponent<BoxCollider2D>().enabled = true;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }
}
