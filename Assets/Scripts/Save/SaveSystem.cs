using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : MonoBehaviour {

    public bool loaded;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);

        PlayerData pd = new PlayerData();
        Load();
    }
	
	
    public void Save()
    {
        PlayerPrefs.SetString("data1", JsonUtility.ToJson(PlayerData.Instance));
        Debug.Log("Data Kaydedildi"+PlayerData.Instance.level + " " + PlayerData.Instance.remainingLive);
    }

    public void Load()
    {
        
        string json = PlayerPrefs.GetString("data1");



        if (json.Length > 0) {
            PlayerData pd = JsonUtility.FromJson<PlayerData>(json);
            PlayerData.Instance.UpdatePlayerData(pd);

            Debug.Log("level = " + PlayerData.Instance.level + " " + "remaining lives= " + PlayerData.Instance.remainingLive);
        } 
        else
        {
            DefaultPlayerData();
        }

        loaded = true;

    }

    public void DefaultPlayerData()
    {
        PlayerData.Instance.level = 1;
        PlayerData.Instance.remainingLive = 3;
        PlayerData.Instance.activeSpells = new List<string>() { "Light","Cosmic"};
        PlayerData.Instance.earnedSpells = new List<string>() ;
        PlayerData.Instance.music = 1f;
        PlayerData.Instance.sound = 1f;

        Save();
    }

    

}
