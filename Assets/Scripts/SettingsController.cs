using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {
    
    public GameObject slider;

    private void Start()
    {
        SoundManager.Audiosrc.volume = SaveSystem.playerData.sound;
        slider.GetComponent<Slider>().value = SaveSystem.playerData.sound;
    }

    public void setMasterVolume(float volume)
    {
        Debug.Log(volume);
        SoundManager.Audiosrc.volume = volume;
        SaveSystem.playerData.sound = volume;
        SaveSystem.Save();
    }
}
