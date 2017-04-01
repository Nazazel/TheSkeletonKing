using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour {

	public Image FadeImg;
	public float fadeSpeed = 1.5f;
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
		setIntroText ("Back in the mists of time when the world was young ruled a powerful Skeleton King who had gold that would make even the poorest man live like a god.");
		yield return new WaitUntil (() => Input.GetKeyDown (KeyCode.Return));
		yield return new WaitForSeconds (0.2f);
		setIntroText ("He promised riches beyond reason to those brave warriors who could make it out of his deadly mazes unscathed.");
		yield return new WaitUntil (() => Input.GetKeyDown (KeyCode.Return));
		yield return new WaitForSeconds (0.2f);
		setIntroText ("Three brave knights took up the Skeleton King's challenge and with great precision, made it through the set of mazes to meet the king.");
		yield return new WaitUntil (() => Input.GetKeyDown (KeyCode.Return));
		yield return new WaitForSeconds (0.2f);
		setIntroText ("The king congratulated the three men on accomplishing such a feat. As he shook their hands, the king took out a sharp blade and fatally stabbed all three knights.");
		yield return new WaitUntil (() => Input.GetKeyDown (KeyCode.Return));
		yield return new WaitForSeconds (0.2f);
		setIntroText ("The Skeleton King laughed as the men laid dying. He revealed the shocking truth as all three took their last breath...there was never any gold.");
		yield return new WaitUntil (() => Input.GetKeyDown (KeyCode.Return));
		yield return new WaitForSeconds (0.2f);
		setIntroText ("The knights return as three souls, seeking vengeance on the tyrant Skeleton King who reaped them of their lives.");
		yield return new WaitUntil (() => Input.GetKeyDown (KeyCode.Return));
		yield return new WaitForSeconds (0.2f);
		setIntroText ("You, the player, will help the souls navigate through the mazes again, avoiding dangerous traps once more to find and defeat the king.");
		yield return new WaitUntil (() => Input.GetKeyDown (KeyCode.Return));
		InvokeRepeating ("FadeToBlack", 0.0f, 0.1f);
		yield return new WaitForSeconds (7.0f);

	}

	public void setIntroText(string hint)
	{
		introText.text = hint;
	}

	public void FadeToBlack()
	{
		FadeImg.color = Color.Lerp (FadeImg.color, Color.black, fadeSpeed * Time.deltaTime);
		if (FadeImg.color.a == 1.0f) {
			CancelInvoke ("FadeToBlack");
		}
	}

	public void FadeToClear()
	{
		if (SceneManager.GetActiveScene ().name == "Lose") {
			GameObject.Find ("Button").GetComponent<Image> ().enabled = false;
		}
		FadeImg.color = Color.Lerp (FadeImg.color, Color.clear, fadeSpeed * Time.deltaTime);
		if (FadeImg.color.a < 0.1f) {
			CancelInvoke ("FadeToClear");
			FadeImg.color = Color.clear;
			Debug.Log (FadeImg.color.a);
			if (SceneManager.GetActiveScene ().name == "Lose") {
				GameObject.Find ("Button").GetComponent<Image> ().enabled = true;
				DestroyImmediate (GameObject.Find ("Fade"));
				DestroyImmediate(GameObject.Find("leveltransition"));
			}
		}
	}
}
