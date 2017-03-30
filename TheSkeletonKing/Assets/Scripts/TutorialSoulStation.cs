using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSoulStation : MonoBehaviour {

	public bool requireButtonPress;
	private bool waitForPress;
	public bool obj4Complete;
	public bool obj6Complete;

	// Use this for initialization
	void Start () {
		waitForPress = false;
		requireButtonPress = true;
		obj4Complete = false;
		obj6Complete = false;
	}

	// Update is called once per frame
	void Update () {
		if (waitForPress && GameObject.FindWithTag ("ObjectiveTracker").GetComponent<Tutorial> ().objectiveNum == 3) 
		{
			if (waitForPress && Input.GetKeyDown (KeyCode.E)) {
				if (GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().currentSoul < 3) {
					StopAllCoroutines ();
					StartCoroutine ("OrbTransition");
					GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().currentSoul++;
				} else {
					StopAllCoroutines ();
					StartCoroutine ("OrbTransition");
					GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().currentSoul = 1;
				}
				obj4Complete = true;
			}
		}
		if (waitForPress && GameObject.FindWithTag ("ObjectiveTracker").GetComponent<Tutorial> ().objectiveNum == 5) 
		{
			if (waitForPress && Input.GetKeyDown (KeyCode.E)) {
				if (GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().currentSoul < 3) {
					StopAllCoroutines ();
					StartCoroutine ("OrbTransition");
					GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().currentSoul++;
				} else {
					StopAllCoroutines ();
					StartCoroutine ("OrbTransition");
					GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().currentSoul = 1;
				}
				obj6Complete = true;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.name == "Player") {
			if (requireButtonPress) {
				waitForPress = true;
				return;
			}

		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.name == "Player")
		{
			waitForPress = false;
		}
	}

	public IEnumerator OrbTransition()
	{
		if(GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().currentSoul == 1)
		{
			GameObject.FindWithTag ("Player").GetComponent<Animator> ().Play ("Red Orb to Blue");
			yield return new WaitForSeconds(0.5f);
			GameObject.FindWithTag ("Player").GetComponent<Animator> ().Play ("Blue Orb Idle");
			StopCoroutine ("OrbTransition");
		}
		else if(GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().currentSoul == 2)
		{
			GameObject.FindWithTag ("Player").GetComponent<Animator> ().Play ("Blue Orb to Green");
			yield return new WaitForSeconds(0.5f);
			GameObject.FindWithTag ("Player").GetComponent<Animator> ().Play ("Green Orb Idle");
			StopCoroutine ("OrbTransition");
		}
		else if(GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().currentSoul == 3)
		{
			GameObject.FindWithTag ("Player").GetComponent<Animator> ().Play ("Green Orb to Red");
			yield return new WaitForSeconds(0.5f);
			GameObject.FindWithTag ("Player").GetComponent<Animator> ().Play ("Red Orb Idle");
			StopCoroutine ("OrbTransition");
		}

	}

}
