using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllSpellsController : MonoBehaviour {
    
    /**
     * allSpells[0] = Light - 15 Damage - No effect - Unlock by default
     * allSpells[1] = Cosmic - 20 Damage - No effect - Unlock by default
     * allSpells[2] = Ice - 15 Damage - Ice effect (Enemy speed = speed/2 for 10 seconds) - Unlock by Level1 Secret Level Boss
     * allSpells[3] = Halo - 25 Damage - No effect - Unlock by Level2 Secret Level Boss
     * allSpells[4] = Poison - 20 Damage - Poison effect (Damage to enemy 4 damage - 3 seconds interval - 10 times) - Unlock by Level2 Final Boss
     * allSpells[5] = Mystery - 35 Damage - No effect - Unlock by Level3 Secret Level Boss
     * allSpells[6] = ToxicCloud - 25 Damage - Poison effect (Damage to enemy 5 damage - 3 seconds interval - 10 times) - Unlock by Level3 Final Boss
     * allSpells[7] = FlmaeRing - 30 Damage - Fire effect (Damage to enemy 10 damage - 2 seconds interval - 5 times) - Unlock by Level4 Secret Level Boss
     */
    public static bool[] allSpells = { true, true, false, false, false, false, false, false };

    public static void setSpellsBools(string boss, string sceneName)
    {
        Debug.Log("setSpellBools " + boss + " " + sceneName);
        bool isSecretLevelBoss;
        if (boss.StartsWith("SecretLevel"))
            isSecretLevelBoss = true;
        else
            isSecretLevelBoss = false;

        if (sceneName == "Level1" && !isSecretLevelBoss || sceneName == "Level4" && !isSecretLevelBoss)
            return; // There is no skill reward in level1 and level4 boss

        switch (sceneName)
        {
            case "Level1":
                if (isSecretLevelBoss)
                    allSpells[2] = true;
                break;
            case "Level2":
                if (isSecretLevelBoss)
                    allSpells[3] = true;
                else
                    allSpells[4] = true;
                break;
            case "Level3":
                if (isSecretLevelBoss)
                    allSpells[5] = true;
                else
                    allSpells[6] = true;
                break;
            case "Level4":
                if (isSecretLevelBoss)
                    allSpells[7] = true;
                break;
        }
        GameObject.Find("SkillsMenu").GetComponent<SkillsMenuConroller>().OnButtonClick();
    }
}
