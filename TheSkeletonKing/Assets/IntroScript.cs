using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroScript : MonoBehaviour {

	public GameObject introBox;
	public Text introText;
	public bool introStarted;

	// Use this for initialization
	void Start () {
		introText = GameObject.Find ("Text").GetComponent<Text>();
		introBox.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!introStarted) {
			introStarted = true;
			StartCoroutine ("oneIntroToRuleThemAll");
		}
	}

	public IEnumerator oneIntroToRuleThemAll()
	{
		introBox.SetActive (true);
		setIntroText ("Hm, the door didn't open. That must mean you need a key to open it! Since you're currently playing as the Red Knight's soul, why don't you grab the key that's behind the black pits with the red aura?");
		yield return new WaitUntil (() => Input.GetKeyDown (KeyCode.Return));
		yield return new WaitForSeconds (0.2f);
	}

	public void setIntroText(string hint)
	{
		introText.text = hint;
	}
}
