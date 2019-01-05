using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelEnd : MonoBehaviour
{   
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject bossGameObject = GameObject.Find("Boss");

        
            if (bossGameObject != null && other.CompareTag("Player") && bossGameObject.GetComponent<EnemyAI>().health <= 0)
            {
            PlayerData.Instance.Level ++;
            SceneManager.LoadScene("MapScene");

            }
           
       
    }
}
