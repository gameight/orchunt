using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{

    public static GameMaster gm;



    void Awake()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }

    void Start()
    {

    }
    public Transform playerPrefab;
    public Transform spawnPoint;
    public float spawnDelay = 1.5f;

    [SerializeField]
    private GameObject gameOverUI;

    public void EndGame()
    {
        Debug.Log("game over");
        gameOverUI.SetActive(true);
    }

    public IEnumerator RespawnPlayer()
    {
        
        yield return new WaitForSeconds(spawnDelay);
        SoundManager.PlaySound("Respawn");
        SoundManager.PlaySound("LevelBackground");
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            GameObject.FindGameObjectWithTag("Player").transform.localScale = new Vector3(1, 1, 1);
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>().jumpForce = 800;
        }
            
        GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<CinemachineVirtualCamera>().Follow = GameObject.FindGameObjectWithTag("Player").transform;
    }

    

    public static void KillPlayer(Player player)
    {
        //player.animator.SetFloat("Health", -1);

        //gm.StartCoroutine(gm.WaitForDieAnimation());
		
		CharacterController2D.m_FacingRight = true;

        Destroy(player.gameObject);
        SaveSystem.playerData.remainingLive -= 1;
        SaveSystem.Save();
        //_remainingLives -= 1;
        if (SaveSystem.playerData.remainingLive <= 0)
        {
            gm.EndGame();
        }
        else
        {
            gm.StartCoroutine(gm.RespawnPlayer());

        }

    }


}




