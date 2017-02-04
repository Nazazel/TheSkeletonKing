using UnityEngine;
using System.Collections;

public class TutorialDoor : MonoBehaviour {

	public bool obj1Complete;
	public bool Ready;
	// Use this for initialization
	void Start () {
		obj1Complete = false;
		Ready = false;
	}

	// Update is called once per frame
	void Update () {
		if (Ready && GameObject.FindWithTag ("ObjectiveTracker").GetComponent<Tutorial>().objectiveNum == 0)
		{
			obj1Complete = true;
			Ready = false;
		}
		else if (Ready && GameObject.FindWithTag ("ObjectiveTracker").GetComponent<Tutorial> ().objectiveNum == 8)
		{
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().numKeys = 0;
			Ready = false;
		}
	}
	void OnTriggerEnter2D(Collider2D other) {

		if (other.name == "Player")
			Ready = true;
	}
}
