using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour {

    private BoxCollider2D playerCollider;
    private CircleCollider2D playerCollider2;
    [SerializeField]
    private BoxCollider2D platformCollider;
    [SerializeField]
    private BoxCollider2D platformTrigger;

	// Use this for initialization
	void Start () {

        playerCollider = GameObject.Find("Rina").GetComponent<BoxCollider2D>();
        playerCollider2 = GameObject.Find("Rina").GetComponent<CircleCollider2D>();
        Physics2D.IgnoreCollision(platformTrigger, platformCollider, true);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if( collision.gameObject.name == "Rina")
        {
            Physics2D.IgnoreCollision(platformCollider, playerCollider, true);
            Physics2D.IgnoreCollision(platformCollider, playerCollider2, true);

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Rina")
        {
            Physics2D.IgnoreCollision(platformCollider, playerCollider, false);
            Physics2D.IgnoreCollision(platformCollider, playerCollider2, false);
        }
    }

}
