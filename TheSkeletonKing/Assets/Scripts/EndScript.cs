using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour {

	public Image FadeImg;
	public Image panel1;
	public Image panel2;
	public Image panel3;
	public Image panel4;

	public float fadeSpeed = 1.5f;
	public GameObject introBox;
	public Text introText;
	public bool introStarted;

	// Use this for initialization
	void Start () {
		FadeImg.color = Color.clear;
		panel1.color = Color.clear;
		panel2.color = Color.clear;
		panel3.color = Color.clear;
		panel4.color = Color.clear;
		introStarted = false;
		introText = GameObject.Find ("Text").GetComponent<Text>();
		introBox.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!introStarted) {
			introStarted = true;
			StartCoroutine ("oneEnderToFindThem");
		}
	}

	public void FadeToBlack()
	{
		FadeImg.color = Color.Lerp (FadeImg.color, Color.black, fadeSpeed * Time.deltaTime);
		if (FadeImg.color.a == 1.0f) {
			CancelInvoke ("FadeToBlack");
		}
	}

	public void Fade4ToClear()
	{
		panel4.color = Color.Lerp (panel4.color, Color.white, 3* fadeSpeed * Time.deltaTime);
		if (panel4.color.a > 0.95f) {
			CancelInvoke ("Fade4ToClear");
			panel4.color = Color.white;
			Debug.Log (panel4.color.a);
		}
	}

	public void Fade3ToClear()
	{
		panel3.color = Color.Lerp (panel3.color, Color.white, 2* fadeSpeed * Time.deltaTime);
		if (panel3.color.a > 0.95f) {
			CancelInvoke ("Fade3ToClear");
			panel3.color = Color.white;
			Debug.Log (panel2.color.a);
		}
	}

	public void Fade2ToClear()
	{
		panel2.color = Color.Lerp (panel2.color, Color.white, 2* fadeSpeed * Time.deltaTime);
		if (panel2.color.a > 0.95f) {
			CancelInvoke ("Fade2ToClear");
			panel2.color = Color.white;
			Debug.Log (panel2.color.a);
		}
	}

	public void Fade1ToClear()
	{
		panel1.color = Color.Lerp (panel1.color, Color.white, 2* fadeSpeed * Time.deltaTime);
		if (panel1.color.a > 0.95f) {
			CancelInvoke ("Fade1ToClear");
			panel1.color = Color.white;
			Debug.Log (panel1.color.a);
		}
	}
	public IEnumerator oneEnderToFindThem()
	{
		InvokeRepeating ("Fade1ToClear", 0.0f, 0.1f);
		yield return new WaitForSeconds (3.0f);
		InvokeRepeating ("Fade2ToClear", 0.0f, 0.1f);
		yield return new WaitForSeconds (3.0f);
		InvokeRepeating ("Fade3ToClear", 0.0f, 0.1f);
		yield return new WaitForSeconds (3.0f);
		InvokeRepeating ("Fade4ToClear", 0.0f, 0.1f);
		yield return new WaitForSeconds (3.0f);
		introBox.SetActive (true);
		setIntroText ("Congratulations, player. You successfully aided the three souls in defeating the Skeleton King. Thanks to you, the fallen knights can now rest in eternal peace.");
		yield return new WaitUntil (() => Input.GetKeyDown (KeyCode.Return));
		yield return new WaitForSeconds (0.2f);
		InvokeRepeating ("FadeToBlack", 0.0f, 0.1f);
		StartCoroutine (AudioFadeOut.FadeOut(GameObject.Find("Music").GetComponent<AudioSource>(),5.0f));
		yield return new WaitForSeconds (6.0f);
		SceneManager.LoadSceneAsync ("Credits");
	}

	public void setIntroText(string hint)
	{
		introText.text = hint;
	}
}
