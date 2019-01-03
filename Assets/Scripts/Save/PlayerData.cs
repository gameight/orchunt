using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public static PlayerData Instance { get; private set; }

    public int level;
    public int remainingLive;
    public List<string> activeSpells;
    public List<string> earnedSpells;
    public float sound;
    public float music;
    public string language;

    public void TestPlayerData()
    {
        level = 5;
        remainingLive = 3;
    }

    public PlayerData()
    {
        Instance = this;
    }

    public void UpdatePlayerData(PlayerData pd)
    {
        level = pd.level;
        remainingLive = pd.remainingLive;
        activeSpells = pd.activeSpells;
        earnedSpells = pd.earnedSpells;
        sound = pd.sound;
        music = pd.music;
        language = pd.language;
    }



    

}
