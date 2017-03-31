using UnityEngine;
using System.Collections;

public class TutorialDoor : MonoBehaviour {

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
}
