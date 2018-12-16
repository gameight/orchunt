using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [System.Serializable]
    public class PlayerStats{
       
        public int Health = 100;

    }
    public PlayerStats playerStats = new PlayerStats();

    public int fallBoundary =-15;

    private void Update()
    {
        if (transform.position.y <= fallBoundary)
            DamagePlayer(999);
    }

    public void DamagePlayer(int damage){
        playerStats.Health -= damage;

        if(playerStats.Health<=0){
            GameMaster.killPlayer(this);
        }
    } 

}
