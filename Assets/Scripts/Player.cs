﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    private float health;
    private float fallBoundary;
    private bool dead;

    public float Health
    {
        get
        {
            return health;
        }        
    }

    public float FallBoundary
    {
        get
        {
            return fallBoundary;
        }

        set
        {
            fallBoundary = value;
        }
    }

    private void Start()
    {
        health = 100f;
        fallBoundary = -15f;
    }

    private void Update()
    {
        if (transform.position.y <= FallBoundary && !dead)
        {
            dead = true;
            DamageToPlayer(999);
        }            
    }

    public void DamageToPlayer(float damage)
    {
        health -= damage;
        SoundManager.PlaySound("rinahurt");


        if (health <= 0)
        {
            // Enable the die animation of Rina in here...
            SoundManager.PlaySound("GameOver");


            //TODO : It needs to wait until animations over.!!
            animator.SetFloat("Health", health);

            StartCoroutine(WaitForDieAnimation());
            
            
        }
    }

    IEnumerator WaitForDieAnimation()
    {
        yield return new WaitForSeconds(1.5f);

        GameMaster.KillPlayer(this);
    }






}