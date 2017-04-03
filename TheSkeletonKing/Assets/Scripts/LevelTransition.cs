using UnityEngine;
using UnityEngine.Experimental;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour {
	
	public Image FadeImg;
	public float fadeSpeed = 1.5f;
	public ArrayList mapList1 = new ArrayList ();
	public ArrayList mapList2 = new ArrayList ();
	public ArrayList mapList3 = new ArrayList ();
	public bool started;
	public string randomizedName;

	// Use this for initialization
	void Start () {
		FadeImg = GameObject.Find ("Fade").GetComponent<Image>();
		started = false;
		mapList1.Add ("Map 1");
		mapList1.Add ("Map 1.1");
		mapList1.Add ("Map 1.2");
		mapList2.Add ("Map 2");
		mapList2.Add ("Map 2.1");
		mapList2.Add ("Map 2.2");
		mapList3.Add ("Map 3");
		mapList3.Add ("Map 3.2");
	}

	public IEnumerator transitionLevel()
	{
		if (SceneManager.GetActiveScene ().name == "Tutorial")
		{
			if(!started)
			{
				yield return new WaitForSeconds (0.1f);
				randomizedName = mapList1 [Random.Range (0, mapList1.Count)].ToString();
				started = true;
				InvokeRepeating ("FadeToBlack", 0.0f, 0.1f);
				StartCoroutine (AudioFadeOut.FadeOut(GameObject.Find("Music").GetComponent<AudioSource>(),3.0f));
				yield return new WaitForSeconds (4.0f);
				SceneManager.LoadSceneAsync (randomizedName);
			}
		} 
		else if (SceneManager.GetActiveScene().name == "Map 1" || SceneManager.GetActiveScene().name == "Map 1.1" || SceneManager.GetActiveScene().name == "Map 1.2")
		{
			if (!started)
			{
				yield return new WaitForSeconds (0.1f);
				randomizedName = mapList2 [Random.Range (0, mapList2.Count)].ToString();
				started = true;
				InvokeRepeating ("FadeToBlack", 0.0f, 0.1f);
				StartCoroutine (AudioFadeOut.FadeOut(GameObject.Find("Music").GetComponent<AudioSource>(),3.0f));
				yield return new WaitForSeconds (4.0f);
				SceneManager.LoadSceneAsync (randomizedName);
			}
		}
		else if (SceneManager.GetActiveScene().name == "Map 2" || SceneManager.GetActiveScene().name == "Map 2.1" || SceneManager.GetActiveScene().name == "Map 2.2")
		{
			if (!started)
			{
				yield return new WaitForSeconds (0.1f);
				randomizedName = mapList3 [Random.Range (0, mapList3.Count)].ToString();
				started = true;
				InvokeRepeating ("FadeToBlack", 0.0f, 0.1f);
				StartCoroutine (AudioFadeOut.FadeOut(GameObject.Find("Music").GetComponent<AudioSource>(),3.0f));
				yield return new WaitForSeconds (4.0f);
				SceneManager.LoadSceneAsync (randomizedName);
			}
		}
		else if (SceneManager.GetActiveScene().name == "Map 3" || SceneManager.GetActiveScene().name == "Map 3.2")
		{
			if (!started)
			{
				yield return new WaitForSeconds (0.1f);
				started = true;
				InvokeRepeating ("FadeToBlack", 0.0f, 0.1f);
				StartCoroutine (AudioFadeOut.FadeOut(GameObject.Find("Music").GetComponent<AudioSource>(),3.0f));
				yield return new WaitForSeconds (4.0f);
				SceneManager.LoadSceneAsync ("Map Boss");
			}
		}

	}

	public void OnTriggerEnter2D(Collider2D other) {
		GameObject.Find ("Player").GetComponent<PlayerController> ().canMove = false;
		StartCoroutine("transitionLevel");
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
