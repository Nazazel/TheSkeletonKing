using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialDoor : MonoBehaviour {

	public GameObject tutorialBox;
	public Text tutorialText;
	public bool obj1Complete;
	public bool obj3Complete;
	public bool obj8Complete;
	public bool Ready;
	// Use this for initialization
	void Start () {
		obj1Complete = false;
		obj3Complete = false;
		obj8Complete = false;
		Ready = false;
	}

	// Update is called once per frame
	void Update () {
		if (Ready && GameObject.FindWithTag ("ObjectiveTracker").GetComponent<Tutorial>().objectiveNum == 0)
		{
			obj1Complete = true;
			Ready = false;
		}
		else if (Ready && GameObject.FindWithTag ("ObjectiveTracker").GetComponent<Tutorial>().objectiveNum == 2)
		{
			obj3Complete = true;
			Ready = false;
		}
		else if (Ready && GameObject.FindWithTag ("ObjectiveTracker").GetComponent<Tutorial> ().objectiveNum == 7)
		{
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.FindWithTag("DoorCollider").GetComponent<PolygonCollider2D> ().enabled = false;
			GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().numKeys = 0;
			StartCoroutine ("finalhint");
			obj8Complete = true;
			Ready = false;
		}
	}
	void OnTriggerEnter2D(Collider2D other) {

		if (other.name == "Player")
			Ready = true;
	}

	void OnTriggerExit2D(Collider2D other) {

		if (other.name == "Player")
			Ready = false;
	}

	public IEnumerator finalhint()
	{
		GameObject.Find ("Player").GetComponent<PlayerController> ().canMove = false;
		tutorialBox.SetActive (true);
		tutorialText.text = "Just remember, if you ever need to interact with anything in the game, use the \"E\" key on your keyboard!";
		yield return new WaitUntil (() => Input.GetKeyDown (KeyCode.Return));
		yield return new WaitForSeconds (0.2f);
		GameObject.Find ("Player").GetComponent<PlayerController> ().canMove = true;
		tutorialBox.SetActive (false);
	}
}
