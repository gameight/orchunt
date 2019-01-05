using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {

    public AudioMixer audioMixerMaster;
    public GameObject slider;

    private void Start()
    {
        audioMixerMaster.SetFloat("Volume", SaveSystem.playerData.sound);
        slider.GetComponent<Slider>().value = SaveSystem.playerData.sound;
    }

    public void setMasterVolume(float volume)
    {
        Debug.Log(volume);
        audioMixerMaster.SetFloat("Volume", volume);
        SaveSystem.playerData.sound = volume;
        SaveSystem.Save();
    }
}
