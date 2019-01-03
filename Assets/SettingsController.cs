using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsController : MonoBehaviour {

    public AudioMixer audioMixerMaster;

    public void setMasterVolume(float volume)
    {
        Debug.Log("Volume: " + volume);
        //audioMixerMaster.SetFloat("volume", volume);
    }

}
