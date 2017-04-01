using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialKey : MonoBehaviour {

	public GameObject tutorialBox;
	public Text tutorialText;
	public bool requireButtonPress;
	public bool waitForPress;
	public bool obj2Complete;
	public bool obj5Complete;
	public bool obj7Complete;
	// Use this for initialization
	void Start () {
		waitForPress = false;
		obj2Complete = false;
		obj5Complete = false;
		obj7Complete = false;
	}

	// Update is called once per frame
	void Update () 
	{
		if (waitForPress && GameObject.FindWithTag ("ObjectiveTracker").GetComponent<Tutorial> ().objectiveNum == 1) {
			if (waitForPress && Input.GetKey (KeyCode.E)) {

				GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().numKeys++;
				gameObject.GetComponent<SpriteRenderer> ().enabled = false;
				gameObject.GetComponent<PolygonCollider2D> ().enabled = false;
				waitForPress = false;
				obj2Complete = true;
			}
		} else if (waitForPress && GameObject.FindWithTag ("ObjectiveTracker").GetComponent<Tutorial> ().objectiveNum == 4) {
			if (waitForPress && Input.GetKey (KeyCode.E)) {

				GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().numKeys++;
				gameObject.GetComponent<SpriteRenderer> ().enabled = false;
				gameObject.GetComponent<PolygonCollider2D> ().enabled = false;
				waitForPress = false;
				obj5Complete = true;
			}
		} else if (waitForPress && GameObject.FindWithTag ("ObjectiveTracker").GetComponent<Tutorial> ().objectiveNum == 6) {
			if (waitForPress && Input.GetKey (KeyCode.E)) {

				GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().numKeys++;
				gameObject.GetComponent<SpriteRenderer> ().enabled = false;
				gameObject.GetComponent<PolygonCollider2D> ().enabled = false;
				waitForPress = false;
				obj7Complete = true;
			}
		} else if (waitForPress && GameObject.FindWithTag ("ObjectiveTracker").GetComponent<Tutorial> ().objectiveNum == 0) {
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
}