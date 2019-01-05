using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsController : MonoBehaviour {

    public AudioMixer audioMixerMaster;

    private void Start()
    {
        audioMixerMaster.SetFloat("Volume", PlayerData.Instance.Sound);
    }

    public void setMasterVolume(float volume)
    {
        audioMixerMaster.SetFloat("Volume", volume);
        PlayerData.Instance.Sound = volume;

    }
}
