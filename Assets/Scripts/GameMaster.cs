using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameMaster : MonoBehaviour {
   
    public static GameMaster gm;

    void Start()
    {
        if(gm==null){
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }
    public Transform playerPrefab;
    public Transform spawnPoint;
    public float spawnDelay = 1.5f;

    public IEnumerator RespawnPlayer(){
        Debug.Log("TODO :Add waiting for spawn sound!");
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(playerPrefab,spawnPoint.position,spawnPoint.rotation);
        Debug.Log("TODO: Add spawn particles!");
        GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<CinemachineVirtualCamera>().Follow = GameObject.FindGameObjectWithTag("Player").transform;

    } 
    public static void killPlayer(Player player){
       
        Destroy(player.gameObject);
        gm.StartCoroutine(gm.RespawnPlayer());
    }


    }




