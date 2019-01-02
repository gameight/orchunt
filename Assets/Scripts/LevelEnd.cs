using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelEnd : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") )//&& GameObject.FindGameObjectWithTag("Boss").GetComponent<EnemyAI>().health == 0)
        {   
            SceneManager.LoadScene("MapScene");
        }
    }
}
