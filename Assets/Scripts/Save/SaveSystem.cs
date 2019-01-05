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
        Debug.Log("Data " + PlayerData.Instance.Level);
        PlayerPrefs.SetString("orchunt_data111", JsonUtility.ToJson(PlayerData.Instance));
        //Debug.Log("Data Kaydedildi"+PlayerData.Instance.Level + " " + PlayerData.Instance.RemainingLive);
    }

    public void Load()
    {
        
        string json = PlayerPrefs.GetString("orchunt_data111");

        Debug.Log(json);

        if (json.Length > 0) {
            PlayerData pd = JsonUtility.FromJson<PlayerData>(json);
            PlayerData.Instance.UpdatePlayerData(pd);

            Debug.Log("level = " + PlayerData.Instance.Level + " " + "remaining lives= " + PlayerData.Instance.RemainingLive);
        } 
        else
        {
            DefaultPlayerData();
        }

        loaded = true;

    }

    public void DefaultPlayerData()
    {
        PlayerData.Instance.Level = 1;
        PlayerData.Instance.RemainingLive = 3;
        PlayerData.Instance.ActiveSpells = new List<string>() { "Light","Cosmic"};
        PlayerData.Instance.EarnedSpells = new List<bool>() { true, true, false, false, false, false, false, false};
        PlayerData.Instance.Sound = 1f;

        Save();
    }

    

}
