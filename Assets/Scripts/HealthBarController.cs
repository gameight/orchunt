using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {

    public float health;

    Image healthBar;
    float maxHealth = 100f;

	// Use this for initialization
	void Start ()
    {
        healthBar = GetComponent<Image>();
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
        healthBar.fillAmount = health / maxHealth;
	}
}
