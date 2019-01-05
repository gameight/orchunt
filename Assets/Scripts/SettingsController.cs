using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsController : MonoBehaviour {

    public AudioMixer audioMixerMaster;

    private void Start()
    {
        audioMixerMaster.SetFloat("Volume", SaveSystem.playerData.sound);
    }

    public void setMasterVolume(float volume)
    {
        Debug.Log(volume);
        audioMixerMaster.SetFloat("Volume", volume);
        SaveSystem.playerData.sound = volume;
        SaveSystem.Save();
    }
}
