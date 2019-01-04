using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    Image healthBar;
    float maxHealth = 100f;

    // Use this for initialization
    void Start()
    {
        healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject rina = GameObject.FindGameObjectWithTag("Player");

        if (rina != null)
        {
            healthBar.fillAmount = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Health / maxHealth;
          //  Debug.Log(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Health);
        }
        else
        {
            healthBar.fillAmount = 0f;
        }
    }

}