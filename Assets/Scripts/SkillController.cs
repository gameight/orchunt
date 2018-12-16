using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour {

    private float speed = 8f;

    private Vector3 startPos;

    private static GameObject rina;

    private static GameObject[] spell = new GameObject[2];

    public static bool[] activateSpellBool = {false, false};

    // Use this for initialization
    void Start () {
        defaultSkills();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        for (int a = 0; a < 2; a++)
        {
            if (activateSpellBool[a])
            {
                spell[a].SetActive(true);
                if (spell[a].activeSelf)
                    spell[a].transform.Translate(speed * Time.deltaTime, 0, 0);
            }
        }
    }

    void defaultSkills()
    {
        Debug.Log("Selecting default spell");
        selectSpell(0, "FlameRing");
        selectSpell(1, "Halo");
    }

    public static void selectSpell(int a, string spellString) {
        Debug.Log("Selecting spell");
        rina = GameObject.Find("Rina");
        spell[a] = new GameObject();
        spell[a].SetActive(false);
        spell[a] = Instantiate(Resources.Load(spellString)) as GameObject;
        spell[a].SetActive(false);
        spell[a].transform.SetParent(rina.transform);
        spell[a].transform.position = new Vector3(rina.transform.position.x + 1, rina.transform.position.y, rina.transform.position.z);
    }

    public static void resetSpell(string spellString)
    {
        Debug.Log("Reseting spell");
        for (int a = 0; a < 2; a++)
        {
            if (spell[a].name == spellString)
            {
                spell[a].SetActive(false);
                activateSpellBool[a] = false;
                spell[a].transform.position = new Vector3(rina.transform.position.x + 1, rina.transform.position.y, rina.transform.position.z);
            }
        }
    }

    public static void activateSpell(string spellString)
    {
        Debug.Log("Activating spell");
        for (int a = 0; a < 2; a++)
        {
            if (spell[a].name.StartsWith(spellString))
            {
                activateSpellBool[a] = true;
            }
        }
    }
}
