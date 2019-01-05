using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class RemainingLivesUI : MonoBehaviour {

   
    private Text livesText;

	// Use this for initialization
	void Awake () {
        livesText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        livesText.text = "x" + SaveSystem.playerData.remainingLive.ToString();
	}
}
