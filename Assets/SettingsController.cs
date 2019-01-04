using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsController : MonoBehaviour {

    public AudioMixer audioMixerMaster;

    public void setMasterVolume(float volume)
    {
        audioMixerMaster.SetFloat("Volume", volume);
    }
}
