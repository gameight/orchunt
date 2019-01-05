using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public int level;
    public int remainingLive;
    public List<string> activeSpells;
    public List<bool> earnedSpells;
    public float sound;

    public void UpdatePlayerData(PlayerData pd)
    {
        level = pd.level;
        remainingLive = pd.remainingLive;
        activeSpells = pd.activeSpells;
        earnedSpells = pd.earnedSpells;
        sound = pd.sound;
    }



    

}
