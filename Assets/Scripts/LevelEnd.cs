using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelEnd : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        bool triggerLock = false;

        GameObject bossGameObject = GameObject.Find("Boss");

        if (bossGameObject != null && other.CompareTag("Player") && bossGameObject.GetComponent<EnemyAI>().health <= 0 && !triggerLock)
        {
            triggerLock = true;

            SaveSystem.playerData.level++;
            SaveSystem.Save();
            SceneManager.LoadScene("MapScene");
        }
    }
}
