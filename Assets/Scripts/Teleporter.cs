using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    public GameObject Portal;
    public GameObject Player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.name == "Rina(Clone)")
        {
            SoundManager.PlaySound("LevelBackground");
            StartCoroutine(Teleport(collision.gameObject));
        }
        
    }
    IEnumerator Teleport(GameObject player)
    {
        yield return new WaitForSeconds(1);
        player.transform.position = new Vector2(Portal.transform.position.x, Portal.transform.position.y);
    }
}
