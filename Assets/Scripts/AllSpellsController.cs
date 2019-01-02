using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllSpellsController : MonoBehaviour {

    public static Dictionary<string, bool> Pairs;

    public static bool[] allSpells = { true, true, false, false, false, false, false, false };

    public static void setSpellsBools(string boss, string sceneName)
    {
        Debug.Log("setSpellBools " + boss + " " + sceneName);
        bool isSecretLevelBoss;
        if (boss.StartsWith("SecretLevel"))
            isSecretLevelBoss = true;
        else
            isSecretLevelBoss = false;

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
        for (int a = 0; a < allSpells.Length; a++)
        {
            Debug.Log(a + " - " + allSpells[a] + " ");
        }
    }
}
