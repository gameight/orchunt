using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsAnimater : MonoBehaviour {

    [SerializeField] GameObject panel;

    public static bool GameIsPaused = false;

    public void DisableAnimation(Animator ani)
    {
        StartCoroutine(WaitForAnimation(ani.GetCurrentAnimatorStateInfo(0).length, ani));
    }
    public void EnableAnimation(Animator ani)
    {
        StartCoroutine(WaitForAnimation(ani.GetCurrentAnimatorStateInfo(0).length, ani));
    }

    public void MainMenuClicked()
    {
        Time.timeScale = 1f;
        //SceneManager.LoadScene("MapScene");
    }

    private IEnumerator WaitForAnimation(float fl, Animator ani)
    {
        if(ani.GetBool("isDisplayed"))
        {
            Debug.Log("if");
            Time.timeScale = 1f;
            ani.SetBool("isDisplayed", false);
            yield return new WaitForSeconds(fl-0.1f);
            GameIsPaused = false;
            panel.SetActive(false);
        }
        else
        {
            Debug.Log("else");
            ani.SetBool("isDisplayed", true);
            yield return new WaitForSeconds(fl-0.1f);
            GameIsPaused = true;
            panel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
