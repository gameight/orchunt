using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretLevelCollider : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "spell" || collision.gameObject.tag == "Player")
        {
            GameObject.Find("SecretLevel").SetActive(false);
        }
    }
}
