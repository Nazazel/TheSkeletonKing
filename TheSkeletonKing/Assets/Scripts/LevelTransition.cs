using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelTransition : MonoBehaviour {

	//public Image fadeScreen;
	public ArrayList mapList1 = new ArrayList ();
	public ArrayList mapList2 = new ArrayList ();
	public ArrayList mapList3 = new ArrayList ();
	public bool started;
	public string randomizedName;

	// Use this for initialization
	void Start () {
		//fadeScreen = GameObject.Find ("Fade");
		started = false;
		mapList1.Add ("Map 1");
		mapList1.Add ("Map 1.1");
		mapList1.Add ("Map 1.2");
		mapList2.Add ("Map 2");
		mapList2.Add ("Map 2.1");
		mapList2.Add ("Map 2.2");
		mapList3.Add ("Map 3");
		mapList3.Add ("Map 3.1");
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
				//yield return new WaitUntil(() => fadeScreen.color.a == 1);
				SceneManager.LoadSceneAsync (randomizedName);
			}
		} 
		else if (SceneManager.GetActiveScene().name == "Map 1" || SceneManager.GetActiveScene().name == "Map 1.1" || SceneManager.GetActiveScene().name == "Map 1.2")
		{
			if (!started)
			{
				yield return new WaitForSeconds (0.1f);
				started = true;
				SceneManager.LoadSceneAsync (mapList2 [Random.Range (0, mapList2.Count)].ToString ());
			}
		}
		else if (SceneManager.GetActiveScene().name == "Map 2" || SceneManager.GetActiveScene().name == "Map 2.1" || SceneManager.GetActiveScene().name == "Map 2.2")
		{
			if (!started)
			{
				yield return new WaitForSeconds (0.1f);
				started = true;
				SceneManager.LoadSceneAsync (mapList3 [Random.Range (0, mapList3.Count)].ToString ());
			}
		}

	}

	public void OnTriggerEnter2D(Collider2D other) {
		StartCoroutine("transitionLevel");
	}
}
