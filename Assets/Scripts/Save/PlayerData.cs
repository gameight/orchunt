using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    //public static PlayerData Instance { get; private set; }

    public int Level
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
            SaveSystem.Save();
        }
    }

    public int RemainingLive
    {
        get
        {
            return remainingLive;
        }

        set
        {
            remainingLive = value;
            SaveSystem.Save();

        }
    }

    public List<string> ActiveSpells
    {
        get
        {
            return activeSpells;
        }

        set
        {
            activeSpells = value;
            SaveSystem.Save();

        }
    }

    public List<bool> EarnedSpells
    {
        get
        {
            return earnedSpells;
        }

        set
        {
            earnedSpells = value;
            SaveSystem.Save();

        }
    }

    public float Sound
    {
        get
        {
            return sound;
        }

        set
        {
            sound = value;
            SaveSystem.Save();

        }
    }



   

    private int level;
    private int remainingLive;
    private List<string> activeSpells;
    private List<bool> earnedSpells;
    private float sound;




    public PlayerData()
    {
        //Instance = this;
    }

    public void UpdatePlayerData(PlayerData pd)
    {
        Level = pd.Level;
        RemainingLive = pd.RemainingLive;
        ActiveSpells = pd.ActiveSpells;
        EarnedSpells = pd.EarnedSpells;
        Sound = pd.Sound;
    }



    

}
