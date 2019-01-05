using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeveloperTools : MonoBehaviour {

    [SerializeField] GameObject Buttons;

    public void OnClick(string name)
    {
        Debug.Log("Loading Scene: " + name);
        SceneManager.LoadScene(name);
    }

    public void DevBttnClick()
    {
        if (Buttons.activeSelf)
            Buttons.SetActive(false);
        else
            Buttons.SetActive(true);
    }

    public void KillBossClick()
    {
        GameObject.Find("SecretLevelBoss").GetComponent<EnemyAI>().health = -1;
    }
}
