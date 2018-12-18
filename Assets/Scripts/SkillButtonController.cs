using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButtonController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onSpellClick()
    {
        Debug.Log("Button clicked");
        GameObject[] rina = GameObject.FindGameObjectsWithTag("Player");
        rina[0].GetComponent<SkillController>().activateSpell(this.name);
    }
}
