using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSoulStation : MonoBehaviour {

	public GameObject tutorialBox;
	public Text tutorialText;
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
		if (waitForPress && GameObject.FindWithTag ("ObjectiveTracker").GetComponent<Tutorial> ().objectiveNum == 3) {
			if (waitForPress && Input.GetKeyDown (KeyCode.E)) {
				gameObject.GetComponent<AudioSource> ().Play ();
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
		} else if (waitForPress && GameObject.FindWithTag ("ObjectiveTracker").GetComponent<Tutorial> ().objectiveNum == 5) {
			if (waitForPress && Input.GetKeyDown (KeyCode.E)) {
				gameObject.GetComponent<AudioSource> ().Play ();
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
		} else if(waitForPress && GameObject.FindWithTag ("ObjectiveTracker").GetComponent<Tutorial> ().objectiveNum == 0){
			if (waitForPress && Input.GetKey (KeyCode.E)) {
				StartCoroutine ("warning");
			}
		} else if(waitForPress && GameObject.FindWithTag ("ObjectiveTracker").GetComponent<Tutorial> ().objectiveNum == 1){
			if (waitForPress && Input.GetKey (KeyCode.E)) {
				StartCoroutine ("warningtoo");
			}
		} else if(waitForPress && GameObject.FindWithTag ("ObjectiveTracker").GetComponent<Tutorial> ().objectiveNum == 2){
			if (waitForPress && Input.GetKey (KeyCode.E)) {
				StartCoroutine ("warning");
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
	public IEnumerator warning()
	{
		GameObject.Find ("Player").GetComponent<PlayerController> ().canMove = false;
		GameObject.Find ("Player").GetComponent<Rigidbody2D> ().velocity = new Vector2 (0.0f, 0.0f);
		tutorialBox.SetActive (true);
		tutorialText.text = "Not so fast, player! Try the door first.";
		yield return new WaitUntil (() => Input.GetKeyDown (KeyCode.Return));
		yield return new WaitForSeconds (0.2f);
		GameObject.Find ("Player").GetComponent<PlayerController> ().canMove = true;
		tutorialBox.SetActive (false);
	}

	public IEnumerator warningtoo()
	{
		GameObject.Find ("Player").GetComponent<PlayerController> ().canMove = false;
		GameObject.Find ("Player").GetComponent<Rigidbody2D> ().velocity = new Vector2 (0.0f, 0.0f);
		tutorialBox.SetActive (true);
		tutorialText.text = "Not so fast, player! Try getting the key first.";
		yield return new WaitUntil (() => Input.GetKeyDown (KeyCode.Return));
		yield return new WaitForSeconds (0.2f);
		GameObject.Find ("Player").GetComponent<PlayerController> ().canMove = true;
		tutorialBox.SetActive (false);
	}

}
