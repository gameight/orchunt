using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonController : MonoBehaviour
{

    public void onSpellClick()
    {
        Debug.Log("Button clicked");
        GameObject[] rina = GameObject.FindGameObjectsWithTag("Player");
        rina[0].GetComponent<SkillController>().activateSpell(this.name);
        GameObject[] button = GameObject.FindGameObjectsWithTag(this.name);
        button[0].GetComponent<Button>().interactable = false;
        StartCoroutine(cooldownSkill(this.name));
    }

    IEnumerator cooldownSkill(string spellString)
    {
        yield return new WaitForSeconds(1.6f);
        GameObject[] button = GameObject.FindGameObjectsWithTag(spellString);
        button[0].GetComponent<Button>().interactable = true;
    }
}
