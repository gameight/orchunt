using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3CollisonTrigger : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name.StartsWith("Level3Platform"))
            this.transform.parent = collision.transform;

        if (collision.gameObject.name.StartsWith("Trap1"))
        {
            GameObject gameObject = GameObject.Find("Trap1");
            gameObject.SetActive(false);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
        if (collision.gameObject.name.StartsWith("Level3Platform"))
            this.transform.parent = null;
        
    }
}
