using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboveFallingObject : MonoBehaviour {
    Rigidbody2D rb;
    public GameObject RockEffect;
    [SerializeField] int Damage = 5;

    private void Start()

    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player")) { 
            rb.isKinematic = false;
            Debug.Log("Trap damage");
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().DamageToPlayer(Damage);
    }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals(""))
            Invoke("DropPlatform", 0.1f);
            Destroy(gameObject, 0.1f);
            RockEffect.SetActive(true);
            StartCoroutine(StopRockEffect());
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().DamageToPlayer(5);
        }
    }

    IEnumerator StopRockEffect()
    {
        yield return new WaitForSeconds(0.3f);
        RockEffect.SetActive(false);
    }

}
