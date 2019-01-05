using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : MonoBehaviour {

    public static PlayerData playerData;
    public bool loaded;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);

        playerData = new PlayerData();
        Load();
    }
	
	
    public static void Save()
    {
        PlayerPrefs.SetString("orchunt_data_17021", JsonUtility.ToJson(playerData));
        Debug.Log("Data Kaydedildi Level: " + playerData.level);
    }

    public void Load()
    {
        string json = PlayerPrefs.GetString("orchunt_data_17021");

        Debug.Log("Loaded Data: " + json);

        if (json.Length > 0) {
            PlayerData pd = JsonUtility.FromJson<PlayerData>(json);
            playerData.UpdatePlayerData(pd);

            //Debug.Log("level = " + SaveSystem.playerData.level + " " + "remaining lives= " + SaveSystem.playerData.remainingLive);
        } 
        else
        {
            DefaultPlayerData();
        }

        loaded = true;
    }

    public void DefaultPlayerData()
    {
        playerData.level = 1;
        playerData.remainingLive = 3;
        playerData.activeSpells = new List<string>() { "Light","Cosmic"};
        playerData.earnedSpells = new List<bool>() { true, true, false, false, false, false, false, false};
        playerData.sound = -5f;

        Save();
    }

    

}
