using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);

        PlayerData pd = new PlayerData();

        Debug.Log(PlayerData.Instance.level + " " + PlayerData.Instance.remainingLive);
    }
	
	
    public void Save()
    {
        PlayerPrefs.SetString("data", JsonUtility.ToJson(PlayerData.Instance));
        Debug.Log("Data Kaydedildi"+PlayerData.Instance.level + " " + PlayerData.Instance.remainingLive);
    }

    public void Load()
    {
        string json = PlayerPrefs.GetString("data");       
        PlayerData pd = JsonUtility.FromJson<PlayerData>(json);
        PlayerData.Instance.UpdatePlayerData(pd);

        Debug.Log(PlayerData.Instance.level + " " + PlayerData.Instance.remainingLive);
    }

    public void TestPlayerData()
    {
        PlayerData.Instance.level  = 5;
        PlayerData.Instance.remainingLive = 3;
    }

    

}
