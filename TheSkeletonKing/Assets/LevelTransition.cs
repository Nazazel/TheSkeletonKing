using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelTransition : MonoBehaviour {

	public ArrayList mapList1 = new ArrayList ();
	public ArrayList mapList2 = new ArrayList ();
	public ArrayList mapList3 = new ArrayList ();
	public bool started;
	public string randomizedName;

	// Use this for initialization
	void Start () {
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
		if (SceneManager.GetActiveScene ().name == "Tutorial") {
			if(!started)
			{
				yield return new WaitForSeconds (0.1f);
				randomizedName = mapList1 [Random.Range (0, mapList1.Count)].ToString();
				started = true;
				SceneManager.LoadSceneAsync (randomizedName);
			}
		} 
		else if ()
		{
			
		}
	}

	public void OnTriggerEnter2D(Collider2D other) {
		StartCoroutine("transitionLevel");
	}
}
