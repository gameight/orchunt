using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{

    private float speed = 12f;

    private Vector3 startPos;

    private static GameObject rina;

    private static GameObject[] spell = new GameObject[2];

    public static bool[] activateSpellBool = { false, false };
    static bool continueBool = false;

    // Use this for initialization
    void Start()
    {
        defaultSkills();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    void defaultSkills()
    {
        Debug.Log("Selecting default spell");
        selectSpell(0, "FlameRing");
        selectSpell(1, "Halo");
    }

    public void selectSpell(int a, string spellString)
    {
        Debug.Log("Selecting spell: " + spellString);
        rina = GameObject.Find("Rina");
        spell[a] = Instantiate(Resources.Load(spellString)) as GameObject;
        spell[a].GetComponentInChildren<ParticleSystemRenderer>().enabled = false;
        spell[a].name = spell[a].name.Replace("(Clone)", "");
        spell[a].transform.position = new Vector3(rina.transform.position.x + 1, rina.transform.position.y, rina.transform.position.z);
    }

    public void resetSpell(string spellString)
    {
        Debug.Log("Reseting spell: " + spellString);
        for (int a = 0; a < 2; a++)
        {
            if (spell[a].name == spellString)
            {
                activateSpellBool[a] = false;
                StartCoroutine(resetSpellCoroutine(a));
                break;
            }
        }
    }

    public void activateSpell(string spellString)
    {
        Debug.Log("Activating spell");
        for (int a = 0; a < 2; a++)
        {
            if (spell[a].name == spellString)
            {
                activateSpellBool[a] = true;
                StartCoroutine(activateSpellCoroutine(a));
            }
        }
    }

    IEnumerator activateSpellCoroutine(int a)
    {
        while (activateSpellBool[a])
        {
            yield return null;
            spell[a].GetComponentInChildren<ParticleSystemRenderer>().enabled = true;
            spell[a].transform.Translate(speed * Time.deltaTime, 0, 0);

        }
        continueBool = true;
        yield return 0;
    }

    IEnumerator resetSpellCoroutine(int a)
    {
        yield return new WaitUntil(() => continueBool == true);
        spell[a].GetComponentInChildren<ParticleSystemRenderer>().enabled = false;
        //spell[a].SetActive(false);
        spell[a].transform.position = new Vector3(rina.transform.position.x + 1, rina.transform.position.y, rina.transform.position.z);
    }
}
