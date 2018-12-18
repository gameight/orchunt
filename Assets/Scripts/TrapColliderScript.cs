using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapColliderScript : MonoBehaviour
{

    [SerializeField] int Damage = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Trap damage");
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().playerStats.Health -= Damage;
        }
    }
}
