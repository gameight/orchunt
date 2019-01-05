﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameMaster : MonoBehaviour
{

    public static GameMaster gm;

    public static int RemainingLives
    {
        get { return PlayerData.Instance.remainingLive; }
    }

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
      
        GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<CinemachineVirtualCamera>().Follow = GameObject.FindGameObjectWithTag("Player").transform;

       
    }

    

    public static void KillPlayer(Player player)
    {
        //player.animator.SetFloat("Health", -1);

        //gm.StartCoroutine(gm.WaitForDieAnimation());
		
		CharacterController2D.m_FacingRight = true;

        Destroy(player.gameObject);
        PlayerData.Instance.remainingLive -= 1;
        //_remainingLives -= 1;
        if (PlayerData.Instance.remainingLive <= 0)
        {
            gm.EndGame();
        }
        else
        {
            gm.StartCoroutine(gm.RespawnPlayer());

        }

    }


}




