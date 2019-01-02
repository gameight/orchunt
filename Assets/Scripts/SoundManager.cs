using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static AudioClip rinaHurtSound, jumpSound, skillSound, levelSound, gameOverSound;
    static AudioSource Audiosrc;



	// Use this for initialization
	void Start () {
        rinaHurtSound = Resources.Load<AudioClip>("rinahurt");
        jumpSound = Resources.Load<AudioClip>("Jump");
        skillSound = Resources.Load<AudioClip>("Skill");
        levelSound = Resources.Load<AudioClip>("LevelBackground");
        gameOverSound = Resources.Load<AudioClip>("GameOver");


        Audiosrc = GetComponent<AudioSource>();
        SoundManager.PlaySound("LevelBackground");


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void PlaySound (string clip){

        switch(clip){
            case "rinahurt" : Audiosrc.PlayOneShot(rinaHurtSound);
                break;
            case "Jump":
                Debug.Log("ses çalındı." + jumpSound.samples);
                Audiosrc.PlayOneShot(jumpSound);

                break;
            case "Skill":
                Audiosrc.PlayOneShot(skillSound);
                break;
            case "LevelBackground":
                Audiosrc.PlayOneShot(levelSound);
                break;
            case "GameOver":
                Audiosrc.Stop();
                Audiosrc.PlayOneShot(gameOverSound);
                break;
        }

    }
}
