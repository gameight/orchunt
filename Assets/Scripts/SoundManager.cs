using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static AudioClip rinaHurtSound, jumpSound, skillSound, levelSound, gameOverSound,mapSound,orcHitSound,respawnSound;
    static AudioSource Audiosrc;



	// Use this for initialization
	void Start () {

        DontDestroyOnLoad(this);
        rinaHurtSound = Resources.Load<AudioClip>("rinahurt");
        jumpSound = Resources.Load<AudioClip>("Jump");
        skillSound = Resources.Load<AudioClip>("Skill");
        levelSound = Resources.Load<AudioClip>("LevelBackground");
        gameOverSound = Resources.Load<AudioClip>("GameOver");
        mapSound = Resources.Load<AudioClip>("MenuBackground");
        orcHitSound = Resources.Load<AudioClip>("OrcHit");
        respawnSound = Resources.Load<AudioClip>("Respawn");
        Audiosrc = GetComponent<AudioSource>();

        Audiosrc.volume = PlayerData.Instance.Sound;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void PlaySound (string clip){

        Audiosrc.volume = PlayerData.Instance.Sound;

        switch(clip){
            case "rinahurt" : 
                Audiosrc.PlayOneShot(rinaHurtSound);
                break;
            case "Jump":
                Debug.Log("ses çalındı." + jumpSound.samples);
                Audiosrc.PlayOneShot(jumpSound);

                break;
            case "Skill":
                Audiosrc.PlayOneShot(skillSound);
                break;
            case "LevelBackground":
                Audiosrc.Stop();
                Audiosrc.PlayOneShot(levelSound);
                break;
            case "GameOver":
                Audiosrc.Stop();
                Audiosrc.PlayOneShot(gameOverSound);
                break;
            case "MenuBackground":
                Audiosrc.Stop();
                Audiosrc.PlayOneShot(mapSound);
                break;
            case "OrcHit":
               
                Audiosrc.PlayOneShot(orcHitSound);
                break;
            case "Respawn":
                Audiosrc.PlayOneShot(respawnSound);
                break;
            case "Start":
                Audiosrc.PlayOneShot(mapSound);
                break;



                
        }

    }
}
